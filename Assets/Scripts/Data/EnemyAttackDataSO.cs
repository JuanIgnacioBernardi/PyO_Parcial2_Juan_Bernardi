using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttackData", menuName = "SpaceInvaders/Enemy Attack Data")]
public class EnemyAttackDataSO : ScriptableObject
{
    public float fireInterval = 2f;
    public float bulletSpeed = 6f;
    public float damage = 0.5f;
}