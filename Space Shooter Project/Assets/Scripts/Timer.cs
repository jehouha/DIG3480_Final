using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;
    public static float deltaTime;

    public Text countdownText;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        countdownText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.timeMode == true)
        {
            if (gameController.gameOver == false)
            {
                Counting();
            }
        }
    }
    
    void Counting()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            WinGame();
        }
    }
    
    public void WinGame()
    {
        Debug.Log("time's up");
        currentTime = startingTime;

        gameController.WinCheck();
        gameController.gameOver = true;
    }
}
