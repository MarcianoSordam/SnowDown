using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delay = 2;
    [SerializeField] float range = 10;
    [SerializeField] float CarrotVelocity = 10;
    [SerializeField] GameObject carrot;
    [SerializeField] Vector3 offset;

    bool isShooting;
    
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range) && !isShooting)
        {
            StartCoroutine(Shoot());
            isShooting = true;
        }
    }

    IEnumerator Shoot()
    {
        //shoot bullet
        GameObject projectile = (GameObject)Instantiate(carrot, transform.position + offset, transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.forward * CarrotVelocity;

        yield return new WaitForSeconds(delay);
        isShooting = false;
    }
}
