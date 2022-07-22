using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    [SerializeField]
    List<Color32> colours = new List<Color32>();
    Dictionary<string, Color32> spriteToColor = new Dictionary<string, Color32>();

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    const string preHighscoreText = "HIGHSCORE : ";
    const string preScoreText = "SCORE : ";
    public int score;
    public int highscore;
    float posY;
    float posY10;
    bool gameover;
    bool startingjump;

    int gameoveraudioclipINT = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        startingjump = true;
        score = 0;
        scoreText.text = preScoreText + score;
        posY = transform.position.y;

        highscore = GetHighScore();
        if (highscore != -1)
        {
            highscoreText.text = preHighscoreText + highscore;
        }
        else
        {
            highscoreText.text = preHighscoreText + "NA";
        }

        playerRb = GetComponent<Rigidbody2D>();
        spriteToColor.Add("Small Circle_0", colours[0]);
        spriteToColor.Add("Small Circle_1", colours[1]);
        spriteToColor.Add("Small Circle_2", colours[2]);
        spriteToColor.Add("Small Circle_3", colours[3]);
    }

    // Update is called once per frame
    void Update()
    {
        startingPlayerJump();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)) && !gameover)
        {
            startingjump = false;
            AudioManager.Play(AudioClipName.BallJump);
            playerRb.velocity = Vector2.up * ConfigurationUtils.Player_JumpForce;
        }

        if (transform.position.y < ScreenUtils.ScreenBottom)
        {
            gameover = true;
            
            if(gameoveraudioclipINT == 0)
            {
                gameoveraudioclipINT++;
                AudioManager.Play(AudioClipName.Gameover);
                SaveHighScore();
            }
            MenuManager.GoToMenu(MenuName.Gameover);
        }

        UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColorChanger"))
        {
            int randIndex = Random.Range(0, colours.Count);
            GetComponent<SpriteRenderer>().color = colours[randIndex];
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (checkColorSame(collision))
            {
                score += 10;
            }
            else
            {
                gameover = true;
                if (gameoveraudioclipINT == 0)
                {
                    gameoveraudioclipINT++;
                    AudioManager.Play(AudioClipName.Gameover);
                    SaveHighScore();
                }
                Timer timer = gameObject.AddComponent<Timer>();
                timer.Duration = 1f;
                

                if (timer.Finished)
                {
                    MenuManager.GoToMenu(MenuName.Gameover);
                }
            }
        }
    }


    bool checkColorSame(Collider2D coll)
    {
        SpriteRenderer obj = coll.gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer player = GetComponent<SpriteRenderer>();

        if (obj.color == player.color)
        {
            return true;
        }
        else if (spriteToColor.ContainsKey(obj.sprite.name))
        {
            Color32 objColor = spriteToColor[obj.sprite.name];
            if (objColor == player.color)
                return true;
        }
        return false;
    }

    void UpdateScore()
    {
        if (posY < transform.position.y)
            posY = transform.position.y;

        score = (int)(posY + 10);
        scoreText.text = preScoreText + score;
    }

    void SaveHighScore()
    {
        if (score > highscore)
        {
            AudioManager.Play(AudioClipName.highscore);
            highscore = score;
        }
            

        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            return PlayerPrefs.GetInt("Highscore");
        }
        else {
            return -1;
        }
    }
    
    void startingPlayerJump()
    {
        Vector2 pos = new Vector2(0, -10);

        if (transform.position.y <= -10 && !gameover)
        {
            startingjump = true;
        }

        if(Input.touchCount == 0 && startingjump)
        {
            startingjump = false;
            AudioManager.Play(AudioClipName.BallJump);
            playerRb.velocity = Vector2.up * ConfigurationUtils.Player_JumpForce;
        }
    }
}
