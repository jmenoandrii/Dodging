using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy
{
    [SerializeField]
    private Vector3 placeDestination;

    public void Initialization(Vector3 destination, Transform transformPlayer)
    {
        placeDestination = destination;
        player = transformPlayer;
    }

    private void Update()
    {
        if (!inDestination)
        {
            DirectionToDestination(placeDestination);
        }
        else
        {
            enemyParticles.Stop();
            LookAt(player.position, transform);
            if (!startShoot)
            {
                StartCoroutine(Shoot());
                startShoot = true;
            }
        }
    }
}
