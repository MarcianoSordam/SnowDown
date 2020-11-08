using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delay = 2;
    bool isShooting;
    void Update()
    {
        if (true && !isShooting)//raycast hit player or wall & if not shooting
        {
            StartCoroutine(Shoot());
            isShooting = true;
        }
    }

    IEnumerator Shoot()
    {
        //shoot bullet
        
        yield return new WaitForSeconds(delay);
        isShooting = false;

    }
}
