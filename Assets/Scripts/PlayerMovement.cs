using UnityEngine;


public class PlayerMovement : PersonMovement
{
    [SerializeField] private float jumpStrength = 1;
    [SerializeField] private PlayerParametrs _playerParametrs;

    public float HorizontalAxis { get; private set; }
    public float VerticalAxis { get; private set; }

    private Vector3 _directionOfMovement;
    private float _smoothVelocity;
    private float _lastRotation;
    private float _smoothTime;
    

    private void Start()
    {
        _playerParametrs = GetComponent<PlayerParametrs>();
    }

    private void Update()
    {
        Movement();
        GetAxis();
        Rotate();
        Fall();
        Run();
        IsGrounded();
    }
    public void Jump()
    {
        if (isGrounded)
            velocity.y = Mathf.Sqrt(jumpStrength * -2f * accelerationOfGravity);
    }

    public override void Fall()
    {
        velocity.y += accelerationOfGravity * Time.deltaTime;
    }

    private void Movement()
    {
        _directionOfMovement = new Vector3(HorizontalAxis, 0, VerticalAxis).normalized;
        characterController.Move(_directionOfMovement * Time.deltaTime * currentMovementSpeed);
        characterController.Move(velocity * Time.deltaTime);
    }

    private void GetAxis()
    {
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");
    }


    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _playerParametrs.canRun && PlayerMoves())
        {
            targetSpeed = maxSpeed;
            _playerParametrs.DecreasedStamina();

        }
        else
        {
            targetSpeed = minSpeed;
            _playerParametrs.IncreasedStamina();
        }
        ChangeCurrentMovementSpeed(currentMovementSpeed, targetSpeed, _deltaSpeed);
    }


    private bool PlayerMoves()
    {
        return HorizontalAxis != 0 || VerticalAxis != 0;
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
