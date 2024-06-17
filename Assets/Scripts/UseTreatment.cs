using UnityEngine;

public class UseTreatment : Interactable
{
    [SerializeField] private float healthChangeAmount = 20;
    [SerializeField] private PlayerParametrs _playerParametrs;
    public override void Interact()
    {
        _playerParametrs.IncreasedHealthPoints( healthChangeAmount);
        Destroy(gameObject);
    }
}
