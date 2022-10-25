using UnityEngine;

namespace Retro.ThirdPersonCharacter
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(PlayerCombat))]
    public class Jumping : MonoBehaviour
    {
        private Animator _animator;
        private PlayerInput _playerInput;
        private PlayerCombat _combat;

        private bool isGrouned;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _combat = GetComponent<PlayerCombat>();
        }

        private void Update()
        {
            // if(_playerInput.Jump)
        }
    }
}