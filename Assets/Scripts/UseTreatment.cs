using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTreatment : Interactable
{
    public override void Interact()
    {
        gameObject.SetActive(false);
    }

    
}
