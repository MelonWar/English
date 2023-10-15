using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;
    Door door;
    bool isInRoom = false;

    void Start()
    {
        door = GetComponentInChildren<Door>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && door != null && isInRoom)
            door.Open();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            isInRoom = true;
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            isInRoom = false;
            virtualCam.SetActive(false);
        }
    }
}
