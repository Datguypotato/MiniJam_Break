using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float maxTimeTillDone;
    [SerializeField] private float TimeTillDone = 0;
    private int currentScore = 0;

    [SerializeField] private GameObject endscoreScreen;
    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private TMP_Text customerScore;
    private int customerServed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

        scoreText.text = "Score: 0";
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void AddScore(float difference)
    {
        customerServed++;
        if (difference > 60)
        {
            StartCoroutine(AddScore(0));
        }
        else if (difference < 60 && difference > 40)
        {
            StartCoroutine(AddScore(50));
        }
        else if (difference < 40 && difference > 30)
        {
            StartCoroutine(AddScore(100));
        }
        else if (difference < 30 && difference > 10)
        {
            StartCoroutine(AddScore(500));
        }
        else if (difference < 10)
        {
            StartCoroutine(AddScore(1000));
        }
    }

    private void Update()
    {
        TimeTillDone += Time.deltaTime;

        if (TimeTillDone > maxTimeTillDone)
        {
            FindObjectOfType<GameManager>().coffeeParent.SetActive(false);
            OpenScoreScreen();
        }
    }

    private void OpenScoreScreen()
    {
        endscoreScreen.SetActive(true);
        endScoreText.text = currentScore.ToString();
        customerScore.text = customerServed.ToString();
    }

    private IEnumerator AddScore(int a_Score)
    {
        scoreText.text += "\n +" + a_Score;
        yield return new WaitForSeconds(1.0f);
        currentScore += a_Score;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}