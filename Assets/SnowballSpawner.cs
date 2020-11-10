using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    [SerializeField] GameObject snowBallModel;
    [SerializeField] float delay;
     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        Instantiate(snowBallModel, transform.position, transform.rotation);
        yield return new WaitForSeconds(delay);
        StartCoroutine(Spawner());
    }
}
