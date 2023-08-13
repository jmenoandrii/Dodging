using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeToDestroy;
    [SerializeField]
    private float timeToInclusionOfCollider;
    [SerializeField]
    private GameObject explosionEffect;
    private Transform player;
    private Collider2D collider2D;

    public void Instantiate(Transform transformPlayer)
    {
        player = transformPlayer;
    }

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        Invoke(nameof(Die), timeToDestroy);
        StartCoroutine(InclusionOfCollider());
    }

    private void Die()
    {
        Destroy(Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation), 5);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private IEnumerator InclusionOfCollider()
    {
        yield return new WaitForSeconds(timeToInclusionOfCollider);
        collider2D.enabled = true;
    }
}
