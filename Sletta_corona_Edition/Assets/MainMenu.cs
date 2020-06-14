using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button level2B;
    public Button level3B;
    int levelComplete;


    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");//получаєм інформацію які уровін завершені і на які рівні можна перейти
        level2B.interactable = false;//по стандарту кнопка не активна
        level3B.interactable = false;//тоже

        switch (levelComplete)//свіч кейс для доступу до уровнів
        {
            case 1:
                level2B.interactable = true;
                break;
            case 2:
                level2B.interactable = true;
                level3B.interactable = true;
                break;
        }
    }

    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void Reset()
    {
        level2B.interactable = false;
        level3B.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
