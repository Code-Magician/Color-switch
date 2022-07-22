using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManager
{
	/// <summary>
	/// Goes to the menu with the given name
	/// </summary>
	/// <param name="name">name of the menu to go to</param>
	public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Help:

                // go to DifficultyMenu scene
                SceneManager.LoadScene("Help");
                break;
            case MenuName.Gameover:
                // instantiate prefab

                if (GameObject.FindGameObjectsWithTag("Gameover").Length == 0)
                    Object.Instantiate(Resources.Load("GameoverCanvas"));
                break;
            case MenuName.Main:
                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                // instantiate prefab
                if(GameObject.FindGameObjectsWithTag("Pause").Length == 0)
                    Object.Instantiate(Resources.Load("PauseCanvas"));
                break;
        }
	}
}
