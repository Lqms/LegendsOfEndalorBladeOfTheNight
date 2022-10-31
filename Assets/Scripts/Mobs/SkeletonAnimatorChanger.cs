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
            StartCoroutine(RunningToTargetCoroutine(player.transform));
        }
    }

    private IEnumerator RunningToTargetCoroutine(Transform target) 
    {
            if (!_agent.SetDestination(target.position))
                yield return null;
    }
}
