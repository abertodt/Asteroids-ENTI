using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _game;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _player;
    public static GameManager instance;
    private GameObject[] _asteroids;
    [SerializeField] private AsteroidSpawner _spawner;
    private GameObject _enemyShip;
    private GameObject _healthPack;

    public int lifes = 3;
    public int points = 0;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        SpawnPlayer();
        _game.SetActive(true);
    }

    public void RestartGame()
    {
        _asteroids = GameObject.FindGameObjectsWithTag("Destroyable");
        foreach (GameObject asteroid in _asteroids) Destroy(asteroid);
        _spawner.AsteroidsAlive = 0;
        _enemyShip = GameObject.FindGameObjectWithTag("Enemy");
        _healthPack = GameObject.FindGameObjectWithTag("HealthPack");
        Destroy(_enemyShip);
        Destroy(_healthPack);
        SpawnPlayer();
        _game.SetActive(true);
        _timer.StartTimer();
        this.lifes = 3;
        this.points = 0;
    }

    private void Update()
    {
        if(this.lifes == 0)
        {
            _timer.StopTimer();
            _game.SetActive(false);
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(_player, _player.transform.position, _player.transform.rotation);
    }
}
