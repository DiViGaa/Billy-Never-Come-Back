using UnityEngine;

public class EnemyMovement : PersonMovement
{
    [SerializeField] private EnemyAnimator _EnemyAnimator;
    public float _detectionDistance = 5;

    private Transform _player;

    public Transform startPos;

    private void Start()
    {
        _EnemyAnimator = GetComponent<EnemyAnimator>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        IsGrounded();
        MoveToStartPos();
        Fall();
        Chase();
    }
    public override void Fall()
    {
        velocity.y += accelerationOfGravity * Time.deltaTime;
    }

    private void MoveToStartPos()
    {
        if (DistanceToPlayer() > _detectionDistance)
        {
            MoveToTarget(minSpeed, startPos);
        }
    }

    private void Chase()
    {
        if (DistanceToPlayer() <= _detectionDistance && !_EnemyAnimator.EnemyIsAttack())
        {
            MoveToTarget(maxSpeed, _player);
        }
    }

    public float DistanceToPlayer()
    {
        return Vector3.Distance(gameObject.transform.position, _player.position);
    }

    private void MoveToTarget(float targetSpeed, Transform targetPos)
    {
        this.targetSpeed = targetSpeed;
        transform.LookAt(targetPos);
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, currentMovementSpeed * Time.deltaTime);
        ChangeCurrentMovementSpeed(currentMovementSpeed, targetSpeed, _deltaSpeed);
    }
}
