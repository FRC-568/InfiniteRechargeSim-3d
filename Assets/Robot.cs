using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float speed = 1.0f;
    public bool fire = false;
    public int ammo = 0;
    Collider m_ObjectCollider;

    // Start is called before the first frame update
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
        Debug.Log("Trigger ON" + m_ObjectCollider.isTrigger);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "test" && fire == true) // this string is your newly created tag
        {
            // TODO: anything you want
            // Even you can get Bullet object
            Debug.Log("Fire the Cannons");
            GameObject B1 = collider.gameObject;


            //Fix this to stop once robot leaves trigger
            if (ammo > 0)
            {
                InvokeRepeating("FireCannons", 1.0f, 2.0f);

            }


        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "test")
        {
            CancelInvoke("FireCannons");
        }
    }
    void FireCannons()
    {
        if (m_ObjectCollider.isTrigger == true && ammo > 0)
        {
            ammo--;
            if (ammo == 0)
                CancelInvoke("FireCannons");
            Debug.Log("What a Shot, Ammo remaining " + ammo);

        }
        else
            CancelInvoke("FireCannons");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ammo < 5)
        {
            ammo = ammo + 1;
            Debug.Log("added ammo: " + ammo);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ammo == 5)
            Debug.Log("Robot Full");

        if (ammo > 0)
            fire = true;




    }
}
