using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    private int score;

    public Text restartText;
    public Text gameOverText;
    public Text creditText;
    public Text hModeText;
    public Text tModeText;

    public bool gameOver;
    private bool restart;

    private AudioManager audioManager;
    public AudioSource bgm;
    public GameObject winSound;

    public Mover mover;

    public bool timeMode;

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        gameOver = false;
        restart = false;
        restartText.text = "Press 'R' for Timed Mode";
        gameOverText.text = "";
        creditText.text = "";
        hModeText.text = "Press 'E' for Hard Mode";
        tModeText.text = "";

        audioManager = AudioManager.instance;
        bgm = GetComponent<AudioSource>();
        mover = GetComponent<Mover>();
        winSound.SetActive(false);

        timeMode = false;
    }

    void Update()
    {
        LoseCheck();
        if (timeMode == false)
        {
            if (score >= 100)
            {
                score = 100;
                WinCheck();
            }
        }
        if (gameOver)
        {
            Destroy(bgm);
        }

        if (gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E was pressed");
                HardMode();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R was pressed");
                TimedMode();
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(
                    -spawnValues.x, spawnValues.x), 
                    spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        if (gameOver == false)
        {
            score += newScoreValue;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        creditText.text = "Made by Julia Houha";
        gameOver = true;
        audioManager.PlaySound("lose_sound");
    }

    public void WinCheck()
    {
        UpdateScore();
        gameOverText.text = "You Win";
        creditText.text = "Made by Julia Houha";
        gameOver = true;
        winSound.SetActive(true);
    }

    public void LoseCheck()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void HardMode()
    {
        mover.speed = -10;
        score = 0;
        UpdateScore();
    }

    public void TimedMode()
    {
        timeMode = true;
        score = 0;
        UpdateScore();
        restartText.text = "";
    }
}