using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawner : MonoBehaviour
{
    private float[] _posibleX =  {10, -10};
    private Vector3 _spawnPoint;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _enemyShip;
    private float _randomX;

    private float _timeToRespawn = 60f;

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.points >= 1000 && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            _timeToRespawn -= Time.deltaTime;
            Debug.Log(_timeToRespawn);
        }

        if (_timeToRespawn <= 0 && GameObject.FindGameObjectWithTag("Enemy") == null )
        {
            Spawn();
        }
    }

    private void CalculateSpawnPoint()
    {
        int randomIndex = Random.Range(0, 2);
        _randomX = _posibleX[randomIndex];
        int randomY = Random.Range(-4, 4);
        _spawnPoint = new Vector3(_randomX, randomY);
    }

    private void Spawn()
    {
        _timeToRespawn = 60f;
        CalculateSpawnPoint();
        if(_randomX == -10)
        {
            _enemyShip.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            _enemyShip.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        Instantiate(_enemyShip, _spawnPoint, _enemyShip.transform.rotation);
    }
}
