using UnityEngine;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour
{
//     public void LoadGame()
//     {
//         SceneManager.LoadScene(0);
//     }

public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }


}
