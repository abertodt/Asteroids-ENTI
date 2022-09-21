using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private float min_speed;
    [SerializeField] private float max_speed;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        min_speed = 1000.0f;
        max_speed = 5000.0f;
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        do
        {
            x = Random.Range(-1, 1);
            y = Random.Range(-1, 1);
        } while (x != 0 && y != 0);
        
        Vector2 direction = new Vector2(x, y);
        float speed = Random.Range(min_speed, max_speed);
        rigidBody.AddForce(direction * speed * Time.deltaTime);

        int random_sprite = Random.Range(0, spriteList.Count);
        spriteRenderer.sprite = spriteList[random_sprite];
    }

}
