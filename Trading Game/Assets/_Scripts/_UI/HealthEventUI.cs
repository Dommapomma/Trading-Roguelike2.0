using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEventUI : MonoBehaviour
{
    [SerializeField] private Button healthButton;
    [SerializeField] private Button maxHealthButton;

    private void Start()
    {
        healthButton.onClick.AddListener(() =>
        {
            PlayerSave.health += 25;
            if (PlayerSave.health > PlayerSave.maxHealth)
            {
                PlayerSave.health = PlayerSave.maxHealth;
            }
            SceneLoader.Load(SceneLoader.Scene.MapScene);
        });
        maxHealthButton.onClick.AddListener(() => {
            PlayerSave.maxHealth += 5;
            PlayerSave.health += 5;
            SceneLoader.Load(SceneLoader.Scene.MapScene);
        });
    }
}
