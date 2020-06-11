using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Botton : MonoBehaviour, IPointerDownHandler//допоміжний клас,який встроєний в програму, через якого праює функція ОнПоінтерДовн, і який обровляє події
{
    
 public void OnPointerDown(PointerEventData eventData)
 {
     if (name == "Game")//якщо ми взаємодіємо з кнопкою - іде превірка за назваою до якого класу вона відноститься  
     {
         SceneManager.LoadScene("Level 1"); //при написканні на кнопку запускається відповідна сцена

     }

     if (name == "Exit")//якщо ми взаємодіємо з кнопкою - іде превірка за назваою до якого класу вона відноститься  
        {
         Application.Quit();//закривання програми
     }

        if (name == "Reload")//якщо ми взаємодіємо з кнопкою - іде превірка за назваою до якого класу вона відноститься  
        {
            SceneManager.LoadScene("Level 1"); //при написканні на кнопку запускається відповідна сцена

        }
    }

}
