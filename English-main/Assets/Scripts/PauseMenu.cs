using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject Page1;
    [SerializeField] GameObject Page2;
    [SerializeField] GameObject Page3;
    [SerializeField] GameObject Page4;
    [SerializeField] GameObject Page5;
    [SerializeField] GameObject Page6;
    [SerializeField] GameObject Page7;
    [SerializeField] GameObject Glossary;
    [SerializeField] GameObject MainPauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Return();
        }
    }

    public void Continue()
    { canvas.enabled = false; }

    public void OpenPage1()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage2()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(true);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage3()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(true);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage4()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(true);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage5()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(true);
        Page6.SetActive(false);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage6()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(true);
        Page7.SetActive(false);
        MainPauseMenu.SetActive(false);
    }

    public void OpenPage7()
    {
        canvas.enabled = true;
        Glossary.SetActive(true);
        Page1.SetActive(false);
        Page2.SetActive(false);
        Page3.SetActive(false);
        Page4.SetActive(false);
        Page5.SetActive(false);
        Page6.SetActive(false);
        Page7.SetActive(true);
        MainPauseMenu.SetActive(false);
    }


    public void Return()
    {
        Glossary.SetActive(false);
        MainPauseMenu.SetActive(true);
    }

    public void Leave()
    {
        Application.Quit();
    }

}
