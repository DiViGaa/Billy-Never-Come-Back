using UnityEngine;

public abstract class AnimatorController : MonoBehaviour
{
    [SerializeField] public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
