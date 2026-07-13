using UnityEngine;
using UnityEngine.UI;
public class HeartsUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HealthSystem playerHealth;
    [SerializeField] private Image[] heartFills;
    private void OnEnable()
    {
        playerHealth.onLifeChanged += HandleLifeChanged;
    }
    private void OnDisable()
    {
        playerHealth.onLifeChanged -= HandleLifeChanged;
    }
    private void HandleLifeChanged(float current, float max)
    {
        for (int i = 0; i < heartFills.Length; i++)
        {
            float heartValue = current - i;
            heartFills[i].fillAmount = Mathf.Clamp01(heartValue);
        }
    }
}