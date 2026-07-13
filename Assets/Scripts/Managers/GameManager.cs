using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private float restartDelay = 2f;

    private int remainingEnemies;
    private bool gameEnded;
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
            EndGame("VICTORY: ALL ENEMIES ARE DEFEATED!");
    }
    private void HandlePlayerDied()
    {
        EndGame("GAME OVER: player died.");
    }
    private void EndGame(string message)
    {
        if (gameEnded) return;
        gameEnded = true;

        Debug.Log(message);
        StartCoroutine(RestartAfterDelay());
    }
    private IEnumerator RestartAfterDelay()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(restartDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}