using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Bot : MonoBehaviour
{
    bool canInteract = false;

    Animator animator;
    AudioSource source;

    int i = 0;
    public AudioClip interactClip;
    public List<AudioClip> audios = new();

    [SerializeField] GameObject gift;
    [SerializeField] GameObject door;

    [SerializeField] GameObject GameManager;
    PauseMenu PauseMenu;

    bool audioPlaying = false;
    bool woke = false;
    void Start()
    {
        PauseMenu = GameManager.GetComponent<PauseMenu>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        if (gift != null)
            gift.SetActive(false);
    }

    private void Update()
    {
        if (PauseMenu.isPaused())
        {
            if(source.isPlaying)
                source.Pause();
            return;
        }
        source.UnPause();
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Wake();
            i = 0;
            audioPlaying = true;
            source.clip = audios[i];
            source.Play();
        }
        if (!source.isPlaying && audioPlaying)
        {
            if (i + 1 < audios.Count) // plays next audio when the current audio finishes
            {
                i++;
                source.clip = audios[i];
                source.Play();
            }
            else // we've reached the end of our list of audios
            {
                audioPlaying = false;
                if (gift != null)
                    GiveGift();
                if (door != null)
                    StartCoroutine(door.GetComponent<Door>().OpenDoorWithDelay(3f));
            }
        }

    }

    public void GiveGift()
    {
        source.clip = interactClip;
        source.Play();
        gift.SetActive(true);
    }

    public void Wake()
    {
        woke = true;
        animator.SetTrigger("Wake");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            canInteract = false;
    }
}
