using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerParametrs : MonoBehaviour
{
    [SerializeField] public float currentHealthPoints {  get; private set;}
    [SerializeField] public float currentStamina { get; private set;}
    [SerializeField] private float _staminaDepletionRate = 20;

    private float maxHealthPoints = 100;
    private float maxStamina = 100;

    public float minStamina { get; private set; }
    public float minHealthPoints { get; private set; }
    public bool canRun { get; private set; }
    public bool death { get; private set; }

    private PlayerParametrs()
    {
        currentHealthPoints = maxHealthPoints;
        currentStamina = maxStamina;
        minHealthPoints = 0;
        minStamina = 0;
        canRun = true;
        death = false;
    }


    public void ChangeStamina(bool regenregeneration)
    {
        if (regenregeneration)
            currentStamina += Time.deltaTime * _staminaDepletionRate;
        else
            currentStamina -= Time.deltaTime * _staminaDepletionRate;

        currentStamina = Mathf.Clamp(currentStamina, minStamina, maxStamina);
    }

    public void SetCanRun(bool state)
    {
        canRun = state;
    }

    public void ChangeHealthPoints(bool dealsDamage, float healthChangeAmount)
    {
        if (dealsDamage)
            currentHealthPoints -= healthChangeAmount;
        else
            currentHealthPoints += healthChangeAmount;

        currentStamina = Mathf.Clamp(currentHealthPoints, minHealthPoints, maxHealthPoints);
    }

    public void SetDeath(bool state)
    {
        death = state;
    }
}
