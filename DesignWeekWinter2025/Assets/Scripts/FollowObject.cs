using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform followedObject; 
    public Vector3 objectOffset;
    private Rigidbody cameraRb;
    Camera mainCamera; 

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>(); 
        cameraRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = followedObject.position + objectOffset;


    }
}
