using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{

    public Transform shipRotation;
    public float rotationSpeed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation != shipRotation.rotation)
        {
            
            transform.rotation = Quaternion.Lerp(transform.rotation, shipRotation.rotation, rotationSpeed * Time.deltaTime); 

        }
    }
}
