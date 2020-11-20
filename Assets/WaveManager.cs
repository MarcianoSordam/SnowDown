using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class EnemyToSpawn {
        public GameObject enemy;
        public float spawnChange;  
    }

    private class Wave {
        public int waveLevel { get; set; }
        public float spawnRate { get; set; }
        public List<GameObject> enemys { get; set; } = new List<GameObject>(); 

        public Wave(int wavelevel, float spawnRate) { 
            this.waveLevel = waveLevel;
            this.spawnRate = spawnRate;
        }
    }

    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float waveCountDown;
    [SerializeField] int DifficulityMultiplier;
    [SerializeField] List<EnemyToSpawn> EnemysToSpawn = new List<EnemyToSpawn>();
    [SerializeField] float StartSpawnRate;
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] float enemySpawnCount;

    private int waveLevel = 0;
    private float spawnRate = 0;

    private System.Random rnd = new System.Random();
    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        waveCountDown = timeBetweenWaves;
        spawnRate = StartSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                NextWave();
            }
        } else {
            waveCountDown -= Time.deltaTime;
        }
    }

    // Creates the next wave
    void NextWave() {
        waveLevel++;
        Debug.Log("Wave " + waveLevel + "started");

        Wave wave = new Wave(waveLevel, spawnRate);

        for (int i = 0; i < enemySpawnCount; i++)
        {
            wave.enemys.Add(GetEnemyChance());
        }

        StartCoroutine(SpawnWave(wave));
    }

    // Start the wave
    IEnumerator SpawnWave(Wave wave) {
        state = SpawnState.SPAWNING;
        Debug.Log("Spawning wave...");

        for (int i = 0; i < wave.enemys.Count; i++)
        {   
            SpawnEnemy(wave.enemys[i]);
            yield return new WaitForSeconds(1f * wave.spawnRate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    // Spawn enemy on spawnpoint
    void SpawnEnemy(GameObject enemy) {
        Debug.Log("Spawning Enemy");
        Transform spawnPoint = GetRandomSpawnPoint();
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    // get random spawnpoint
    private Transform GetRandomSpawnPoint() {
        return spawnPoints[rnd.Next(0, spawnPoints.Count)];
    }

    // returns an enemy based on chance
    private GameObject GetEnemyChance() {
        double rand = rnd.NextDouble();

        for (int i = 0; i < EnemysToSpawn.Count; i++)
        {
            EnemyToSpawn enemy = EnemysToSpawn[i];

            if (rand < enemy.spawnChange) {
                return enemy.enemy;
            }

            rand -= enemy.spawnChange;
        }

        return null;
    }
}
