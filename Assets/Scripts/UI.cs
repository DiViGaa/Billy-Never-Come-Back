using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private Slider _healthPointsSlider;
    [SerializeField] private PlayerParametrs _playerParametrs;
    [SerializeField] private Slider _EnemyHealthPointsSlider;
    [SerializeField] private EnemyParametrs _EnemyParametrs;

    private void Update()
    {
        UpdateStaminaSlider();
        UpdateHealthPointsSlider();
        UpdateEnemyHealthPointsSlider();
    }

    public void UpdateStaminaSlider()
    {
        _staminaSlider.value = _playerParametrs.currentStamina;
    }

    public void UpdateHealthPointsSlider()
    {
        _healthPointsSlider.value = _playerParametrs.currentHealthPoints;
    }

    public void UpdateEnemyHealthPointsSlider()
    {
        _EnemyHealthPointsSlider.value = _EnemyParametrs.currentHealthPoints;
    }
}
