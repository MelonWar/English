using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Neuronne : MonoBehaviour
{
    [SerializeField] GameObject lien;

    [SerializeField] List<Neuronne> neuronnes = new();
    List<LineRenderer> liens = new();

    [SerializeField] bool estFinal = false;
    [SerializeField] GameObject door;

    [ShowOnly] [SerializeField] bool state = false;
    [ShowOnly] [SerializeField] float sum = 0;

    [SerializeField] public float weight = 0.5f;
    [SerializeField] public float bias = 10f;
    [SerializeField] float minBias = 0f;
    [SerializeField] public float maxBias = 2f;
    [SerializeField] bool isBias = false;

    SpriteRenderer spriteRenderer;
    SpriteRenderer outlineRenderer;

    [SerializeField] GameObject outline;

    Color openColor = Color.white;
    Color closedColor = Color.black;
    Color openNegativeColor = Color.red;

    Slider slider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        outlineRenderer = outline.GetComponent<SpriteRenderer>();
        if(!estFinal)
            LierNeuronnes();

        slider = GetComponentInChildren<Slider>();

        if (!isBias)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.minValue = minBias;
            slider.maxValue = maxBias;
            slider.value = bias;
        }

        UpdateColor();
    }
    public void ChangeBias()
    {
        bias = slider.value;
        ChangeInput(0);
    }
    public void ChangeInput(float value)
    {
        sum += value;
        if ((sum >= bias && !state) || (sum < bias && state))
            ChangeState();
    }

    private void ChangeState()
    {
        state = !state;
        UpdateColor();
        if (estFinal)
        {
            if (state)
                StartCoroutine(door.GetComponent<Door>().OpenDoorWithDelay(.5f));
        }
        else
            foreach (Neuronne neuron in neuronnes)
                neuron.ChangeInput(state ? weight : -weight);
    }

    private void UpdateColor()
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
        foreach (Neuronne neuronne in neuronnes)
        {
            LineRenderer newLien = Instantiate(lien, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
            liens.Add(newLien);
            newLien.SetPosition(1, neuronne.transform.position - transform.position);
        }
    }
}
