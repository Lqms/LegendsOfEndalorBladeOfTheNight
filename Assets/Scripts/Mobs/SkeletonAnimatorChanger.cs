using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class SkeletonAnimatorChanger : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController _walk;
    [SerializeField] private RuntimeAnimatorController _attack;
    [SerializeField] private float _attackRange = 1;

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
            _target = player.transform;
            StartCoroutine(RunningToTargetCoroutine());
        }
    }

    private IEnumerator RunningToTargetCoroutine() 
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, _target.position) > _attackRange)
            {
                _agent.SetDestination(_target.position);
                _animator.runtimeAnimatorController = _walk;
            }
            else
            {
                _agent.SetDestination(transform.position);
                _animator.runtimeAnimatorController = _attack;
            }

            yield return null;
        }
    }
}
