using System.Collections.Generic;
using UnityEngine;
public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int initialSize = 20;
    private readonly Queue<Projectile> pool = new Queue<Projectile>();
    private void Awake()
    {
        for (int i = 0; i < initialSize; i++)
        {
            Projectile proj = Instantiate(projectilePrefab, transform);
            proj.gameObject.SetActive(false);
            pool.Enqueue(proj);
        }
    }
    public void Spawn(Vector2 position, Vector2 direction, float speed, float damage, ProjectileOwner owner)
    {
        Projectile proj = pool.Count > 0 ? pool.Dequeue() : Instantiate(projectilePrefab, transform);

        proj.transform.position = position;
        proj.transform.rotation = Quaternion.identity;
        proj.gameObject.SetActive(true);
        proj.Configure(direction, speed, damage, owner, this);
    }
    public void Return(Projectile proj)
    {
        proj.gameObject.SetActive(false);
        pool.Enqueue(proj);
    }
}