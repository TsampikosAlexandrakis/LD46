using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public static int scoreAdd;
    public static bool kill = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            kill = true;
            scoreAdd = scoreAdd + 1;
        }
    }
}
