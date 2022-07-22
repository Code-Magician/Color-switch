using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameover : MonoBehaviour
{

    public TextMeshProUGUI GameoverScoreText;
    public TextMeshProUGUI GameoverHighScoreText;
    const string preScoreText = "YOUR SCORE : ";
    const string preHighScoreText = "HIGHSCORE : ";
    int score;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        score = player.score;
        GameoverScoreText.text = preScoreText + score;

        if(player.highscore != -1)
            GameoverHighScoreText.text = preHighScoreText + player.highscore;
        else
        {
            GameoverHighScoreText.text = "No Games Played Yet.";
        }
    }
    
    public void HandleGameoverButton()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
