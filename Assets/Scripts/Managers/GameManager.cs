using UnityEngine;
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private Enemy[] enemies; 

    private int remainingEnemies;
    private void Awake()
    {
        remainingEnemies = enemies.Length;
    }
    private void OnEnable()
    {
        Enemy.OnAnyEnemyDied += HandleEnemyDied;
        playerHealth.onDie += HandlePlayerDied;
    }
    private void OnDisable()
    {
        Enemy.OnAnyEnemyDied -= HandleEnemyDied;
        playerHealth.onDie -= HandlePlayerDied;
    }
    private void HandleEnemyDied(Enemy enemy)
    {
        remainingEnemies--;
        if (remainingEnemies <= 0)
        {
            Debug.Log("VICTORYY!");
            Time.timeScale = 0f;
        }
    }
    private void HandlePlayerDied()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;
    }
}