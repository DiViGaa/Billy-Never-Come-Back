using System;
using UnityEngine;

public class PlayerAnimator : AnimatorController
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private string _currentWeaponInHand;

    private readonly KeyCode space = KeyCode.Space;
    private readonly KeyCode mouseLeft = KeyCode.Mouse0;
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
        IsGrounded();
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
        return _playerMovement.HorizontalAxis * _playerMovement.currentMovementSpeed;
    }

    private float VerticalSpeed()
    {
        return _playerMovement.VerticalAxis * _playerMovement.currentMovementSpeed;
    }

    private void JumpAnimation()
    {
        if (Input.GetKeyDown(space) && _playerMovement.isGrounded)
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

    private void IsGrounded()
    {
        animator.SetBool("IsGraunded", _playerMovement.isGrounded);
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
