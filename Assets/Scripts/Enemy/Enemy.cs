using System;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private ProjectilePool projectilePool;

    public static event Action<Enemy> OnAnyEnemyDied;
    private HealthSystem health;
    private void Awake()
    {
        health = GetComponent<HealthSystem>();

        health.onDie += HandleDeath;
    }
    private void HandleDeath()
    {
        OnAnyEnemyDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}