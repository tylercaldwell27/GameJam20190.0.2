﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    private Transform player;
    public int rotationOffset = 0;
    // Update is called once per frame
    private void Start()
    {
        player = GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        difference.Normalize();

        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + rotationOffset);
    }
}
