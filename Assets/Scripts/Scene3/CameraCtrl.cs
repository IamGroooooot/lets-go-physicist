﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform playerTxt;
    public Transform Txt1;
    public Transform target;
    public Vector3 offset;
    private float currentZoom = 10;
    public float pitch = 1;
    public float zoomSpeed = 4f;
    public float minZoom= 5f;
    public float maxZoom= 15f;

    public float yawSpeed = 100f;
    private float currentYaw = 0;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom,minZoom,maxZoom);

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed*Time.deltaTime;
        playerTxt.LookAt(this.transform.position);
        Txt1.LookAt(this.transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position,Vector3.up, currentYaw);
    }
}