using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class SkeletonAnimatorChanger : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController _walk;

    private Animator _animator;
    private Transform _target;
    private NavMeshAgent _agent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _animator.runtimeAnimatorController = _walk;
            _target = player.transform;
            StartCoroutine(RunningToTargetCoroutine());
        }
    }

    private IEnumerator RunningToTargetCoroutine() 
    {
        while (true)
        {
            if (transform.position != _target.position)
            {
                _agent.SetDestination(_target.position);
            }

            yield return null;
        }
    }
}
