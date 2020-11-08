using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    SphereCollider colliderComponent;
    [SerializeField] GameObject explosion;
    bool SumoningSickness = true;
    [SerializeField] float lifetime = 30;
    public double Damage = 1;

    bool destroy = false;

    void Start()
    {
        StartCoroutine(RemoveSumoningSickness());
    }
    public void turnOnDestroy()
    {
        destroy = true;
    }

    public void TurnOffDestroy()
    {
        destroy = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "hands" && !SumoningSickness)
        {
            DestroyThis();
        } else if (other.gameObject.tag == "enemy") {
            EnemyController ec = other.transform.GetComponent<EnemyController>();
            ec.TakeDamage(Damage);
            DestroyThis();
        }
    }

    public void DestroyThis()
    {
        //spawn effect
        GameObject explosionEffect = Instantiate(explosion, transform.position, transform.rotation);
        //destroy this
        Destroy(explosionEffect, 2);
        Destroy(gameObject);
    }

    IEnumerator RemoveSumoningSickness()
    {
        yield return new WaitForSeconds(.5f);
        SumoningSickness = false;
        yield return new WaitForSeconds(lifetime);
        DestroyThis();
    }
}
