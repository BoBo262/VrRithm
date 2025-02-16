using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public int songChoice;
    public AudioSource source;
    public GameObject spawner;
    public spawner spawnObject;
    public SongSelect songSelect;
    public scoreKeeping score;
    public AudioProcessor processor;
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        processor = gameObject.GetComponent<AudioProcessor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score.score <= 0)
            source.Stop();
    }

    public void PrepareSong()
    {
        processor.onBeat.AddListener(OnBeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
        switch (songSelect.songChoice)
        {
            case 0:
                source.clip = clip1;
                source.PlayOneShot(clip1);
                break;
            case 1:
                source.clip = clip2;
                source.PlayOneShot(clip2);
                break;
            case 2:
                source.clip = clip3;
                source.PlayOneShot(clip3);
                
                break;
            default:
                source.clip = clip1;
                source.PlayOneShot(clip1);
                
                break;
        }
        
    }

    void OnBeatDetected()
    {
        spawnObject.spawn();
    }

    void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }

}
