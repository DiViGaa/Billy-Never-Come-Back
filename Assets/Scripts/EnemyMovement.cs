using UnityEngine;

public class EnemyMovement : PersonMovement
{
    [SerializeField] public float _detectionDistance = 5;
    [SerializeField] private EnemyAnimator _EnemyAnimator;

    private Transform _player;
    private float _deltaSpeed = 20;

    public Transform startPos;

    private void Start()
    {
        _EnemyAnimator = GetComponent<EnemyAnimator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        isGrounded();
        Movement();
        Fall();
        Run();
    }
    public override void Fall()
    {
        velocity.y += accelerationOfGravity * Time.deltaTime;
    }

    public override void Movement()
    {
        if (DistanceToPlayer() > _detectionDistance)
        {
            transform.LookAt(startPos);
            transform.position = StartPosition();
        }
    }

    private Vector3 StartPosition()
    {
        return Vector3.MoveTowards(transform.position, startPos.position, currentMovementSpeed * Time.deltaTime);
    }

    public override void Run()
    {
        targetSpeed = minSpeed;
        if((DistanceToPlayer() < _detectionDistance && DistanceToPlayer() >= 1) && !_EnemyAnimator.EnemyIsAttack())
        {
            targetSpeed = maxSpeed;
            transform.LookAt(_player);
            transform.position = Vector3.MoveTowards(transform.position, _player.position, currentMovementSpeed * Time.deltaTime);
        }
        changeCurrentMovementSpeed(currentMovementSpeed, targetSpeed, _deltaSpeed);
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(gameObject.transform.position, _player.position);
    }
}
