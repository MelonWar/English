using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;

    [SerializeField] float audioDelay = 3f;
    AudioSource source;

    Character Player;
    int enterCounter = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        source = GetComponent<AudioSource>();
    }

    public void ReplayAudio()
    {
        source.Stop();
        source.Play();
    }

    public void PauseAudio()
    {
        if (source.isPlaying)
            source.Pause();
    }
    public void UnPauseAudio()
    {
        source.UnPause();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            Player.SetRoom(gameObject);
            enterCounter++;
            virtualCam.SetActive(true);
            if (source.clip != null && enterCounter < 2)
                source.PlayDelayed(audioDelay);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (source != null && source.isPlaying)
                source.Stop();
            virtualCam.SetActive(false);
        }
    }
}
