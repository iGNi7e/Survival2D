﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    private Vector3 currentVelocity;

    private void LateUpdate()
    {
        if (target == null)
            return;
        Vector3 newPos = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position,newPos,ref currentVelocity,0.1f);
        //transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
    }
}
