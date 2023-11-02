using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Collider weaponCollider;
    [SerializeField] private Unit unit;

    private void Awake()
    {
        weaponCollider = GetComponent<Collider>();
    }

    public virtual void EnableCollider(bool enabled)
    {
        weaponCollider.enabled = enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Unit collidingUnit))
        {
            if (unit.UnitAttackState.target == collidingUnit.gameObject)
            {
                DamageTarget(collidingUnit);
            }
        }
    }

    public void DamageTarget(Unit collidingUnit)
    {
        collidingUnit.HealthVisual.TakeDamage(unit.Unit_SO.unitAttack.damage);

        // Repost
        if (collidingUnit.UnitStateMachine.currentState != collidingUnit.UnitAttackState && collidingUnit.UnitStateMachine.currentState != collidingUnit.UnitMoveAttackState) {
            collidingUnit.UnitMoveAttackState.target = unit.gameObject;
            collidingUnit.UnitAttackState.target = unit.gameObject;
            collidingUnit.UnitStateMachine.ChangeState(collidingUnit.UnitMoveAttackState);
        }

        // Target is dead
        if (collidingUnit.HealthVisual.currentHealth <= 0) 
        {
            collidingUnit.UnitStateMachine.ChangeState(collidingUnit.UnitDeadState);
            unit.UnitStateMachine.ChangeState(unit.UnitIdleState);
        }
    }
}
