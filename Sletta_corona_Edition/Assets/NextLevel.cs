using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelController.instance.isEndGame();
        //запускається метод ісЕндГейм, з класа ЛевелКонтроллер (інстанс - це відкрити доступ до функції)
    }
}
