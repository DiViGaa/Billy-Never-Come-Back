using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : AnimatorController
{
    [SerializeField] private EnemyMovement enemyMovement;

    private void Update()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        RunAnimation();
        WalkAnimation();
        AttackAnimation();
    }

    private void WalkAnimation()
    {
        if (enemyMovement.transform.position == enemyMovement.startPos.position)
        {
            animator.SetBool("Walk", false);
        }
        else if (enemyMovement.DistanceToPlayer() > enemyMovement._detectionDistance)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Run", false);
        }
    }

    private void RunAnimation()
    {
        if (enemyMovement.DistanceToPlayer() < enemyMovement._detectionDistance && enemyMovement.DistanceToPlayer() >= 1) 
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
    }

    private void AttackAnimation()
    {
        if (enemyMovement.DistanceToPlayer() <= 1)
        {
            animator.SetBool("Attack", true);
        }
    }

    public bool EnemyIsAttack()
    {
        return animator.GetBool("Attack");
    }

    public void TheAttackIsOver()
    {
        animator.SetBool("Attack", false);
    }
}
