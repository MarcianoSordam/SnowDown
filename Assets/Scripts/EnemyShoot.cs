using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float delay = 2;
    [SerializeField] float range = 10;
    [SerializeField] float CarrotVelocity = 10;
    [SerializeField] GameObject carrot;
    [SerializeField] GameObject ShootingPoint;

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
        Debug.Log("Shoot");
        //shoot bullet
        GameObject projectile = (GameObject)Instantiate(carrot, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.forward * CarrotVelocity;

        yield return new WaitForSeconds(delay);
        isShooting = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(ShootingPoint.transform.position, .1f);
    }
}
