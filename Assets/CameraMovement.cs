using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMovement : MonoBehaviour
{
    [FormerlySerializedAs("position")] [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
    
}
