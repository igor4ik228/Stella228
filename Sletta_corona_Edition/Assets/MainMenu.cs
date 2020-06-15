using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button level2B;
    public Button level3B;
    public Button level4B;
    public Button level5B;
    public Button level6B;
    public Button level7B;
    public Button level8B;
    public Button level9B;

    int levelComplete;


    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("LevelComplete");//получаєм інформацію які уровін завершені і на які рівні можна перейти
        level2B.interactable = false;//по стандарту кнопка не активна
        level3B.interactable = false;//тоже
        level4B.interactable = false;//тоже
        level5B.interactable = false;//тоже
        level6B.interactable = false;//тоже
        level7B.interactable = false;//тоже
        level8B.interactable = false;//тоже
        level9B.interactable = false;//тоже

        switch (levelComplete)//свіч кейс для доступу до уровнів
        {
            case 1:
                level2B.interactable = true;
                break;
            case 2:
                level2B.interactable = true;
                level3B.interactable = true;
                break;
            case 3:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                break;
            case 4:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                break;
            case 5:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                level6B.interactable = true;
                break;
            case 6:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                level6B.interactable = true;
                level7B.interactable = true;
                break;
            case 7:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                level6B.interactable = true;
                level7B.interactable = true;
                level8B.interactable = true;
                break;
            case 8:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                level6B.interactable = true;
                level7B.interactable = true;
                level8B.interactable = true;
                level9B.interactable = true;
                break;
            case 9:
                level2B.interactable = true;
                level3B.interactable = true;
                level4B.interactable = true;
                level5B.interactable = true;
                level6B.interactable = true;
                level7B.interactable = true;
                level8B.interactable = true;
                level9B.interactable = true;
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
        level4B.interactable = false;
        level5B.interactable = false;
        level6B.interactable = false;
        level7B.interactable = false;
        level8B.interactable = false;
        level9B.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
