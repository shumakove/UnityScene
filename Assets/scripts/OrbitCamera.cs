﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

    [SerializeField]
    private Transform target;

    public float rotSpeed = 1.5f;

    private float _roY;
    private Vector3 _offset;

    // Use this for initialization
	void Start () {
        _roY = transform.eulerAngles.y;
        _offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LateUpdate() {
        float horInput = Input.GetAxis("Horizontal");
        if(horInput != 0) {
            _roY += horInput * rotSpeed;
        } else {
            _roY += Input.GetAxis("Mouse X") * rotSpeed * 3;
        }

        Quaternion rotation = Quaternion.Euler(0, _roY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
	}
}
