using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothness : MonoBehaviour
{

    private Vector3 offset = new Vector3(0f, 13f, -32f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
