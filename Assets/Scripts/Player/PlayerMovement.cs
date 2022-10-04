using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movement_speed;
    [SerializeField] private float rotation_speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject deathParticles;
    private float vertical;
    private float horizontal;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movement_speed = 20;
        rotation_speed = 100;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
        {
            rb.AddForce(transform.up * vertical * movement_speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
            //transform.position = transform.position + transform.up * vertical * Time.deltaTime * movement_speed;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
       
        transform.eulerAngles += new Vector3(0, 0, -horizontal) * Time.deltaTime * rotation_speed;
        
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bulletToDestroy = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(bulletToDestroy, 2.5f);
        }
      
    }

    public void Die()
    {
        GameManager.instance.lifes--;
        GameObject particles = Instantiate(deathParticles, transform.position, transform.rotation);
        Destroy(particles, 2f);

        if(GameManager.instance.lifes > 0)
        {
            transform.position = new Vector3(0, 0);
            rb.velocity = new Vector3(0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
