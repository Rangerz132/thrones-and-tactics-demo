using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisual : Health
{
    [field: SerializeField] public GameObject Canvas { get; private set; }
    [SerializeField] private Image healthBar;
    private Animator animator;

    private void Awake()
    {
        animator = Canvas.GetComponent<Animator>();
    }

    /// <summary>
    /// Set the lowest amount of life
    /// </summary>
    public void InitializeHealth(float health)
    {
        currentHealth = 1;
        maxHealth = health;
        SetHealthBar();
    }

    /// <summary>
    /// Override health values by an entity ScriptableObject health values
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(float health)
    {
        currentHealth = health;
        maxHealth = health;
        this.SetHealthBar();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        SetHealthBar();
    }

    public override void Heal(float healAmount)
    {
        base.Heal(healAmount);
        SetHealthBar();
    }

    /// <summary>
    /// Set the health bar visually
    /// </summary>
    private void SetHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void PlaySelectAnimation()
    {
        animator.SetTrigger("Select");
    }

    public void PlayUnselectAnimation()
    {
        animator.SetTrigger("Unselect");
    }
}

