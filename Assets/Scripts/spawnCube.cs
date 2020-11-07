using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCube : MonoBehaviour
{
    [SerializeField] GameObject spawnThis;
    public void SpawnCube()
    {
        GameObject cube = Instantiate (spawnThis,transform.position,transform.rotation);
    }
}
