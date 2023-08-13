using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform placeBullet;
    public GameObject bullet, explosionEffect;
    public ParticleSystem enemyParticles;
    public float delayBullet;
    public float speed;
    public bool inDestination = false;
    public bool startShoot = false;

    public IEnumerator Shoot()
    {
        while (!StateGame.singleton.GameEnded())
        {
            GameObject bulletPrefab = Instantiate(bullet, placeBullet.position, placeBullet.rotation);
            bulletPrefab.GetComponent<Bullet>().Instantiate(player);
            yield return new WaitForSeconds(delayBullet);
        }
    }

    public void DirectionToDestination(Vector3 place)
    {
        LookAt(place, transform);
        transform.position = Vector3.MoveTowards(transform.position, place, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, place) < 0.1)
        {
            inDestination = true;
        }
    }

    public void LookAt(Vector3 target, Transform transformParent)
    {
        Vector3 dir = target - transformParent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transformParent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Die()
    {
        Destroy(gameObject);
        Destroy(Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation), 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(collision.gameObject);
            Die();
        }
        else if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage();
            Die();
        }
        else if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            Die();
        }
    }
}
