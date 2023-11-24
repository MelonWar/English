using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;

    public IEnumerator OpenDoorWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OpenDoor();
    }
    public void OpenDoor()
    {
        if(!opened)
        {
            GetComponent<Animator>().SetTrigger("Open");
            GetComponent<AudioSource>().Play();
            BoxCollider2D coll = GetComponent<BoxCollider2D>();
            coll.size = new Vector2(coll.size.x, .2f);
            coll.offset = new Vector2(coll.offset.x, .5f);
            opened = true;
        }
    }
}
