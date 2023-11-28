using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OrbVisual : MonoBehaviour
{
    [SerializeField] private BaseOrb orb;
    public void AttackVisual(){
        Vector2 enemyPos = EnemyManager.Instance.GetEnemyVisual().transform.position;
        this.transform.DOMove(enemyPos, 1).SetEase(Ease.InSine).OnComplete(() => {
            Destroy(this.gameObject);
        });
    }
}
