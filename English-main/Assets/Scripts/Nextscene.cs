using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextscene : MonoBehaviour
{
    public Animator transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(nameof(LoadLevel));
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("SceneChange");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
