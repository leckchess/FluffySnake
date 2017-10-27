using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {



    public enum Dir { down, left, up ,right};

    public float stepTime; // time between steps
    public float step;
    public Dir _dir = Dir.right;

    public static Movement instance;


    #region Unity Functions

    private void Awake()
    {
        instance = this;
    }

    void Update () {

        if (GameManager.instance.gameState == GameManager.GameState.play)
        {
            if ((SwipeManager.swipeDirection == SwipeManager.Swipe.Up || (Input.GetAxis("Vertical") > 0)) && _dir != Dir.down)
            {
                _dir = Dir.up;
                transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
            }
            if ((SwipeManager.swipeDirection == SwipeManager.Swipe.Down || (Input.GetAxis("Vertical") < 0)) && _dir != Dir.up)
            {
                _dir = Dir.down;
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }
            if ((SwipeManager.swipeDirection == SwipeManager.Swipe.Right || (Input.GetAxis("Horizontal") > 0)) && _dir != Dir.right)
            {
                _dir = Dir.right;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            if ((SwipeManager.swipeDirection == SwipeManager.Swipe.Left || (Input.GetAxis("Horizontal") < 0)) && _dir != Dir.left)
            {
                _dir = Dir.right;
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }

    }


    #endregion

    #region Game Main Functions

    // to start the game once the player hit play
    public void StartGame()
    {
        GameManager.instance.snakeParts.Add(gameObject);
        GameManager.instance.Append();
        GameManager.instance.Append();
        FoodGenerator.instance.GenerateFood();
        StartCoroutine("NextStep");
    }

    public IEnumerator NextStep()
    {
        if (GameManager.instance.gameState != GameManager.GameState.play)
            yield break;
        // moving the snake body parts
        for (int i = GameManager.instance.snakeParts.Count - 1; i > 0; i--)
        {
            GameManager.instance.snakeParts[i].transform.position = GameManager.instance.snakeParts[i - 1].transform.position;
        }

        transform.position += transform.right * 1 * step;

        // calling for the next step after a certain time
        yield return new WaitForSeconds(stepTime);
        StartCoroutine(NextStep());
    }
    
    #endregion

}
