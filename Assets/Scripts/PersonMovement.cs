using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class PersonMovement : MonoBehaviour
{
    public float currentMovementSpeed = 1;
    public float targetSpeed = 1;
    public float minSpeed = 1;
    public float maxSpeed = 3;
    [Min(-9.8f)] public Vector3 velocity;
    public CharacterController characterController;
    public float accelerationOfGravity = -9.8f;
    public bool isGrounded = true;
    public float _deltaSpeed = 1;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void IsGrounded()
    {
        isGrounded = characterController.isGrounded;
    }

    public void ChangeCurrentMovementSpeed(float current, float target, float deltaSpeed)
    {
        currentMovementSpeed = Mathf.MoveTowards(current, target, deltaSpeed * Time.deltaTime);
    }

    abstract public void Fall();


}
