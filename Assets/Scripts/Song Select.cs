using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelect : MonoBehaviour
{
    public Dropdown m_Dropdown;
    public Text m_Text;
    public int songChoice;
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioPlay audioPlay;
    void Start()
    {
 
        m_Dropdown = GetComponent<Dropdown>();
  
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });

        //Initialise the Text to say the first value of the Dropdown
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropdownValueChanged(Dropdown change)
    {
        songChoice = change.value;
    }
}
