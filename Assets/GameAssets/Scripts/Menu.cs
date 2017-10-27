using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    bool _mute;
    public GameObject volumeSprite;

    private void Awake()
    {
    }

    void Start () {
        volume(false);
    }

    // Update is called once per frame
    void Update () {
	}

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void volume(bool change)
    {
        _mute = (PlayerPrefs.GetString("IsMute") != null && PlayerPrefs.GetString("IsMute") != "") ? Convert.ToBoolean(PlayerPrefs.GetString("IsMute")) : false;
        if (change) { _mute = !_mute; }
        PlayerPrefs.SetString("IsMute", _mute.ToString());
        if (_mute == true)
        {
            AudioListener.pause = true;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.pause = false;
            AudioListener.volume = 1;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();

        }
       
        volumeSprite.SetActive(!_mute);
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        GameManager.instance.gameState = pause ? GameManager.GameState.pause : GameManager.GameState.play;
        if(!pause) StartCoroutine(Movement.instance.NextStep());
    }
}
