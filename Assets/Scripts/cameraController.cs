using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 6.0f;
    public float height = 1.0f;
    public float damping = 5.0f;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position + Vector3.up * height - target.forward * distance;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * damping);

            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * damping);
        }
    }
}
