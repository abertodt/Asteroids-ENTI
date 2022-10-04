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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _points.text = GameManager.instance.points.ToString();
        _lifes.text = GameManager.instance.lifes.ToString();
        _time.text = Time.time.ToString("00.00");


        if (GameManager.instance.lifes == 0)
        {
            _gameOver.gameObject.SetActive(true);
        }
    }
}
