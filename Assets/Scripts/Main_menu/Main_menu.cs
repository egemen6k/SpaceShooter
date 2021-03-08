using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene(1); // SP game scene
    }

    public void LoadCoop()
    {
        SceneManager.LoadScene(2); // MP game scene
    }
}
