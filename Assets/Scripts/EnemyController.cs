using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
    public float shotTime;
    public float maxHealth;
    public Gun gun;

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
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        gun.Direction = toPlayer;
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
