using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Botton : MonoBehaviour, IPointerDownHandler
{
    /*
    public GameObject buttons;
    


     public void TapGame()
     {
         if (name == "Game")
         {
             Application.LoadLevel("SampleScene");

         }

     }
    public void TapExit()
    {
        if (name == "Exit")
        {
            Application.Quit();
        }
    }
    */


    
 public void OnPointerDown(PointerEventData eventData)
 {
     if (name == "Game")
     {
         SceneManager.LoadScene("SampleScene");

     }

     if (name == "Exit")
     {
         Application.Quit();
     }
 }

}
