using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    /*
     * TO-DO
     * Implement pause
     * On game start screen: 
     *  pause the game
     * On Game Over Screen:
     *  pause game
     * Restart:
     *  set scores back to 0
     *  Reset all blocks
     *  
     *  build game end game is not working
     *  mouse disappears when clicked inside
     *  
     */

    public GameObject gameStart;
    public GameObject gameOver;

    public Button startButton;
    public Button endButton;
    public Button restartButton;

    public GameObject startBall;
    private Rigidbody rb_startBall;
    

    private bool isStart;

    // Start is called before the first frame update
    void Start()
    {

        gameStart.SetActive(true);
        isStart = false;
        //gameOver.SetActive(false);
        rb_startBall = startBall.GetComponent<Rigidbody>();

        startButton.onClick.AddListener(StartButton);
        endButton.onClick.AddListener(EndButton);
        restartButton.onClick.AddListener(RestartButton);

    }
    

    public void GameOver()
    {
        if (!gameStart.activeSelf)
        {
            gameOver.SetActive(true);
        }
    }

    public bool IsStart()
    {
        return isStart;
    }

    void StartButton()
    {
        isStart = true;
        gameStart.SetActive(false);

        transform.parent = null;
        //start = true;
        rb_startBall.isKinematic = false;
        rb_startBall.AddForce(new Vector3(600f, 600f, 0));

    }

    void RestartButton()
    {

    }

    void EndButton()
    {

    }

    /*
     * TO-DO:
     * when button is pressed:
     * isStart = true
     * gameStart.SetActive(false);
     * call method
     *  instantiate the ball
     *  allow player to move
     */
}
