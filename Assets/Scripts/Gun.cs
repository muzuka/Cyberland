using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    public float timeToShoot;
    public float bulletOffset;
    public GameObject bullet;
    Camera camera;
    Timer shootTimer;

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
        camera = Camera.main;
        shootTimer = new Timer(timeToShoot);
    }
	
	// Update is called once per frame
	void Update () 
    {

    }

    public void MousePressed()
    {
        shootTimer.reset();
        Shoot();
    }

    public void MouseHeld()
    {
        shootTimer.update(Shoot);
    }

    void Shoot () 
    {
        GameObject newBullet = Instantiate(bullet, transform.position + (bulletOffset * direction), Quaternion.identity);
        newBullet.GetComponent<Bullet>().Direction = direction;
    }
}
