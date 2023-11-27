using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuroInput : MonoBehaviour
{
    [SerializeField] GameObject lien;

    [SerializeField] List<Neuronne> neuronnes = new();
    List<LineRenderer> liens = new();

    [SerializeField] bool estFinal = false;
    [SerializeField] GameObject door;

    [SerializeField] float weight = 0.5f;

    public bool state { get; private set; } = false;

    Color openColor = Color.white;
    Color closedColor = Color.black;
    Color openNegativeColor = Color.red;

    SpriteRenderer spriteRenderer;
    SpriteRenderer outlineRenderer;

    [SerializeField] GameObject outline;

    AudioSource source;

    bool canInteract = false;

    void Start()
    {
        if(!estFinal)
            LierNeuronnes();

        spriteRenderer = GetComponent<SpriteRenderer>();
        outlineRenderer = outline.GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

        UpdateColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
            Interact();
    }

    void Interact()
    {
        source.Play();
        ChangeState();
        if(!estFinal)
            foreach (Neuronne neuron in neuronnes)
                neuron.ChangeInput(state ? weight : -weight);
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

    private void ChangeState()
    {
        state = !state;
        if (state && estFinal)
            StartCoroutine(door.GetComponent<Door>().OpenDoorWithDelay(.5f));
        UpdateColor();
    }

    void UpdateColor()
    {
        Color color = state ?
            (weight < 0 ? openNegativeColor : openColor) : closedColor;
        if(!estFinal)
        {
            foreach (LineRenderer lien in liens)
            {
                lien.startColor = color;
                lien.endColor = color;
            }
        }
        spriteRenderer.color = color;
        outlineRenderer.color = color;
    }
    void LierNeuronnes()
    {
        foreach(Neuronne neuronne in neuronnes)
        {
            LineRenderer newLien = Instantiate(lien, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
            liens.Add(newLien);
            newLien.SetPosition(1, neuronne.transform.position - transform.position);
        }
    }
}
