using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
    public float timeToDestroy;

    public float damage { get; set; }

    Timer destroyTimer;

    void Start ()
    {
        destroyTimer = new Timer(timeToDestroy);
    }

    void Update ()
    {
        destroyTimer.update(Destroyed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attackable>())
        {
            collision.GetComponent<Attackable>().attacked(damage);
        }
    }

    void Destroyed ()
    {
        Destroy(gameObject);
    }
}
