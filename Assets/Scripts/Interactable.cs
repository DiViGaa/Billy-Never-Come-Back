using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] public float distanceToUse = 3;
    [SerializeField] private Vector3 _playerPosition;
    [SerializeField] private Vector3 _positionInteractableObject;
    public abstract void Interact();

    public bool CanInteract()
    {
        PlayerPosition();
        PositionInteractableObject();
        return distanceToUse >= Vector3.Distance(_positionInteractableObject, _playerPosition);
    }

    private void PlayerPosition()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void PositionInteractableObject()
    {
        _positionInteractableObject = gameObject.transform.position;
    }

}
