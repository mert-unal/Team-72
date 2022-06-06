using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{
    // public void ingameNewScene()
    // {
    //     //SceneManager.LoadScene("Sce 1");
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    //     //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}


// public class LoadSceneOnClick : MonoBehaviour {
 
//     // Use this for initialization
//     public void LoadByIndex(int sceneIndex)
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//     }
// }