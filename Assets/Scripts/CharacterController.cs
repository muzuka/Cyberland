using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour 
{
    public Slider healthSlider; 
    public Gun gun;
    public float maxHealth;
    public float speed;

    Attackable attackable;
    Rigidbody2D rigidbody;
    Camera camera;


    // Use this for initialization
    void Start () 
    {
        attackable = GetComponent<Attackable>();
        attackable.maxHealth = maxHealth;
        attackable.health = maxHealth;
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
        healthSlider.maxValue = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0;
        bool down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0;
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
        bool mouseDown = Input.GetMouseButtonDown(0);

        if (up)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed);
            //transform.Translate(new Vector2(0f, speed * Time.deltaTime));
        }
        else if (down)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -speed);
            //transform.Translate(new Vector2(0f, -speed * Time.deltaTime));
        }
        else
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
        }

        if (right)
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            //transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        }
        else if (left)
        {
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            //transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.MousePressed();
        }
        if (Input.GetMouseButton(0))
        {
            gun.MouseHeld();
        }
        UpdateGunPosition();
        healthSlider.value = attackable.health;
    }

    void UpdateGunPosition()
    {
        // Gun rotates around axis
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 toMouse = mousePosition - transform.position;
        toMouse.z = 0;
        toMouse.Normalize();
        gun.transform.position = transform.position + (0.75f * toMouse);
        float rot_z = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        gun.Direction = toMouse;
    }

    public void destroyed()
    {
        GameController.instance.OpenMenu("Game Over");
    }
}
