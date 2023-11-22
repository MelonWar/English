using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;
    Door door;
    AudioSource source;
    bool isInRoom = false;
    int enterCounter = 0;

    void Start()
    {
        door = GetComponentInChildren<Door>();

        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && door != null && isInRoom)
            door.Open();
    }

    private void WelcomeInRoom()
    {
        if (source != null)
        source.PlayDelayed(2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            isInRoom = true;
            enterCounter++;
            if (enterCounter == 1)
                WelcomeInRoom();
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            isInRoom = false;
            if (source != null && source.isPlaying)
                source.Stop();
            virtualCam.SetActive(false);
        }
    }
}
