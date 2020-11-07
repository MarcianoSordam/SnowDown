using System.Collections;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    public void SelfDestruct()
    {
        GameObject cubesplotion = Instantiate (explosionEffect, transform.position, transform.rotation);
        Destroy(cubesplotion,5);
        Destroy(gameObject);
    }
}
