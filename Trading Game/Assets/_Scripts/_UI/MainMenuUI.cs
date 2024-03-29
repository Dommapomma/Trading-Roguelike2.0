using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    


    private void Awake()
    {
        
        playButton.onClick.AddListener(() =>
        {
            InitializeSeed(); 
            SceneLoader.Load(SceneLoader.Scene.MapScene);
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    private void InitializeSeed()
    {
        int seed;
        if (PlayerPrefs.HasKey("seed") == true)
        {
            seed = PlayerPrefs.GetInt("seed");
        }
        else
        {
            seed = Random.Range(1000000, 9999999);
        }
        Random.InitState(seed);
    }


}
