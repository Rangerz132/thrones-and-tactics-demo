using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, IEntity
{
    // FSM
    public UnitStateMachine UnitStateMachine { get; private set; }
    public UnitIdleState UnitIdleState { get; private set; }
    public UnitWalkState UnitWalkState { get; private set; }
    public UnitDeadState UnitDeadState { get; private set; }

    // Offensive States
    public UnitAttackState UnitAttackState { get; private set; }
    public UnitMoveAttackState UnitMoveAttackState { get; private set; }

    // Components
    [field: SerializeField] public Unit_SO Unit_SO { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public AgentController AgentController { get; private set; }
    [field: SerializeField] public SelectedTarget SelectedTarget { get; private set; }
    [field: SerializeField] public HealthVisual HealthVisual { get; private set; }
    [field: SerializeField] public Weapon Weapon { get; private set; }

    void Start()
    {
        // Set states
        UnitStateMachine = new UnitStateMachine();
        UnitIdleState = new UnitIdleState(this, UnitStateMachine, "isIdle");
        UnitWalkState = new UnitWalkState(this, UnitStateMachine, "isWalking");
        UnitDeadState = new UnitDeadState(this, UnitStateMachine, "isDead");
        UnitAttackState = new UnitAttackState(this, UnitStateMachine, "isAttacking");
        UnitMoveAttackState = new UnitMoveAttackState(this, UnitStateMachine, "isWalking");
        UnitStateMachine.Initialize(UnitIdleState);

        // Set unit health
        HealthVisual.SetHealth(Unit_SO.health);
    }

    void Update()
    {
        UnitStateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        UnitStateMachine.currentState.PhysicsUpdate();
    }

    /// <summary>
    /// Slerp the current unit direction to face the target
    /// </summary>
    /// <param name="transformTarget"></param>
    public void FaceTarget(Transform transformTarget, float turnSpeed)
    {
        Vector3 dir = (transformTarget.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        lookRot.x = 0;
        lookRot.z = 0;
        float t = Time.deltaTime * turnSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * turnSpeed);
    }

    public void OnClick()
    {
        HealthVisual.PlaySelectAnimation();
        SelectedTarget.PlaySelectAnimation();
    }

    public void OnRelease()
    {
        HealthVisual.PlayUnselectAnimation();
        SelectedTarget.PlayUnselectAnimation();
    }
}
