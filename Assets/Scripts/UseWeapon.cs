using System;
using UnityEngine;

public class UseWeapon : Interactable
{
    public static Action<GameObject> pickUp;
    public override void Interact()
    {
        if (CanInteract())
        {
            pickUp?.Invoke(gameObject);
            PlayerAnimatorEvent.weaponInHand?.Invoke(gameObject.tag);
        }
    }
}
