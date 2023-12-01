using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject manaNumberCounter;
    [SerializeField] private int manaCounterMoveAmount = 15;
    [SerializeField] private Slider healthBar;

    private void Start() {
        BobUpAndDown(manaNumberCounter);
    }
    public void UpdateVisual() {
        TextMeshProUGUI manaNumberText = manaNumberCounter.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        string manaString = player.GetMana().ToString() + "/" + player.GetMaxMana().ToString();
        manaNumberText.text = manaString;

        int healthBarValue = player.GetPlayerHealth();
        if (healthBarValue < 0) { healthBarValue = 0; }
        healthBar.value = healthBarValue;
        healthBar.maxValue = player.GetMaxPlayerHealth();
    }
    private void BobUpAndDown(GameObject gameObject){
        gameObject.transform.DOMoveY(manaNumberCounter.transform.position.y + manaCounterMoveAmount, 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

}
