using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour

{
    [SerializeField] Text highscoreText;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            highscoreText.text = "No Games Played Yet.";
        }
    }
    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("Gameplay");
	}

	/// <summary>
	/// Handles the on click event from the high score button
	/// </summary>
	public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }

	/// <summary>
	/// Handles the on click event from the quit button
	/// </summary>
	public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
    }
} 
