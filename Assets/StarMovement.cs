using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _gameManager.AddScore(1);
            StartCoroutine(vanishAnimation());
        }
    }

    private IEnumerator vanishAnimation()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2(rb.velocity.x, 5);
        transform.position = new Vector2(transform.position.x, transform.position.y );
        while (rb.velocity.y >=0)
        {
            yield return null;
        }
        Destroy(gameObject);
        
    }
}
