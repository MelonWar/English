using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}