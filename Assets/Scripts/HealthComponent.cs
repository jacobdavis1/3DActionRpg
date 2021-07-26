using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    Animator animator;
    WorldUIComponent ui;

    float invincibilityTimer = 0;
    bool invincible = false;

    public bool Alive { get; set; } = true;
    public float MaxHp { get; set; } = 20;
    public float CurrentHp { get; set; } = 20;
    public float DamageReduction { get; set; } = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ui = GetComponentInChildren<WorldUIComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Alive)
            return;

        if (CurrentHp <= 0)
        {
            Alive = false;
            animator.CrossFadeInFixedTime("Die", 0.1f);
            ui.HealthBar.Disable();
        }

        if (invincible && invincibilityTimer <= 0)
            invincible = false;
        else if (invincibilityTimer > 0)
            invincibilityTimer -= Time.deltaTime;
    }

    public void Damage(float damage)
    {
        if (invincible || !Alive)
            return;

        float finalDamage = damage - DamageReduction;
        CurrentHp -= finalDamage;
        ui.HealthBar.SetBar(CurrentHp, MaxHp);

        animator.CrossFadeInFixedTime("Hit", 0.1f);

        if (CurrentHp > 0)
        {
            invincible = true;
            invincibilityTimer = 0.5f;
        }
    }

    public void Heal(float healing)
    {
        CurrentHp += healing;

        if (CurrentHp > MaxHp)
            CurrentHp = MaxHp;
    }

    public void OnDeath()
    {
        animator.speed = 0;
    }
}
