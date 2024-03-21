using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        Translation();
        Rotation();
    }

    private void Translation()
    {
        var targetPos = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPos, translateSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
