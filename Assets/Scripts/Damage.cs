using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerDamage(other);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            EnemyDamage(other);
        }
    }

    private void EnemyDamage(Collider other)
    {
        var enemyParameters = other.gameObject.GetComponent<EnemyParametrs>();
        enemyParameters.DecreasedHealthPoints(_damage);
    }

    private void PlayerDamage(Collider other)
    {
        var playerParameters = other.gameObject.GetComponent<PlayerParametrs>();
        playerParameters.DecreasedHealthPoints(_damage);
    }
}
