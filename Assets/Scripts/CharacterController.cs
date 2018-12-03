using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour 
{
    public List<Gun> gunList;
    public float maxHealth;
    public float speed;

    Attackable attackable;
    Rigidbody2D rigidbody;
    Camera camera;
    int gunIndex;

    // Use this for initialization
    void Start () 
    {
        InitializeGuns();
        attackable = GetComponent<Attackable>();
        attackable.maxHealth = maxHealth;
        attackable.health = maxHealth;
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
        gunIndex = 0;
        EquipWeapon(gunIndex);
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
            gunList[gunIndex].MousePressed();
        }
        if (Input.GetMouseButton(0))
        {
            gunList[gunIndex].MouseHeld();
        }
        else 
        {
            gunList[gunIndex].MouseUp();
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            gunIndex++;
            if (gunIndex >= gunList.Count)
            {
                gunIndex = 0;
            }
            EquipWeapon(gunIndex);
        }

        UpdateGunPosition();
    }

    void UpdateGunPosition ()
    {
        // Gun rotates around axis
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 toMouse = mousePosition - transform.position;
        toMouse.z = 0;
        toMouse.Normalize();
        gunList[gunIndex].transform.position = transform.position + (0.75f * toMouse);
        float rot_z = Mathf.Atan2(toMouse.y, toMouse.x) * Mathf.Rad2Deg;
        gunList[gunIndex].transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        gunList[gunIndex].Direction = toMouse;
        gunList[gunIndex].GetComponent<SpriteRenderer>().flipY = mousePosition.x < transform.position.x;
    }

    void InitializeGuns ()
    {
        // gun1
        if (SelectedGuns.gun1)
        {
            gunList[0].InitializeGun(SelectedGuns.gun1);
        }
        // gun2
        if (SelectedGuns.gun2)
        {
            gunList[1].InitializeGun(SelectedGuns.gun2);
        }
        // gun3
        if (SelectedGuns.gun3)
        {
            gunList[2].InitializeGun(SelectedGuns.gun3);
        }
    }

    void EquipWeapon(int index)
    {
        for (int i = 0; i < gunList.Count; i++)
        {
            gunList[i].gameObject.SetActive(i == index);
        }
    }

    public void destroyed ()
    {
        GameController.instance.OpenMenu("Game Over");
    }

    public Gun GetEquippedGun ()
    {
        return gunList[gunIndex];
    }
}
