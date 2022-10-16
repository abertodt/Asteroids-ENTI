using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _deathParticles;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Animator _animator;
    private float _vertical;
    private float _horizontal;

    // Start is called before the first frame update
    void Start()
    {
        _movementSpeed = 20;
        _rotationSpeed = 100;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_vertical > 0)
        {
            _rigidBody.AddForce(transform.up * _vertical * _movementSpeed * Time.deltaTime);
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
       
        transform.eulerAngles += new Vector3(0, 0, -_horizontal) * Time.deltaTime * _rotationSpeed;
        
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletToDestroy = Instantiate(_bullet, transform.position, transform.rotation);
            Destroy(bulletToDestroy, 2.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet" || collision.tag == "Enemy")
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.instance.lifes--;
        GameObject particles = Instantiate(_deathParticles, transform.position, transform.rotation);
        Destroy(particles, 2f);

        if(GameManager.instance.lifes > 0)
        {
            transform.position = new Vector3(0, 0);
            _rigidBody.velocity = new Vector3(0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
