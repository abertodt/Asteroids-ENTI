using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private GameObject _deathParticles;
    [SerializeField] private GameObject _bullet;

    private int _hp = 100;
    private float _speed = 2f;
    private float _timeToShoot = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Move();

        if(_timeToShoot > 0)
        {
            _timeToShoot -= Time.deltaTime;
        }
        else
        {
            Shoot();
        }

        if(_hp == 0)
        {
            Die();
        }
        
    }

    private void Move()
    {
        transform.position += transform.up * Time.deltaTime * _speed;
    }

    private void Die()
    {
        GameObject particles = Instantiate(_deathParticles, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(gameObject);
    }

    private void Shoot()
    {
        _timeToShoot = 0.5f;
        Quaternion randomAngle = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        GameObject bulletToDestroy = Instantiate(_bullet, transform.position, randomAngle);
        Destroy(bulletToDestroy, 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _hp = _hp - 20;
    }
}