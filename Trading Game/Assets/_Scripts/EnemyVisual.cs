using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Image enemySprite;
    private void Start() {
        BobUpAndDown(enemySprite.gameObject);
    }
    public void UpdateVisual(){
        int healthBarValue = EnemyManager.Instance.GetHealth();
        if (healthBarValue < 0) { healthBarValue = 0; }
        healthBar.value = healthBarValue;
        healthBar.maxValue = EnemyManager.Instance.GetMaxHealth();
    }
    private void BobUpAndDown(GameObject gameObject){
        gameObject.transform.DOMoveY(gameObject.transform.position.y + 15, 1).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
    }
    public void AttackAnimation(){
        enemySprite.gameObject.transform.DOMoveY(gameObject.transform.position.y - 400, 1).SetEase(Ease.InSine).SetLoops(2, LoopType.Yoyo);
    }
}
