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

    public void InitializeGun (GunItem item)
    {
        GetComponent<SpriteRenderer>().sprite = item.icon;
        bullet = item.bullet;
        timeToShoot = item.timeToShoot;
        timeToReload = item.timeToReload;
        maxBullets = item.maxBullets;
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
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            newBullet.GetComponent<Projectile>().Direction = direction;
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
