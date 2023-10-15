using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform target;
    float speed = 3;

    bool open = false;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if (open && distance > 0.001f)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
    }

    public void Open()
    {
        open = true;
    }
}
