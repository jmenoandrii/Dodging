using System.Collections;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    public float maxX, maxY;
    public float minX, minY;
    public GameObject enemyPrefab;
    public Transform[] pointsSpawn;
    public float spawnDelay, firstDelay;
    public int minTime;
    public bool startSpawn = false;

    public Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (!startSpawn && Stats.singleton.Times >= minTime)
        {
            StartCoroutine(Spawn());
            startSpawn = true;
        }
    }

    public abstract IEnumerator Spawn();
}
