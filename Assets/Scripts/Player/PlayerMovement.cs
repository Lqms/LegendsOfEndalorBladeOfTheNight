using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    private const string InputX = nameof(InputX);
    private const string InputY = nameof(InputY);

    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _walkableLayer;

    private CharacterController _characterController;
    private PlayerInput _input;
    private PlayerCombat _combat;
    private Animator _animator;
    private Vector3 _position;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<PlayerInput>();
        _combat = GetComponent<PlayerCombat>();
        _animator = GetComponent<Animator>();

        _position = transform.position;
    }

    private void Update()
    {
        if (_input.MovementInput)
        {
            _animator.SetFloat(InputX, 1);
            _animator.SetFloat(InputY, 1);
            LocatePosition();
        }

        if (!_combat.AttackInProgress)
            MoveToPosition();
        else
            _position = transform.position;
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
        if (Vector3.Distance(transform.position, _position) < 1)
        {
            _animator.SetFloat(InputX, 0);
            _animator.SetFloat(InputY, 0);
            return;
        }

        Quaternion newRotation = Quaternion.LookRotation(_position - transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
        _characterController.SimpleMove(transform.forward * _speed);
    }
}
