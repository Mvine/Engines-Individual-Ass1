﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public Boundary boundary;

    // created a reference to the BulletPoolManager
    public BulletPoolManager bulletPoolManager;

    void Start()
    {
        boundary.Top = 2.45f;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, bulletSpeed * Time.deltaTime, 0.0f);
    }

    private void CheckBounds()
    {
        if (transform.position.y >= boundary.Top)
        {
            // This code  uses the BulletPoolManager's
            // ResetBullet function which will return the bullet to the pool
            bulletPoolManager.ResetBullet(this.gameObject);
        }
    }
}
