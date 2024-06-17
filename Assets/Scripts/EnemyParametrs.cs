using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyParametrs : MonoBehaviour
{
    [SerializeField] public float currentHealthPoints { get; private set; }
    private float maxHealthPoints = 100;
    public float minHealthPoints { get; private set; }

    private void Update()
    {
        IsDead();
    }

    private EnemyParametrs()
    {
        currentHealthPoints = maxHealthPoints;
        minHealthPoints = 0;
    }

    public void DecreasedHealthPoints(float healthChangeAmount)
    {
        currentHealthPoints -= healthChangeAmount;
        currentHealthPoints = Mathf.Clamp(currentHealthPoints, minHealthPoints, maxHealthPoints);
    }
    private void IsDead()
    {
        if (currentHealthPoints <= minHealthPoints)
        {
            Destroy(gameObject);
        }
    }
}
