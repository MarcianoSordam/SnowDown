using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    [SerializeField] float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    public void SpawnCubesFunction()
    {
        StartCoroutine(SpawnCubes());
    }

    public IEnumerator SpawnCubes()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            GameObject cubeClone = Instantiate(cubes[i], transform.position, transform.rotation);
        }
    }

}
