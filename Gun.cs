using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject gun;
    public Camera cam;
    Vector2 mousePos;
    public AudioSource audio;
    public AudioClip shoot;
    Rigidbody2D gunRb;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        gunRb = gun.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gunRb.position = player.position;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        gunRb.WakeUp();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Fire = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            Fire.GetComponent<Rigidbody2D>().AddForce(gun.transform.up * 500f);
            audio.PlayOneShot(shoot);
        }
    }
    void FixedUpdate()
    {

        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        gunRb.rotation = angle;
    }
}
