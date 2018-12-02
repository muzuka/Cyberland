using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunItem : ScriptableObject 
{
    public Sprite icon;
    public Sprite texture;
    public GameObject bullet;
    public int maxBullets;
    public float timeToReload;
    public float timeToShoot;
}
