using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] float delay = 2;
    [SerializeField] float range = 15;
    [SerializeField] float CarrotVelocity = 10;
    [SerializeField] GameObject carrot;
    [SerializeField] GameObject ShootingPoint;
    [SerializeField] float lifetime = 5; // lifetime of carrot bullets

    bool isShooting;

    void Update()
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range) && !isShooting)
        {
            Debug.Log(hit.collider.gameObject.name);
            StartCoroutine(Shoot());
            isShooting = true;
        }
    }

    IEnumerator Shoot()
    {
        //Debug.Log("Shoot");
        //shoot bullet
        GameObject projectile = (GameObject)Instantiate(carrot, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
        Destroy(projectile, lifetime);
        //projectile.GetComponent<Rigidbody>().velocity = Vector3.forward * CarrotVelocity;

        yield return new WaitForSeconds(delay);
        isShooting = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(ShootingPoint.transform.position, .1f);
    }
}
