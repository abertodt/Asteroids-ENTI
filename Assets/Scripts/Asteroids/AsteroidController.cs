using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public void Die()
    {
        CreateSplit(gameObject);
        CreateSplit(gameObject);
        Destroy(gameObject); 
    }

    private void CreateSplit(GameObject gameobject)
    {
        GameObject half = Instantiate(gameObject, gameobject.transform.position, gameobject.transform.rotation);
        half.transform.localScale = half.transform.localScale * 0.5f;
    }
}
