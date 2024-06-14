using UnityEngine;


public class PlayerMovement : PersonMovement
{
    [SerializeField][Range(0, 100)] private float currentStamina = 100;
    [SerializeField] private float jumpStrength = 1;
    [SerializeField] private float _deltaSpeed = 1f;
    [SerializeField] private float _staminaDepletionRate = 20;

    public float horizontalAxis { get; private set; }
    public float verticalAxis { get; private set; }
    private float _smoothTime;
    private Vector3 _directionOfMovement;
    private float _smoothVelocity;
    private float _lastRotation;
    private bool canRun = true;

    private void Update()
    {
        Movement();
        GetAxis();
        Rotate();
        Fall();
        Run();
        isGrounded();
    }
    public override void Movement()
    {
        _directionOfMovement = new Vector3(horizontalAxis, 0, verticalAxis).normalized;
        characterController.Move(_directionOfMovement * Time.deltaTime * currentMovementSpeed);
        characterController.Move(velocity * Time.deltaTime);
    }

    private void GetAxis()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
    }
    public void Jump()
    {
        if (IsGrounded)
            velocity.y = Mathf.Sqrt(jumpStrength * -2f * accelerationOfGravity);
    }

    public override void Fall()
    {
        velocity.y += accelerationOfGravity * Time.deltaTime;
    }


    public override void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && canRun && PlayerMoves())
        {
            targetSpeed = maxSpeed;
            currentStamina -= Time.deltaTime * _staminaDepletionRate;
        }
        else
        {
            canRun = false;
            targetSpeed = minSpeed;
            currentStamina += Time.deltaTime * _staminaDepletionRate;
            if (currentStamina >= 20)
            {
                canRun = true;
            }
        }
        changeCurrentMovementSpeed(currentMovementSpeed, targetSpeed, _deltaSpeed);
    }


    private bool PlayerMoves()
    {
        return horizontalAxis != 0 || verticalAxis != 0;
    }

    private void Rotate()
    {
        float rotation = DegreesBetweenTheMotionVector();

        if (_directionOfMovement != Vector3.zero)
            _lastRotation = rotation;

        float angle = SmoothChangeInAngleOfRotation();
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    private float DegreesBetweenTheMotionVector()
    {
        return Mathf.Atan2(_directionOfMovement.x, _directionOfMovement.z) * Mathf.Rad2Deg;
    }

    private float SmoothChangeInAngleOfRotation()
    {
        return Mathf.SmoothDampAngle(transform.eulerAngles.y, _lastRotation, ref _smoothVelocity, _smoothTime);
    }

}
