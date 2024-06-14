using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class PersonMovement : MonoBehaviour
{
    [SerializeField] public float currentMovementSpeed = 1;
    [SerializeField] public float targetSpeed = 1;
    [SerializeField] public float minSpeed = 1;
    [SerializeField] public float maxSpeed = 3;
    [Min(-9.8f)] public Vector3 velocity;
    public CharacterController characterController;
    public float accelerationOfGravity = -9.8f;
    public bool IsGrounded = true;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void isGrounded()
    {
        IsGrounded = characterController.isGrounded;
    }

    public void changeCurrentMovementSpeed(float current, float target, float deltaSpeed)
    {
        currentMovementSpeed = Mathf.MoveTowards(current, target, deltaSpeed * Time.deltaTime);
    }

    abstract public void Movement();

    abstract public void Fall();

    abstract public void Run();

}
