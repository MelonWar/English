using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform target;
    float speed = 3;

    public bool opened { get; private set; } = false;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (opened && distance > 0.001f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.deltaTime);
    }

    public void Open()
    {
        if(opened == false)
        {
            opened = true;

            // play opening sound
            GetComponent<AudioSource>().Play();
        }
    }
}
