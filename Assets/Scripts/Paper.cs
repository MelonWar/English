using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    bool wasRead = false;
    [ShowOnly][SerializeField] bool playerCanRead = false;
    [ShowOnly][SerializeField] bool isReading = false;
    [SerializeField] GameObject UI;

    [SerializeField] string text;
    TMP_Text UIText;

    AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
        UIText = UI.GetComponentInChildren<TMP_Text>();
        UI.SetActive(false);
    }

    void Update()
    {
        if (playerCanRead && Input.GetKeyDown(KeyCode.E) && !isReading)
        {
            DisplayText();
        }
        else if (Input.anyKeyDown && isReading)
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

        UIText.text = Glossary.HighlightText(text);
        UI.SetActive(true);
    }

    void RemoveText()
    {
        isReading = false;
        if (UI != null)
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
