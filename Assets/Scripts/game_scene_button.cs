using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_scene_button : MonoBehaviour
{
    public GameObject[] audio;
    public SongSelect select;
    public void Update()
    {
      
    }
    public void ChangeScene(string sceneName)
    {
        for (int i = 0;i< 3;i++)
        {
            if (select.songChoice == i)
                audio[i].SetActive(true);
            else
                audio[i].SetActive(false);
        }
        //SceneManager.LoadScene(sceneName);
    }
}
