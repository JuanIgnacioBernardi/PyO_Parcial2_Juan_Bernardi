using System;
using UnityEngine;
[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private ProjectilePool projectilePool;

    public static event Action<Enemy> OnAnyEnemyDied;

    private HealthSystem health;
    private IEnemyAttackStrategy attackStrategy;

    private void Awake()
    {
        health = GetComponent<HealthSystem>();
        attackStrategy = GetComponent<IEnemyAttackStrategy>();
        attackStrategy?.Init(firePoint, projectilePool);

        health.onDie += HandleDeath;
    }

    private void Update()
    {
        attackStrategy?.Tick(Time.deltaTime);
    }

    private void HandleDeath()
    {
        OnAnyEnemyDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}