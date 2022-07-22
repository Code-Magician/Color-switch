using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    bool following = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position.y > transform.position.y) && following)
        {
            Vector3 pos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = pos;
        }
        
        if(player.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            following = false;
        }
        else
        {
            following = true;
        }
    }


    public void HandlePauseButton()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Pause);
    }
}
