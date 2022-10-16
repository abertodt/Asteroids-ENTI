using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _healthPack;
    private float _maxX = 9;
    private float _maxY = 5;
    private float _timeToSpawn = 60f;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(Random.Range(-_maxX, _maxX), Random.Range(-_maxY, _maxY));

        if (!GameObject.FindGameObjectWithTag("HealthPack") && GameManager.instance.points >= 1000)
        {
            _timeToSpawn -= Time.deltaTime;
        }

        if (_timeToSpawn <= 0)
        {
            Instantiate(_healthPack, position, _healthPack.transform.rotation);
            _timeToSpawn = 60f;
        }
    }
}
