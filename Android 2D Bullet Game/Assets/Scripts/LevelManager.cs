using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void Reload() {
        switch (GameManager.type) {
            case (dungeonType.Beach):
                SceneManager.LoadScene("BeachMain");
                break;
            case (dungeonType.Beach2):
                SceneManager.LoadScene("Beach2Main");
                break;
            case (dungeonType.Beach3):
                SceneManager.LoadScene("Beach3Main");
                break;
            case (dungeonType.Forest):
                SceneManager.LoadScene("ForestMain");
                break;
            case (dungeonType.Forest2):
                SceneManager.LoadScene("Forest2Main");
                break;
            case (dungeonType.Forest3):
                SceneManager.LoadScene("Forest3Main");
                break;
            case (dungeonType.Snow):
                SceneManager.LoadScene("SnowMain");
                break;
            case (dungeonType.Snow2):
                SceneManager.LoadScene("Snow2Main");
                break;
            case (dungeonType.Tundra):
                SceneManager.LoadScene("TundraMain");
                break;
            default:
                Application.Quit();
                break;
        }
    }


    public void Forest() {
        GameManager.type = dungeonType.Forest;
        SceneManager.LoadScene("ForestMain");
    }
    
    public void Map() {
        SceneManager.LoadScene("Map");
    }

    public void Forest2()
    {
        GameManager.type = dungeonType.Forest2;
        SceneManager.LoadScene("Forest2Main");
    }

    public void Forest3()
    {
        GameManager.type = dungeonType.Forest3;
        SceneManager.LoadScene("Forest3Main");
    }

    public void Snow()
    {
        GameManager.type = dungeonType.Snow;
        SceneManager.LoadScene("SnowMain");
    }

    public void Snow2()
    {
        GameManager.type = dungeonType.Snow2;
        SceneManager.LoadScene("Snow2Main");
    }

    public void Tundra()
    {
        GameManager.type = dungeonType.Tundra;
        SceneManager.LoadScene("TundraMain");
    }

    public void Beach()
    {
        GameManager.type = dungeonType.Beach;
        SceneManager.LoadScene("BeachMain");
    }

    public void Beach2()
    {
        GameManager.type = dungeonType.Beach2;
        SceneManager.LoadScene("Beach2Main");
    }

    public void Beach3()
    {
        GameManager.type = dungeonType.Beach3;
        SceneManager.LoadScene("Beach3Main");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void SceneLoader()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
