using UnityEngine;

public class CanBeUsed : MonoBehaviour
{
    [SerializeField] private RaycastHit _hit;
    [SerializeField] private Outline _previosOutline;
    [SerializeField] private bool _buttonEIsPressed;
    [SerializeField] private int MaxDistance = 20;
    private void Update()
    {
        FindIntrectabble();
        CheckPressedKey();
        InvokeInteract();
    }

    private void FindIntrectabble()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit, MaxDistance))
        {
            if (_hit.collider.GetComponent<Outline>())
            {
                var outliner = _hit.collider.GetComponent<Outline>();
                if (outliner != null)
                {
                    _previosOutline = outliner;
                    outliner.OutlineWidth = 5;
                }
            }
            else
            {
                if (_previosOutline != null)
                {
                    _previosOutline.OutlineWidth = 0;
                }
            }
        }
    }

    private void CheckPressedKey()
    {
        _buttonEIsPressed = Input.GetKeyDown(KeyCode.E);
    }

    private void InvokeInteract()
    {
        if (_buttonEIsPressed && _hit.collider.GetComponent<Interactable>())
            _hit.collider.GetComponent<Interactable>().Interact();
    }
}
