﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    public Rigidbody2D player;
    public SpriteRenderer spr;
    public float speed;
    public Camera cam;
    public Animator anim;
    public int score;
    public Text scoreTxt;

    Vector2 mousePos;
    Vector2 movement;
    

    public Texture2D cursorArrow;
    void Start()
    {
        //Cursor.SetCursor(cursorArrow,Vector2.zero,CursorMode.ForceSoftware);
        score = 0;
    }

    void Update()
    {
        if(BulletBehaviour.kill == true)
        {
            score = score + 1;
            BulletBehaviour.kill = false;
        }

        if (score > 10)
        {
            Spawner.delay = 1.5f;
        }

        if (score > 20)
        {
            Spawner.delay = 1f;
        }

        if (score > 50)
        {
            Spawner.delay = 0.5f;
        }

        scoreTxt.text ="Score: "+score;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (player.velocity.x > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else if(player.velocity.x < 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 lookDir = mousePos - player.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        
        player.velocity = movement * speed;
        

        if (lookDir.x< 0f)
        {
            spr.flipX = true;
            anim.SetBool("LookingRight", true);
        }
        else
        {
            spr.flipX = false;
            anim.SetBool("LookingRight", false);
        }
    }
}
