using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchOverUI : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TextMeshProUGUI gameOverText;


    private void Awake()
    {
        restartButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.MapScene);
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.MainMenuScene);
        });
    }
    public void SetGameOverText(string newGameOverText)
    {
        gameOverText.text = newGameOverText;
    }
}
