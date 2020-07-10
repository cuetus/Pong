using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text DifficultyText;
    public Text RoundsText;
    public GameObject settings;

    private void Awake()
    {

        if(!GameObject.Find("Settings"))
        {
            GameObject newSettings = Instantiate(settings);
            newSettings.name = "Settings";
            DontDestroyOnLoad(newSettings);
        }
    }

    private void Start()
    {
        RoundsText.text = Settings.rounds.ToString();
    }

    public void ButtonRounds(bool more)
    {
        if (more && Settings.rounds < 20)
            Settings.rounds++;
        else if (!more && Settings.rounds > 3)
            Settings.rounds--;

        RoundsText.text = Settings.rounds.ToString();
    }

    public void Button1P()
    {
        SceneManager.LoadScene(1);
    }
    public void Button2P()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonDifficulty(bool right)
    {

        if (right)
        {
            switch(Settings.difficulty)
            {
                case Difficulty.Easy:
                    Settings.difficulty = Difficulty.Hard;
                    break;
                case Difficulty.Normal:
                    Settings.difficulty = Difficulty.Easy;
                    break;
                case Difficulty.Hard:
                    Settings.difficulty = Difficulty.Normal;
                    break;
            }
        }
        else
        {
            switch (Settings.difficulty)
            {
                case Difficulty.Easy:
                    Settings.difficulty = Difficulty.Normal;
                    break;
                case Difficulty.Normal:
                    Settings.difficulty = Difficulty.Hard;
                    break;
                case Difficulty.Hard:
                    Settings.difficulty = Difficulty.Easy;
                    break;
            }
        }

        if (Settings.difficulty == Difficulty.Easy)
            DifficultyText.text = "  Easy";
        else if (Settings.difficulty == Difficulty.Normal)
            DifficultyText.text = "Normal";
        else
            DifficultyText.text = "  Hard";
    }
}