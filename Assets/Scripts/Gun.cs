using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    public float timeToReload;
    public float timeToShoot;
    public float bulletOffset;
    public int maxBullets;
    public GameObject bullet;
    Camera camera;
    Timer shootTimer;
    Timer reloadTimer;
    public int bullets { get; set; }

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
        bullets = maxBullets;
        camera = Camera.main;
    }

    void OnEnable()
    {
        shootTimer = new Timer(timeToShoot);
        reloadTimer = new Timer(timeToReload);
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

    public void MouseUp()
    {
        reloadTimer.update(Reload);
    }

    void Shoot () 
    {
        if (bullets != 0)
        {
            bullets--;
            GameObject newBullet = Instantiate(bullet, transform.position + (bulletOffset * direction), Quaternion.identity);
            newBullet.GetComponent<Bullet>().Direction = direction;
        }
    }

    void Reload ()
    {
        if (bullets != maxBullets)
        {
            bullets++;
        }
    }
}
