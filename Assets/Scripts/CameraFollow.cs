using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;

    private void LateUpdate()
    {
        float currentHeight = transform.position.y;

        transform.position = _target.position;
        transform.position -= Vector3.forward * _distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.LookAt(_target);
    }
}
