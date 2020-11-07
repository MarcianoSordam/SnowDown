using System.Collections;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    void OnCollisionEnter(Collision colider)
    {
        if (colider.gameObject.tag == "Hands")
        {
            Debug.Log("collided");
            for (int i = 0; i<spawnPoints.Length; i++)
            {
                //send message to spawners
                spawnPoints[i].SendMessage("SpawnCube");
            }
        }
    }
}
