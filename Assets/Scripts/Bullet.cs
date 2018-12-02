using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float damage;
    public float lifetime;
    public float speed;

    Timer timer;

    private Vector3 direction;
    public Vector3 Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value.normalized;
        }
    }

    void Start()
    {
        timer = new Timer(lifetime);
    }

    // Use this for initialization
    void Update () 
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        timer.update(DestroyThis);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Attackable>())
        {
            collision.gameObject.GetComponent<Attackable>().attacked(damage);
        }
        Destroy(gameObject);
    }

    void DestroyThis ()
    {
        Destroy(gameObject);
    }
}
