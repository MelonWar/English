using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject glossary;
    TMP_Text[] glossaryDefs;

    Animator animator;

    Character player;

    [ShowOnly] [SerializeField] bool paused = false;

    public bool isPaused()
        => paused;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        animator = pauseMenu.GetComponent<Animator>();
        pauseMenu.SetActive(false);

        glossaryDefs = glossary.GetComponentsInChildren<TMP_Text>();
    }

    Room GetRoom()
        => player.Room.GetComponent<Room>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void OpenGlossary()
    {
        pauseMenu.SetActive(false);

        int i = 0;
        foreach(string word in Glossary.GetWords())
        {
            glossaryDefs[i].text = $"{word} : {Glossary.glossary[word]}";
            i++;
        }
        glossary.SetActive(true);

    }

    public void ReplayAudio()
    {
        ResumeGame();
        GetRoom().ReplayAudio();
    }

    public void PauseGame()
    {
        GetRoom().PauseAudio();
        pauseMenu.SetActive(true);
        animator.SetTrigger("Pause");
        paused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        GetRoom().UnPauseAudio();
        animator.SetTrigger("Resume");
        pauseMenu.SetActive(false);
        glossary.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
}
