using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    enum TypeUI
    {
        MAIN,
        INGAME,
        WIN
    }

    TypeUI uiManager;

    public GameObject MainMenu;
    public GameObject InGame;
    public GameObject Win;

    public bool targetfound = false;
    public bool levelfound = false;

    float timer_character = 0;
    float timer_level = 0;
    //ChargeMenu trailCharacter;
    //ChargeMenu trailLevel;
    public GameObject trailCharacterGO;
    public GameObject trailLevelGO;

    public Text Score;
    public Text FinalScore;
    public Text Grade;
    //public Text PreviewGrade;
    static public int score_value;

    AudioSource audio_source;
    public AudioClip start_wav;
    public bool game_over = false;

    public static int streak_combo;
    public Text Combo;

    void Start()
    {
        //trailCharacter = trailCharacterGO.GetComponent<ChargeMenu>();
        //trailLevel = trailLevelGO.GetComponent<ChargeMenu>();
        audio_source = GetComponent<AudioSource>();
    }

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
            default:
                uiManager = TypeUI.MAIN;
                break;
        }

        Score.text = "Score: " + score_value;
        if(streak_combo != 0 && streak_combo != 1)
        {
            Combo.text = "Combo x" + streak_combo;
        }
        else
            Combo.text = "";

        if (game_over)
        {
            uiManager = TypeUI.WIN;
            Grade.text = CalculeGrade(score_value);
            FinalScore.text = "FInal Score: " + score_value;
        }
    }

    public void ResetUI()
    {
        MainMenu.SetActive(false);
      
        InGame.SetActive(false);
        Win.SetActive(false);
    }

    public void LetsGo()
    {
        uiManager = TypeUI.INGAME;
        audio_source.clip = start_wav;
        audio_source.Play();
    }

    public void PlayerFound()
    {
        targetfound = true;
    }
    //public void PlayerFound()
    //{
    //    //TODO wait 2s and then active bool and go to select song menu
    //    // Particle effect
    //    timer_character += Time.deltaTime;
    //    trailCharacter._degree += 360 / 2 * Time.deltaTime;
    //    if (timer_character >= 2f)
    //    {
    //        targetfound = true;
    //        timer_character = 0;
    //        trailCharacterGO.SetActive(false);
    //        uiManager = TypeUI.LEVELFOUND;

    //    }

    //}
  
    //public void PlayerLost()
    //{
    //    timer_character = 0;
    //    trailCharacter.reset = true;
    //}
    public void SelectSong()
    {
        levelfound = true;
    }

    //public void SelectSong()
    //{
    //    //TODO wait 3s and  then active bool and play song
    //    timer_level += Time.deltaTime;
    //    trailLevel._degree += 360 / 2 * Time.deltaTime;
    //    if (timer_level >= 2f)
    //    {
    //        levelfound = true;
    //        timer_level = 0;
    //        trailLevelGO.SetActive(false);
    //        uiManager = TypeUI.INGAME;

    //    }
    //}
    //public void SelectSongLost()
    //{
    //    timer_level = 0;
    //    trailLevel.reset = true;
    //}

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

    public void ReturnMainMenu()
    {
        uiManager = TypeUI.MAIN;
        game_over = false;
    }

    public string CalculeGrade(int score)
    {
        if (score >= 0 && score < 550 )
        {
            return "F";
        }
        else if(score >= 550 && score < 900)
        {
            return "D";
        }
        else if (score >= 900 && score < 1400)
        {
            return "C";
        }
        else if (score >= 1400 && score < 1720)
        {
            return "B";
        }
        else if (score >= 1720 && score < 2000)
        {
            return "A";
        }
        else if (score >= 2000)
        {
            return "S";
        }
        else
        {
            return "A";
        }

    }

    public void ComboWombo()
    {


    }
}
