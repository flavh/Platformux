using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(0, 0);
        if (target.position.x < transform.position.x)
        {
            direction.x -= 1;
        }
        else
        {
            direction.x += 1;
        }
    }

    private void FixedUpdate()
    {
        transform.position =
            new Vector2(transform.position.x + direction.x * speed * Time.deltaTime, transform.position.y);
    }
}