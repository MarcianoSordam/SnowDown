using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLever : MonoBehaviour
{
    [SerializeField] CubesSpawnPoint spawnPoint;
    [SerializeField] float triggerPoint;

    bool prevState = false;

    void Update()
    {
        if (transform.rotation.x < triggerPoint)
        {
            if (prevState == false)
            {
                prevState = true;
                Debug.Log("Lever Activated");
                spawnPoint.SpawnCubesFunction();
            }
        }
        else
        {
            prevState = false;
        }
    }
}
