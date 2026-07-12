using UnityEngine;

public enum ProjectileOwner { Player, Enemy }

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 4f;

    private Vector2 direction;
    private float speed;
    private float damage;
    private ProjectileOwner owner;
    private float timer;
    private ProjectilePool pool;
    public void Configure(Vector2 dir, float spd, float dmg, ProjectileOwner projOwner, ProjectilePool sourcePool)
    {
        direction = dir.normalized;
        speed = spd;
        damage = dmg;
        owner = projOwner;
        pool = sourcePool;
        timer = 0f;
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
            Disable();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool hitsPlayer = owner == ProjectileOwner.Enemy && other.CompareTag("Player");
        bool hitsEnemy = owner == ProjectileOwner.Player && other.CompareTag("Enemy");
        if (!hitsPlayer && !hitsEnemy) return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null) return;

        damageable.TakeDamage(damage);
        Disable();
    }
    private void Disable()
    {
        if (pool != null)
            pool.Return(this);
        else
            Destroy(gameObject);
    }
}