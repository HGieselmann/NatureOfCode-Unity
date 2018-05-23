using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene scene;

//    public void Update()
//    {
//        Debug.Log(SceneManager.GetActiveScene().buildIndex);
//    }

    public void NextScene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentscene + 1);
    }
    
    public void PrevScene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentscene - 1);
    }
    public void DirectSelect(int _level)
        {
            SceneManager.LoadScene(_level);
        }

    public void QuitMe()
    {
        Application.Quit();
    }
}
