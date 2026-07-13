using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    [Header("Laser Settings")]
    [SerializeField] private float maxLength = 20f;

    private LineRenderer line;
    private float damage;
    private bool hasDamagedThisActivation;
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }
    public void SetDamage(float value)
    {
        damage = value;
    }
    private void OnEnable()
    {
        hasDamagedThisActivation = false;
    }
    private void Update()
    {
        RaycastHit2D playerHit = FindPlayerHit();
        float length = playerHit.collider != null ? playerHit.distance : maxLength;

        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0f, -length, 0f));

        if (playerHit.collider != null && !hasDamagedThisActivation)
        {
            IDamageable damageable = playerHit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                hasDamagedThisActivation = true;
            }
        }
    }
    private RaycastHit2D FindPlayerHit()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, maxLength);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.CompareTag("Player"))
                return hit;
        }
        return default;
    }
}