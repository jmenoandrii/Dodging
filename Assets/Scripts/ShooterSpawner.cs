using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawner : EnemySpawner
{
    public override IEnumerator Spawn()
    {
        yield return new WaitForSeconds(firstDelay);
        while (!StateGame.singleton.GameEnded())
        {
            int variant = Mathf.RoundToInt(Random.Range(0, pointsSpawn.Length));

            Shooter enemy = Instantiate(enemyPrefab, pointsSpawn[variant].position, pointsSpawn[variant].rotation).GetComponent<Shooter>();
            enemy.Initialization(new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY)), player);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
