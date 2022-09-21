using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private int min_asteroids, max_asteroids;
    private float max_x = 9;
    private float max_y = 5;

    // Start is called before the first frame update
    void Start()
    {
        min_asteroids = 2;
        max_asteroids = 10;

        int asteroids_number = Random.Range(min_asteroids, max_asteroids);
        for(int i = 0; i < asteroids_number; i++)
        {
            Vector3 position = new Vector3(Random.Range(-max_x, max_x), Random.Range(-max_y, max_y));
            Instantiate(asteroid, position, Quaternion.Euler(new Vector3(0,0,Random.Range(0, 360))));
        }
        
    }
}