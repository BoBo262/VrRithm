using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetTrigger : MonoBehaviour
{
    public int score;
    public scoreKeeping scoring;
    
    // Start is called before the first frame update
    void Start()
    {
        scoring = GameObject.FindGameObjectWithTag("Score").GetComponent<scoreKeeping>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == gameObject.tag)
        {
            scoring.score++;
            Destroy(gameObject);
        }
        else
        {
            scoring.score--;
            Destroy(gameObject);
        }
            

            
    }
}
