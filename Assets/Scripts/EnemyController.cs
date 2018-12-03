using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
    public float shotTime;
    public float maxHealth;
    public Gun gun;
    public GunItem gunItem;

    Timer shotTimer;
    Attackable attackable;
    GameObject player;

	// Use this for initialization
	void Start () 
    {
        shotTimer = new Timer(shotTime);
        attackable = GetComponent<Attackable>();
        attackable.maxHealth = maxHealth;
        attackable.health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        gun.InitializeGun(gunItem);
        gun.maxBullets = -1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        shotTimer.update(Shoot);
        UpdateGunPosition();
	}

    void UpdateGunPosition()
    {
        // Gun rotates around axis
        Vector3 toPlayer = player.transform.position - transform.position;
        toPlayer.z = 0;
        toPlayer.Normalize();
        gun.transform.position = transform.position + (0.75f * toPlayer);
        float rot_z = Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        gun.Direction = toPlayer;
        gun.GetComponent<SpriteRenderer>().flipY = player.transform.position.x > transform.position.x;
    }

    void Shoot ()
    {
        gun.MousePressed();
    }

    public void destroyed ()
    {
        Destroy(gameObject);
    }
}
