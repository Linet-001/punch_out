using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    //void Update()
    //{
    //}

    void LateUpdate()
    {
        FollowPLayer();
    }


    void FollowPLayer()
    {
        transform.position = target.TransformPoint(offsetPosition);

        transform.rotation = target.rotation;

    }
}
