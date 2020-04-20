using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spr;
    public Transform target;
    public Rigidbody2D enemy;
    public Animator anim;
    public GameObject Endpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        if (angle > 0f)
        {
            spr.flipX = true;
            
        }
        else
        {
            spr.flipX = false;
            
        }
        if (enemy.velocity.x > 0 || enemy.velocity.y > 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else if (enemy.velocity.x < 0 || enemy.velocity.y < 0)
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("LookingRight", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("LookingRight", false);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision);    
        }
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(this.gameObject);
            Endpanel.SetActive(true);
        }
    }
}
