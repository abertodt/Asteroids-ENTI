using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    private float _speed = 200f;
    private string _collisionTag = "Destroyable";

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(transform.up * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _collisionTag && gameObject.tag == "Bullet")
        {
            collision.GetComponent<AsteroidController>().Die();
            Destroy(gameObject);
        }
    }

    
}
