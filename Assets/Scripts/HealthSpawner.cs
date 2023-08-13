using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject healthPrefab;
    [SerializeField]
    private float maxX, maxY;
    [SerializeField]
    private float minX, minY;
    [SerializeField]
    private float spawnDelay, firstDelay;
    [SerializeField]
    private int minTime;
    [SerializeField]
    private bool startSpawn = false;

    private void Update()
    {
        if (!startSpawn && Stats.singleton.Times >= minTime)
        {
            StartCoroutine(Spawn());
            startSpawn = true;
        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(firstDelay);
        while (!StateGame.singleton.GameEnded())
        {
            Instantiate(healthPrefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY)), healthPrefab.transform.rotation);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
