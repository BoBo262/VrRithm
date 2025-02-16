using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public scoreKeeping score;
    public GameObject spawner;
    public spawner spawnerSpeed;
    public AudioPlay audioPlay;
    // Start is called before the first frame update
    void Start()
    {
        spawnerSpeed = spawner.GetComponent<spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        spawner.SetActive(true);
        score.score = 3;
    }


}
