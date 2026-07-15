using System;
using UnityEngine;
public abstract class PowerUpBase : MonoBehaviour
{
    [Header("Power-up Settings")]
    [SerializeField] private float duration = 5f;
    [SerializeField] private float cooldown = 15f;

    public event Action OnPowerUpActivated;
    public event Action OnPowerUpDeactivated;

    private float cooldownTimer;
    private float durationTimer;

    public bool isActive { get; private set; }
    public bool IsReady => cooldownTimer <= 0f && !isActive;
    public float RemainingDuration => durationTimer;
    public void Activate()
    {
        if (!IsReady) return;

        isActive = true;
        durationTimer = duration;
        cooldownTimer = cooldown;
        OnActivated();
        OnPowerUpActivated?.Invoke();
    }
    private void Update()
    {
        if (cooldownTimer > 0f) cooldownTimer -= Time.deltaTime;

        if (isActive)
        {
            durationTimer -= Time.deltaTime;
            if (durationTimer <= 0f)
            {
                isActive = false;
                OnDeactivated();
                OnPowerUpDeactivated?.Invoke();
            }
        }
    }
    protected abstract void OnActivated();
    protected abstract void OnDeactivated();
}