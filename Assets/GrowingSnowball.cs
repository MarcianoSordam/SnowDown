using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingSnowball : MonoBehaviour
{
    [SerializeField] float rollSpeed = 10f;
    [SerializeField] float growSpeed = 1f;
    [SerializeField] float maxSize = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        // move the ball forward
        transform.Translate(Vector3.forward * rollSpeed * Time.deltaTime);
        
        // this method doesn't work
        //rb.velocity = transform.forward * rollSpeed;

        // increase size of the ball until maximum scale is reached
        if(maxSize > transform.localScale.x) {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime ;
        }
    }
}
