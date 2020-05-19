using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    enum TypeUI
    {
        MAIN,
        SEARCHPLAYER,
        LEVELFOUND,
        INGAME,
        WIN
    }

    TypeUI uiManager;

    public GameObject MainMenu;
    public GameObject InGame;
    public GameObject Win;
    public GameObject SearchPlayer;
    public GameObject SearchLevel;

    bool targetfound = false;
    bool levelfound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (uiManager)
        {
            case TypeUI.MAIN:
                ResetUI();
                MainMenu.SetActive(true);
                break;
            case TypeUI.INGAME:
                ResetUI();
                InGame.SetActive(true);
                break;
            case TypeUI.WIN:
                ResetUI();
                Win.SetActive(true);
                break;
            case TypeUI.SEARCHPLAYER:
                ResetUI();
                SearchPlayer.SetActive(true);
                break;
            case TypeUI.LEVELFOUND:
                ResetUI();
                SearchLevel.SetActive(true);
                break;
            default:
                uiManager = TypeUI.MAIN;
                break;
        }
    }

    public void ResetUI()
    {
        MainMenu.SetActive(false);
        SearchPlayer.SetActive(false);
        SearchLevel.SetActive(false);
        InGame.SetActive(false);
        Win.SetActive(false);
    }

    public void LetsGo()
    {
        uiManager = TypeUI.SEARCHPLAYER;
    }

    public void PlayerFound()
    {
        //TODO wait 3s and  then active bool and go to select song menu
    }

    public void SelectSong()
    {
        //TODO wait 3s and  then active bool and play song
    }

    public void MarcGalvez()
    {
        Application.OpenURL("https://www.linkedin.com/in/marc-g%C3%A1lvez-llorens-539938173/");
    }

    public void LluisMoreu()
    {
        Application.OpenURL("https://www.linkedin.com/in/llu%C3%ADs-moreu-farran/");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
