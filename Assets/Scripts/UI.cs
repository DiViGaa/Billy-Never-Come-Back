using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private Slider _healthPointsSlider;
    [SerializeField] private PlayerParametrs _playerParametrs;

    private void Update()
    {
        UpdateStaminaSlider();
        UpdateHealthPointsSlider();
    }

    public void UpdateStaminaSlider()
    {
        _staminaSlider.value = _playerParametrs.currentStamina;
    }

    public void UpdateHealthPointsSlider()
    {
        _healthPointsSlider.value = _playerParametrs.currentHealthPoints;
    }
}
