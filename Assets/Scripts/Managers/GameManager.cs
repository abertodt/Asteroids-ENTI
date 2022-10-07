using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _game;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _player;
    public static GameManager instance;

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
        SpawnPlayer();
        _timer.StartTimer();
        this.lifes = 3;
        this.points = 0;
    }

    private void Update()
    {
        if(this.lifes == 0)
        {
            _timer.StopTimer();
        }
    }

    private void SpawnPlayer()
    {
        Instantiate(_player, _player.transform.position, _player.transform.rotation);
    }
}
