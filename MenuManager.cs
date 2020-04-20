using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioSource audio;
    public GameObject game;
    public GameObject menu;
    private bool muted = false;
    public Texture2D cursorArrow;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void onStartClick()
    {
        game.SetActive(true);
        menu.SetActive(false);
    }
    public void OnMuteClick()
    {
        if (audio.isPlaying)
        {
            audio.Pause();
        }
        else
        {
            audio.Play();
        }
    }
}
