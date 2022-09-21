using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public float vertical, horizontal;

    // Start is called before the first frame update
    void Start()
    {
        vertical = 5;
        horizontal = 9;
    }

    // Update is called once per frame
    void Update()
    {
        //cambia la posicion cuando se sale por arriba
        if (transform.position.y > vertical)
        {
            transform.position = new Vector3(transform.position.x, -vertical, transform.position.z);
        }

        //cambia la posicion cuando se sale por abajo
        if (transform.position.y < -vertical)
        {
            transform.position = new Vector3(transform.position.x, vertical, transform.position.z);
        }

        //cambia la posicion cuando se sale por la derecha
        if (transform.position.x > horizontal)
        {
            transform.position = new Vector3(-horizontal, transform.position.y, transform.position.z);
        }

        //cambia la posicion cuando se sale por la izquierda
        if (transform.position.x < -horizontal)
        {
            transform.position = new Vector3(horizontal, transform.position.y, transform.position.z);
        }
    }
}
