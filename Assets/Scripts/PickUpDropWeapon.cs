using System;
using UnityEngine;

public class PickUpDropWeapon : MonoBehaviour
{
    [SerializeField] private GameObject currentWeapon;
    [SerializeField] private bool canPicUp;
    private void OnEnable()
    {
        UseWeapon.pickUp += PickUp;
    }

    private void OnDisable()
    {
        UseWeapon.pickUp -= PickUp;
    }
    public void PickUp(GameObject weapon)
    {
        if (canPicUp)
        {
            Drop();
        }

        currentWeapon = weapon;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        currentWeapon.GetComponent<MeshCollider>().isTrigger = true;
        currentWeapon.GetComponent<Outline>().enabled = false;
        currentWeapon.transform.parent = transform;
        currentWeapon.transform.localPosition = Vector3.zero;
        currentWeapon.transform.localEulerAngles = new Vector3(82.2f, 0, 14.9f);
        currentWeapon.GetComponent<MeshCollider>().enabled = false;
        canPicUp = true;
    }

    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<MeshCollider>().isTrigger = false;
        currentWeapon.GetComponent<Outline>().enabled = true;
        canPicUp = false;
        currentWeapon.GetComponent<MeshCollider>().enabled = true;
        currentWeapon = null;
    }
}
