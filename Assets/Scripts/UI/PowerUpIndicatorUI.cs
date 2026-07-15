using UnityEngine;
using UnityEngine.UI;
public class PowerUpIndicatorUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PowerUpBase powerUp;
    [SerializeField] private GameObject indicatorRoot;
    [SerializeField] private Text remainingText;
    private void OnEnable()
    {
        powerUp.OnPowerUpActivated += HandleActivated;
        powerUp.OnPowerUpDeactivated += HandleDeactivated;
        indicatorRoot.SetActive(false);
    }
    private void OnDisable()
    {
        powerUp.OnPowerUpActivated -= HandleActivated;
        powerUp.OnPowerUpDeactivated -= HandleDeactivated;
    }
    private void HandleActivated()
    {
        indicatorRoot.SetActive(true);
    }
    private void HandleDeactivated()
    {
        indicatorRoot.SetActive(false);
    }
    private void Update()
    {
        if (!indicatorRoot.activeSelf) return;
        remainingText.text = Mathf.Ceil(powerUp.RemainingDuration) + "s";
    }
}