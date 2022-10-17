using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    private float _speed = 200f;
    private float _waitTime = 2f;
    private string _collisionTag = "Destroyable";

    private void OnEnable()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(transform.up * _speed);
        StartCoroutine(WaitToDisable(_waitTime));
    }

    IEnumerator WaitToDisable(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _collisionTag && gameObject.tag == "Bullet")
        {
            collision.GetComponent<AsteroidController>().Die();
            gameObject.SetActive(false);
        }
    }

    
}
