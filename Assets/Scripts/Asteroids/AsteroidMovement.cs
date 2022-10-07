using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    private float _x = 0;
    private float _y = 0;

    // Start is called before the first frame update
    void Start()
    {
        _minSpeed = 1000.0f;
        _maxSpeed = 5000.0f;
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        while(_x == 0 && _y == 0)
        {
            _x = Random.Range(-1, 1);
            _y = Random.Range(-1, 1);
        }

        Vector2 direction = new Vector2(_x, _y);

        float speed = Random.Range(_minSpeed, _maxSpeed);
        _rigidBody.AddForce(direction * speed * Time.deltaTime);

        int random_sprite = Random.Range(0, _spriteList.Count);
        _spriteRenderer.sprite = _spriteList[random_sprite];
    }

}
