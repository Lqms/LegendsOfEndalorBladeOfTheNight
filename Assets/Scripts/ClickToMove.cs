using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ClickToMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private Animator _animator;
    private Vector3 _position;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _position = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _animator.SetFloat("InputX", 1);
            _animator.SetFloat("InputY", 1);
            _animator.SetBool("IsInAir", false);
            LocatePosition();
        }

        MoveToPosition();
    }

    private void LocatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            _position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
    }

    private void MoveToPosition()
    {
        if (Vector3.Distance(transform.position, _position) < 1)
        {
            _animator.SetFloat("InputX", 0);
            _animator.SetFloat("InputY", 0);
            _animator.SetBool("IsInAir", false);
            return;
        }

        Quaternion newRotation = Quaternion.LookRotation(_position - transform.position, Vector3.forward);

        newRotation.x = 0;
        newRotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
        _characterController.SimpleMove(transform.forward * _speed);
    }
}
