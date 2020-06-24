using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chngescenes : MonoBehaviour
{
    public void mainscene()
    {
        SceneManager.LoadScene("ARBUSINESSCARD");
    }
    public void splashscene()
    {
        SceneManager.LoadScene("splash");
    }
    public void instructionsscene()
    {
        SceneManager.LoadScene("instructions");
    }
    public void aboutscene()
    {
        SceneManager.LoadScene("about");
    }

}