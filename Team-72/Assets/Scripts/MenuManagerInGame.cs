using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MenuManagerInGame : MonoBehaviour
{

    public GameObject inGameScreen, pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
   //     global::System.Object p = inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void PlayButton()
    {

    }

    public void HomeButton()
    {

    }

    public void Pause() //Function to take care of Pause Button.. 
    {

   //     print("Entered Pause Func");
     //   if (Time.timeScale == 1 && paused == false) //1 means the time is normal so the game is running..
     //   {
     //       print("Enterer first if");
      //      Time.timeScale = 0; //Pause Game..
     //   }

//        if (Time.timeScale == 0)
 //       {
   //         Time.timeScale = 1; //Resume Game..
     //   }
    }
}

