using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Projectile 
{
    public float timeToExplode;

    Timer explosionTimer;

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

    // Use this for initialization
    void Start () 
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        explosionTimer = new Timer(timeToExplode);
	}
	
	// Update is called once per frame
	void Update () 
    {
        explosionTimer.update(Explode);
	}

    void Explode ()
    {
        GetComponent<ExplodesOnTouch>().Explode();
    }
}
