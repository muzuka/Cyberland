using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour 
{
    public CharacterController player;
    public Attackable playerHealth;

    public Slider healthSlider;
    public GameObject ammo;
    public GameObject ammoObject;

    public static HUDController instance;

    int currentBulletCount;

	// Use this for initialization
	void Start () {
        instance = this;
        healthSlider.maxValue = player.maxHealth;
        healthSlider.value = player.maxHealth;
        currentBulletCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = playerHealth.health;
        UpdateBullets();
	}

    void UpdateBullets ()
    {
        int targetBulletCount = player.GetEquippedGun().bullets;
        if (currentBulletCount > targetBulletCount)
        {
            int diff = currentBulletCount - targetBulletCount;
            for (int i = 0; i < diff; i++)
            {
                RemoveBullet();
                currentBulletCount--;
            }
        }
        else if (currentBulletCount < targetBulletCount)
        {
            int diff = targetBulletCount - currentBulletCount;
            for (int i = 0; i < diff; i++)
            {
                AddBullet();
                currentBulletCount++;
            }
        }
    }

    public void RemoveBullet()
    {
        Image toDelete = ammo.GetComponentInChildren<Image>();
        if (toDelete != null)
        {
            Destroy(ammo.GetComponentInChildren<Image>().gameObject);
        }
    }

    public void AddBullet()
    {
        Instantiate(ammoObject, ammo.transform);
    }
}
