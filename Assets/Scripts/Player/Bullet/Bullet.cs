using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed = 200f;
    private string collisionTag = "Destroyable";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == collisionTag)
        {
            collision.GetComponent<AsteroidController>().Die();
            Destroy(gameObject);
        }
    }

    
}
