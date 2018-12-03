using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float lifetime;
    public float speed;

    Timer timer;

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

    public virtual void Start()
    {
        timer = new Timer(lifetime);
    }

    // Use this for initialization
    public virtual void Update()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        timer.update(DestroyThis);
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
