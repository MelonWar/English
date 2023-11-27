using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource source;

    int i = 0;
    [SerializeField] public List<AudioClip> levelTracks;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!IsMusicPlaying())
        {
            if(i < levelTracks.Count)
            {
                PlayMusic(levelTracks[i]);
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        source.Stop();
        source.clip = clip;
        source.Play();
    }

    public void LoopMusic(AudioClip clip)
    {
        source.Stop();
        source.loop = true;
        PlayMusic(clip);
    }

    public void StopMusic()
    {
        source.loop = false;
        source.Stop();
    }

    public bool IsMusicPlaying()
        => source.isPlaying;

}
