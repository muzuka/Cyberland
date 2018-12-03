using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodesOnTouch : MonoBehaviour 
{
    public GameObject explosion;
    public float damage;

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity).GetComponent<Explosion>().damage = damage;
        Destroy(gameObject);
    }
}
