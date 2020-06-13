using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null; //ВІДКРИВАЄМО ДОСТУП ДО КОНТРОЛЕЛРА З ЛЮБОЇ ЧАСТІ СКРИПТА
    int sceneIndex;//для сприйняття номера уровня
    int levelComplete;//які рінві у нас завершені
    

    void Start()
    {
        if(instance == null) //повноціний звязок кода з колайдером персонажа
        {
            instance = this;
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;//сетІндекс получає номер теперішньої сцени
        levelComplete = PlayerPrefs.GetInt("LevelComplete"); //левелКомпліт записує інформацію плеєрПрефс (той рівень, який якраз завершили)
    }

    public void isEndGame()
    {
        if (sceneIndex == 3)//провірка чи це остінній рівень
        {
            Invoke("LoadMainMenu", 1f);//запустити головне меню(з рівнями) з затримкою в один фрейм
        }
        else
        {
            if (levelComplete < sceneIndex) //якщо завершено рівнів меньше чім наший теперішній рівень то 
                PlayerPrefs.SetInt("LevelComplete", sceneIndex); //має записати текучий рівень, якщо ми ще не завершили всі рівні
            Invoke("NextLevel", 1f);//відкрити наступний рівень        
        }
    }

     void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1); //запустити сцену з індексом на 1 більше (наступну)
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
