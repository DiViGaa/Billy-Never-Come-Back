using System;
using UnityEngine;

public class PlayerAnimator : AnimatorController
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private string _currentWeaponInHand;

    private KeyCode space = KeyCode.Space;
    private KeyCode mouseLeft = KeyCode.Mouse0;
    private void OnEnable()
    {
        PlayerAnimatorEvent.weaponInHand += WeaponAnimation;
    }
    private void OnDisable()
    {
        PlayerAnimatorEvent.weaponInHand -= WeaponAnimation;
    }
    private void Update()
    {
        UpdatePlayerMovement();
        ChangeAnimatorAxis();
        JumpAnimation();
        AttackAnimation();
        isGrounded();
    }

    private void UpdatePlayerMovement()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void ChangeAnimatorAxis()
    {
        animator.SetFloat("X", HorizontalSpeed());
        animator.SetFloat("Y", VerticalSpeed());
    }

    private float HorizontalSpeed()
    {
        return _playerMovement.horizontalAxis * _playerMovement.currentMovementSpeed;
    }

    private float VerticalSpeed()
    {
        return _playerMovement.verticalAxis * _playerMovement.currentMovementSpeed;
    }

    private void JumpAnimation()
    {
        if (Input.GetKeyDown(space) && _playerMovement.IsGrounded)
            animator.SetTrigger("Jump");
        
    }

    private void AttackAnimation()
    {
        if (Input.GetKeyDown(mouseLeft) && WeaponInHand())
            animator.SetTrigger("Attack");
    }

    private bool WeaponInHand()
    {
        return (animator.GetBool("OneHandWeapon") || animator.GetBool("TwoHandWeapon"));
    }

    private void isGrounded()
    {
        animator.SetBool("IsGraunded", _playerMovement.IsGrounded);
    }

    public void WeaponAnimation(string weaponTag)
    {
        animator.SetBool(_currentWeaponInHand, false);

            if (_currentWeaponInHand != weaponTag)
                _currentWeaponInHand = weaponTag;

        animator.SetBool(_currentWeaponInHand, true);
    }

    public void JumpEvent()
    {
        _playerMovement.Jump();
    }
}
