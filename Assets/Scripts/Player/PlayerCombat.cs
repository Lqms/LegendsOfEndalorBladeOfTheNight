using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    private const string attackTriggerName = "Attack";
    private const string specialAttackTriggerName = "Ability";

    private Animator _animator;
    private PlayerInput _playerInput;

    public bool AttackInProgress {get; private set;} = false;


    [SerializeField] private LayerMask _walkableLayer;
    private Vector3 _position;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if(_playerInput.AttackInput && !AttackInProgress)
        {
            Attack();
        }
        else if (_playerInput.SpecialAttackInput && !AttackInProgress)
        {
            SpecialAttack();
        }
    }

    private void SetAttackStart()
    {
        AttackInProgress = true;
    }

    private void SetAttackEnd()
    {
        AttackInProgress = false;
    }

    private void Attack()
    {
        LocatePosition();
        MoveToPosition();


        _animator.SetTrigger(attackTriggerName);
    }

    private void SpecialAttack()
    {
        LocatePosition();
        MoveToPosition();


        _animator.SetTrigger(specialAttackTriggerName);
    }



    private void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float maxDistance = 1000;

        if (Physics.Raycast(ray, out hit, maxDistance, _walkableLayer))
            _position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
    }

    private void MoveToPosition()
    {
        Quaternion newRotation = Quaternion.LookRotation(_position - transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = newRotation;
    }
}