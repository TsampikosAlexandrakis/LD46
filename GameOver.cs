using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject endPanel;
    public GameObject game;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            endPanel.SetActive(true);
            game.SetActive(false);
        }
    }

    public void OnExitClick()
    {
        SceneManager.LoadScene(0);
    }
}
