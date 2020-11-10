using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingSnowball : MonoBehaviour
{
    [SerializeField] float rollSpeed = 10f;
    [SerializeField] float growSpeed = 1f;
    [SerializeField] float maxSize = 5f;
    [SerializeField] float damage = 1;
    [SerializeField] float destroyTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void FixedUpdate()
    {
        // move the ball forward
        transform.Translate(Vector3.forward * rollSpeed * Time.deltaTime);
        
        // this method doesn't work
        //rb.velocity = transform.forward * rollSpeed;

        // increase size and damage of the ball until maximum size is reached
        if(maxSize > transform.localScale.x) {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime ;
            damage++;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessage("TakeDamage",damage);

        
        if (other.gameObject.layer != 13) {
            //todo snowball explode animation
            Destroy(gameObject);
        }
    }
}
