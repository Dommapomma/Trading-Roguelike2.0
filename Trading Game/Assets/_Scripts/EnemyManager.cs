using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDamageable, IStatusEffectable {

    [SerializeField] private BaseEnemy enemyVariant;
    [SerializeField] private GameObject statusEffectParent;
    [SerializeField] private List<_SE_Base> statusEffects = new List<_SE_Base>();
    public static EnemyManager Instance {get; private set;}
    private EnemyVisual enemyVisual;
    [SerializeField] private float enemyTurnTimer = 3;
    private bool enemyTurn = false;
    public event EventHandler OnEnemyTurnOver;
    private int health;
    private int maxHealth;
    private void Awake() {
        Instance = this;
    }
    private void GameManager_OnEnemyTurnStart(object sender, EventArgs e)
    {
        enemyTurn = true;
        ApplyStatusEffects();
        enemyVisual.AttackAnimation();
        Attack();
    }

    private void Attack(){
        enemyVariant.RandomAttack();
    }
    void Start()
    {
        GameManager.Instance.OnEnemyTurnStart += GameManager_OnEnemyTurnStart;
        maxHealth = enemyVariant.GetMaxHealth();
        health = maxHealth;
        enemyVisual = enemyVariant.GetEnemyVisual();
    }

    public void Damage(int damageAmount){
        health -= damageAmount;
        if (health <= 0){
            GameManager.Instance.GameOver();
        } else {
            UpdateVisual();
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health >  maxHealth) { 
            health = maxHealth;
        }
        UpdateVisual();
    }
    private void UpdateVisual(){
        enemyVisual.UpdateVisual();
    }
    public int GetHealth(){
        return health;
    }
    public int GetMaxHealth(){
        return maxHealth;
    }
    public EnemyVisual GetEnemyVisual(){
        return enemyVisual;
    }

    private void Update() {
        if (enemyTurn == true){
            enemyTurnTimer -= Time.deltaTime;
            if (enemyTurnTimer < 0){
                enemyTurnTimer = 3;
                enemyTurn = false;
                OnEnemyTurnOver?.Invoke(this, EventArgs.Empty);
            }
        }
    }


    private void ApplyStatusEffects(){
        List<_SE_Base> effectsToRemove = new List<_SE_Base>();
        for (int i = statusEffects.Count - 1; i >= 0; i--){
            statusEffects[i].ApplyEffect();
        }
    }
    public void AddStatusEffect(_SE_Base statusEffect){ statusEffects.Add(statusEffect); }
    public void RemoveStatusEffect(_SE_Base statusEffect) { statusEffects.Remove(statusEffect); }

    public GameObject GetStatusEffectParent() { return statusEffectParent; }
    public List<_SE_Base> GetStatusEffectList() { return statusEffects; }
}
