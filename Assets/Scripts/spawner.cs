using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public Toggle hardMode;
    public GameObject[] targets;
    public Transform[] points;
    public float beat = (60 / 130) * 2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void spawn()
    {
        GameObject target = Instantiate(targets[Random.Range(0, 2)], points[Random.Range(0, 4)]);
        if(hardMode.isOn)
        {
            target.GetComponent<targetMovement>().speed = 4;
        }
        else
            target.GetComponent<targetMovement>().speed = 2;
        target.transform.localPosition = Vector3.zero;
        target.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
    }
}
