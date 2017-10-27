using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameState { menu, play, gameover,pause };
    public GameObject snakePart;
    public List<GameObject> snakeParts = new List<GameObject>();
    public static GameManager instance;
    public GameObject pauseButton;
    RaycastHit hit;
    public GameObject gameOverMenu;

    public GameState gameState = GameState.play;

    public AudioClip eating,die;

    private void Awake()
    {
        instance = this;
    }
    void Start () {
        
        Movement.instance.StartGame();
    }

    void Update () {

        if (gameState == GameState.play)
        {
            if (Physics.Raycast(snakeParts[0].transform.position, snakeParts[0].transform.right, out hit, 0.5f))
            {
                if (hit.collider.name.Contains("Part") || hit.collider.name.Contains("wall") || hit.collider.name.Contains("obstical")) // obstical lsa msh implemented
                {
                    // here stop everything and change game play screen to game over
                    GetComponent<AudioSource>().PlayOneShot(die);
                    gameState = GameState.gameover;
                    gameOverMenu.SetActive(true);
                    pauseButton.SetActive(false);
                }
                if (hit.collider.name.Contains("Food"))
                {
                    GetComponent<AudioSource>().PlayOneShot(eating);
                    Destroy(hit.collider.gameObject);
                    Append();
                    FoodGenerator.instance.GenerateFood();
                }
            }
        }
	}

    // append new part to the snake body
    public void Append()
    {
        GameObject part = GameObject.Instantiate(snakePart,snakeParts[snakeParts.Count-1].transform.position,snakeParts[snakeParts.Count-1].transform.rotation) as GameObject;
        part.transform.parent = snakeParts[0].transform.parent;
        if (!snakeParts.Contains(part))
            snakeParts.Add(part);

        if (Movement.instance.stepTime > 0.01f)
        { Movement.instance.stepTime -= 0.01f; }
    }

}
