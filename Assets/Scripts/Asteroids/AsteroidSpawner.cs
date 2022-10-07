using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;
    private int _minAsteroids, _maxAsteroids;
    private float _maxX = 9;
    private float _maxY = 5;
    public int asteroidsAlive;

    // Start is called before the first frame update
    void Start()
    {
        GenerateAsteroids();
    }

    private void Update()
    {
        if(asteroidsAlive <= 0)
        {
            asteroidsAlive = 0;
            GenerateAsteroids();
        }
    }

    private void GenerateAsteroids()
    {
        _minAsteroids = 2;
        _maxAsteroids = 10;

        int asteroids_number = Random.Range(_minAsteroids, _maxAsteroids);

        for (int i = 0; i < asteroids_number; i++)
        {
            Vector3 position = new Vector3(Random.Range(-_maxX, _maxX), Random.Range(-_maxY, _maxY));

            if(Vector3.Distance(position, new Vector3(0,0,0)) > 3)
            {
                GameObject asteroide = Instantiate(_asteroid, position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                asteroide.GetComponent<AsteroidController>().spawner = this;
            }     
        }
    }
}
