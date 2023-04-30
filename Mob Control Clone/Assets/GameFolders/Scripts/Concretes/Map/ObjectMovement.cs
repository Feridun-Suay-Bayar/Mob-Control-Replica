using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] Transform object_1;
    [SerializeField] Transform object_2;
    [SerializeField] float speed;

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x >= object_1.position.x)
        {
            speed *= -1;
        }
        if(transform.position.x <= object_2.position.x)
        {
            speed *= -1;
        }
    }
}
