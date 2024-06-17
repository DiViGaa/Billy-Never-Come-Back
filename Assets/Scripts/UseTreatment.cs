using UnityEngine;

public class UseTreatment : Interactable
{
    [SerializeField] private float healthChangeAmount = 20;
    [SerializeField] private PlayerParametrs _playerParametrs;
    private bool _dealsDamage = false;
    public override void Interact()
    {
        _playerParametrs.ChangeHealthPoints(_dealsDamage, healthChangeAmount);
        Destroy(gameObject);
    }
}
