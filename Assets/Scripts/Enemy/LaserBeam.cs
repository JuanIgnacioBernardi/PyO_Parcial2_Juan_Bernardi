using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class LaserBeam : MonoBehaviour
{
    private float damage;
    public void SetDamage(float value)
    {
        damage = value;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        damageable?.TakeDamage(damage);
    }
}