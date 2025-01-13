using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayController : MonoBehaviour
{
    public static GamePlayController ornek;



    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText, gameOverText;
    public Image HelpIcon;

    [SerializeField]
    private Button restartButton, PauseButton;

    [SerializeField] 
    private GameObject pausePanel;
    [SerializeField]
    private Sprite[] medalicon;
    [SerializeField]
    private Image[] medal;

    // Start is called before the first frame update
    private void Awake()
    {
        MakeInstance();
        HelpIcon.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    void MakeInstance()
    {
        if (ornek == null)
        {
            ornek = this;
        }
    }

    public  void    PauseGame()
    {
        if (BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                endScoreText.text =""+ BirdScript.instance.score;
                bestScoreText.text = "" + DataController.ornek.getHighScore();
                    restartButton.onClick.RemoveAllListeners();
                restartButton.onClick.AddListener(() => ResumeGame());
            }
        }
    }

    public void goToMenuButton()
    {
        Application.LoadLevel("MainMenu");
    }
    public void RestartGame()
    {
        Application.LoadLevel("PlayScreen");
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(true);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        HelpIcon.gameObject.SetActive(false);

    }
    public void SetScore(int score)
    {
        try
        {
            scoreText.text = "" + score;
        }
        catch (Exception e)
        {
            throw new Exception($"scoreText null geldi:{e.Message}");
        }
    }
    public void SkoruGoster(int score)
    {
        pausePanel.SetActive(true);
        endScoreText.text = "" + BirdScript.instance.score;
        gameOverText.gameObject.SetActive(true );
        scoreText.gameObject.SetActive(false);

        if (score > DataController.ornek.getHighScore()) 
        {
            DataController.ornek.setHighScore(score);
        
        }
        bestScoreText.text = "" + DataController.ornek.getHighScore();

        if (score <= 10)
        {
            medal[0].sprite = medalicon[0];

        }
        else if (score > 10 && score < 30)
        {
            medal[0].sprite = medalicon[1];

        }
        else 
        {
            medal[0].sprite = medalicon[2];        
        }
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => RestartGame());
      
            
    }
}
