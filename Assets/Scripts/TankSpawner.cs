using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : EnemySpawner
{
    public override IEnumerator Spawn()
    {
        yield return new WaitForSeconds(firstDelay);
        while (!StateGame.singleton.GameEnded())
        {
            int variant = Mathf.RoundToInt(Random.Range(0, pointsSpawn.Length));

            Tank enemy = Instantiate(enemyPrefab, pointsSpawn[variant].position, pointsSpawn[variant].rotation).GetComponent<Tank>();

            List<Vector3> posEnemy = new List<Vector3>();

            for (int i = 0; i < 2; i++)
            {
                posEnemy.Add(new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY)));
            }

            enemy.Initialization(posEnemy, player);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
