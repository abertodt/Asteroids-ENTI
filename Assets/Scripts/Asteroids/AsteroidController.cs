using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public AsteroidSpawner spawner;

    private void Start()
    {
        spawner.asteroidsAlive++;
    }

    public void Die()
    {
        if(transform.localScale.x > 0.25f){
            CreateSplit(gameObject);
            CreateSplit(gameObject);
            Destroy(gameObject);
            GameManager.instance.points = GameManager.instance.points + 100;
        }

        spawner.asteroidsAlive--;
        Destroy(gameObject);
    }

    private void CreateSplit(GameObject gameobject)
    {
        GameObject half = Instantiate(gameObject, gameobject.transform.position, gameobject.transform.rotation);
        half.transform.localScale = half.transform.localScale * 0.5f;
        half.GetComponent<AsteroidController>().spawner = spawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().Die();
        }
    }
}
