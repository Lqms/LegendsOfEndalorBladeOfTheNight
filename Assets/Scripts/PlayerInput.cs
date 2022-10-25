using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _attackInput;
    private bool _specialAttackInput;
    private bool _jumpInput;
    private bool _movementInput;

    public bool AttackInput => _attackInput;
    public bool SpecialAttackInput => _specialAttackInput;
    public bool JumpInput => _jumpInput;
    public bool MovementInput => _movementInput;

    private void Update()
    {
        _attackInput = Input.GetMouseButtonDown(0);
        _specialAttackInput = Input.GetKeyDown(KeyCode.R);
        _movementInput = Input.GetMouseButton(1);
        // _jumpInput = Input.GetButton("Jump");
    }
}