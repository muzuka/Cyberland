using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBlast : Projectile 
{
    public float timePerHit;

    Timer damageTimer;

    List<Attackable> targets;

    public override void Start ()
    {
        base.Start();
        targets = new List<Attackable>();
        damageTimer = new Timer(timePerHit);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attackable>())
        {
            targets.Add(collision.GetComponent<Attackable>());
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        damageTimer.update(Damage);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Attackable>())
        {
            targets.Remove(collision.GetComponent<Attackable>());
        }
    }

    void Damage () 
    {
        foreach (Attackable target in targets)
        {
            target.attacked(damage);
        }
    }
}
