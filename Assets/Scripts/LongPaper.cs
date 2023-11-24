using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LongPaper : MonoBehaviour
{
    bool wasRead = false;
    [ShowOnly][SerializeField] bool playerCanRead = false;
    [ShowOnly][SerializeField] bool isReading = false;
    [SerializeField] GameObject UI;

    [SerializeField] List<string> texts;
    TMP_Text[] UITexts;

    AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
        UITexts = UI.GetComponentsInChildren<TMP_Text>();
        UI.SetActive(false);
    }

    void Update()
    {
        if (playerCanRead && Input.GetKeyDown(KeyCode.E) && !isReading)
        {
            DisplayText();
        }
        else if (Input.anyKeyDown && isReading && !Input.GetMouseButtonDown(0))
            RemoveText();

    }

    public void SetRead()
    {
        wasRead = true;
        GetComponent<SpriteRenderer>().color = new Color(.7f, 1, .7f);
    }

    void DisplayText()
    {
        source.Play();

        if (!wasRead)
            SetRead();

        isReading = true;

        List<string> words = Glossary.GetWords();
        int i = 0;
        foreach(string text in texts)
        {
            UITexts[i].text = Glossary.HighlightText(text);
            i++;
        }
            
        UI.SetActive(true);
        RectTransform scroll = GameObject.FindGameObjectWithTag("Scroll").GetComponent<RectTransform>();
        scroll.position = new Vector3(scroll.position.x, 0, scroll.position.z);
    }

    void RemoveText()
    {
        isReading = false;
        if(UI != null)
            UI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            playerCanRead = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerCanRead = false;
            RemoveText();
        }
    }
}
