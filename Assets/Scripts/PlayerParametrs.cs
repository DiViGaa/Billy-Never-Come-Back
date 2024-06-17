using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    [SerializeField] public float currentHealthPoints {  get; private set;}
    [SerializeField] public float currentStamina { get; private set;}
    [SerializeField] private float _staminaDepletionRate = 20;

    private int _minimumThresholdToUseStamina = 20;
    private float maxHealthPoints = 100;
    private float maxStamina = 100;

    public float minStamina { get; private set; }
    public float minHealthPoints { get; private set; }
    public bool canRun { get; private set; }

    private PlayerParametrs()
    {
        currentHealthPoints = maxHealthPoints;
        currentStamina = maxStamina;
        minHealthPoints = 0;
        minStamina = 0;
        canRun = true;
    }

    public void DecreasedStamina()
    {
        currentStamina -= Time.deltaTime * _staminaDepletionRate;
        if (currentStamina <= minStamina)
            SetCanRun(false);
        currentStamina = Mathf.Clamp(currentStamina, minStamina, maxStamina);
    }

    public void IncreasedStamina()
    {
        currentStamina += Time.deltaTime * _staminaDepletionRate;
        if (currentStamina >= _minimumThresholdToUseStamina)
            SetCanRun(true);
        currentStamina = Mathf.Clamp(currentStamina, minStamina, maxStamina);
    }

    public void SetCanRun(bool state)
    {
        canRun = state;
    }

    public void DecreasedHealthPoints(float healthChangeAmount)
    {
        currentHealthPoints -= healthChangeAmount;
        currentHealthPoints = Mathf.Clamp(currentHealthPoints, minHealthPoints, maxHealthPoints);
    }

    public void IncreasedHealthPoints(float healthChangeAmount)
    {
        currentHealthPoints += healthChangeAmount;
        currentHealthPoints = Mathf.Clamp(currentHealthPoints, minHealthPoints, maxHealthPoints);
    }

}
