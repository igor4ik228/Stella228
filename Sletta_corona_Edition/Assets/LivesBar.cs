using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];//створюємо масив для панлі з серцями
    private Stella_controller stella_controller;//ссілка на Стеллу

    private void Awake()
    {
        stella_controller = FindObjectOfType<Stella_controller>();

        for (int i = 0; i<hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }

    public void Refresh()//метод, який перевіряє скільки в Стелли ХР і якщо в неї 3 ХР то родить видимими три сермя і тд. (він включає/виключає видимість обєктів в масиві)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < stella_controller.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
