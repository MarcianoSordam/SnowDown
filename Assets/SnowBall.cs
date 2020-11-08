using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    SphereCollider colliderComponent;
    [SerializeField] GameObject explosion;
    bool SumoningSickness = true;
    [SerializeField] float lifetime = 30;

    [SerializeField] bool destroy = false;

    void Start()
    {
        StartCoroutine(RemoveSumoningSickness());
    }
    public void turnOnDestroy()
    {
        destroy = true;
        Debug.Log("Destroy is on");
    }

    public void TurnOffDestroy()
    {
        destroy = false;
        Debug.Log("Destroy is off");

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "hands" && !SumoningSickness)
        {
            DestroyThis();
        }
    }

    public void DestroyThis()
    {
        if (destroy)
        {
            //spawn effect
            GameObject explosionEffect = Instantiate(explosion, transform.position, transform.rotation);
            //destroy this
            Destroy(explosionEffect, 2);
            Destroy(gameObject);
        }
    }

    IEnumerator RemoveSumoningSickness()
    {
        yield return new WaitForSeconds(.5f);
        SumoningSickness = false;
        yield return new WaitForSeconds(lifetime);
        DestroyThis();
    }
}
