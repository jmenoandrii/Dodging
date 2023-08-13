using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform playerTexture;
    [SerializeField]
    private Transform direction;
    [SerializeField]
    private ParticleSystem playerParticle;

    private Vector3 moveDirection;

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, inputY);

        if (moveDirection != Vector3.zero)
        {
            playerParticle.Play();
            direction.localPosition = moveDirection;
            LookAt(direction.position);
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }

    private void LookAt(Vector3 pos)
    {
        Vector3 dir = pos - playerTexture.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        playerTexture.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void TakeDamage()
    {
        Stats.singleton.Lives -= 1;
        if (Stats.singleton.Lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
