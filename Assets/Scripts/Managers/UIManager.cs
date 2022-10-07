using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _points;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _lifes;
    [SerializeField] private TextMeshProUGUI _gameOver;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private Timer _timer;

    // Update is called once per frame
    void Update()
    {
        _points.text = GameManager.instance.points.ToString();
        _lifes.text = GameManager.instance.lifes.ToString();
        _time.text = _timer.GetTime();
                

        if (GameManager.instance.lifes == 0)
        {
            _gameOver.gameObject.SetActive(true);
            _restartButton.SetActive(true);
            _time.text = _timer.GetTime();
        }
    }

    public void StartGame()
    {
        _startButton.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void RestartGame()
    {
        _restartButton.SetActive(false);
        _gameOver.gameObject.SetActive(false);
        GameManager.instance.RestartGame();
    }
}
