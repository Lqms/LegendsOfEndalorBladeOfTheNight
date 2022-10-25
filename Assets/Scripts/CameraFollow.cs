using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private float _height;

    // [SerializeField] private float _heightDamping;

    private void LateUpdate()
    {
        float wantedHeight = _target.position.y * _height;
        float currentHeight = transform.position.y;

        // зум на персонажа
        //currentHeight = Mathf.Lerp(currentHeight, wantedHeight, _heightDamping * Time.deltaTime);

        transform.position = _target.position;
        transform.position -= Vector3.forward * _distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        transform.LookAt(_target);
    }
}
