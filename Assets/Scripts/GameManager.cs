using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance { get; private set; }

    // API
    public bool isGameOver { get; private set; }

    //Constants
    private static readonly string KEY_HIGHEST_SCORE = "HighestScore";

    [Header("Audio")]
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource gameOverSfx;

    [Header("Score")]
    [SerializeField] private float score;
    [SerializeField] private int highestScore;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }    

        score = 0;
        highestScore = PlayerPrefs.GetInt(KEY_HIGHEST_SCORE);

    }

    private void Update()
    {
        if (!isGameOver) 
        { 
            score += Time.deltaTime;
        }

        if (GetScore() > GetHighestScore())
        { 
            highestScore = GetScore();
        }
    }

    public int GetScore()
    {
        return (int) Mathf.Floor(score);
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void EndGame()
    {
        if (isGameOver) return;

        isGameOver = true;

        musicPlayer.Stop();

        gameOverSfx.Play();

        //Save highestScore
        PlayerPrefs.SetInt(KEY_HIGHEST_SCORE, GetHighestScore());

        //Reload scene
        StartCoroutine(ReloadScene(6));
    }

    private IEnumerator ReloadScene(float delay)
    { 
        //Wait
        yield return new WaitForSeconds(delay);

        //Reload scene 
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
