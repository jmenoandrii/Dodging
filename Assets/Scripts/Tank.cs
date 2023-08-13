using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    [SerializeField]
    private List<Vector3> placeDestinations;
    [SerializeField]
    private Transform tower;

    private int indexDestination = 0;

    public void Initialization(List<Vector3> destinations, Transform transformPlayer)
    {
        placeDestinations = destinations;
        player = transformPlayer;
    }

    private int ChooseDestination()
    {
        int i = Random.Range(0, placeDestinations.Count);

        if (i == indexDestination)
            i = ChooseDestination();

        return i;
    }

    private void Update()
    {
        LookAt(player.position, tower);
        if (!inDestination)
        {
            DirectionToDestination(placeDestinations[indexDestination]);
        }
        else
        {
            indexDestination = ChooseDestination();

            inDestination = false;

            if (!startShoot)
            {
                StartCoroutine(Shoot());
                startShoot = true;
            }
        }
    }
}
