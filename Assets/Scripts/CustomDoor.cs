using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomDoor : MonoBehaviour
{
    bool canInteract = false;

    public GameObject virtualCam;

    void Start()
    {
        
    }
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if(virtualCam != null)
            {
                virtualCam.SetActive(false);
            }
            Transition();
        }
    }

    public void Transition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
