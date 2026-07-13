using UnityEngine;
public abstract class PowerUpBase : MonoBehaviour
{
    [Header("Power-up Settings")]
    [SerializeField] private float duration = 5f;
    [SerializeField] private float cooldown = 15f;

    private float cooldownTimer;
    private float durationTimer;
    private bool isActive;
    public bool IsReady => cooldownTimer <= 0f && !isActive;
    public void Activate()
    {
        if (!IsReady) return;

        isActive = true;
        durationTimer = duration;
        cooldownTimer = cooldown;
        OnActivated();
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
            }
        }
    }
    protected abstract void OnActivated();
    protected abstract void OnDeactivated();
}