using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemies;
        public float timeBetweenSpawns = 0.5f;
        public float timeBetweenWaves = 1f;
        public int enemiesCount;
    }

    [Header("Wave Settings")]
    public Wave[] waves;
    public Transform[] spawnPoint;
    public int currentWave = 0;
    [SerializeField] bool countDownBegin;
    [SerializeField] private float countDown;


    private void Start()
    {
        countDownBegin = true;
        for(int i = 0;i< waves.Length;i++)
        {
            waves[i].enemiesCount = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        if(currentWave >= waves.Length)
        {
            Debug.Log("All Waves Completed");
            return;
        }

        if(countDownBegin == true)
        {
            countDown -= Time.deltaTime;
        }

        if(countDown <= 0f)
        {
            countDownBegin = false;
            countDown = waves[currentWave].timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWave].enemiesCount == 0)
        {
            countDownBegin = true;
            currentWave++;
        }
    }


    IEnumerator SpawnWave()
    {

    }
}
