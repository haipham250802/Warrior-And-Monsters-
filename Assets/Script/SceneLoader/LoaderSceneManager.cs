using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoaderSceneManager : MonoBehaviour
{
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void LoadMap1()
    {
        SceneManager.LoadScene("Map_01");
    }
    public void LoadMap2()
    {
        SceneManager.LoadScene("Map_02");
    }
    public void LoadMap3()
    {
        SceneManager.LoadScene("Map_03");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
