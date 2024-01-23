using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDamageable, IStatusEffectable, IMissable {

    [SerializeField] private BaseEnemy defaultEnemyVariant;
    private BaseEnemy enemyVariant;
    [SerializeField] private GameObject statusEffectParent;
    [SerializeField] private List<_SE_Base> statusEffects = new List<_SE_Base>();
    public static EnemyManager Instance {get; private set;}
    [SerializeField] private List<int> missChances = new List<int>();
    public List<int> MissChances { get { return missChances; } }

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
        if (!MissedAction())
        {
            enemyVisual.AttackAnimation();
            Attack();
        }
        else
        {
            enemyVisual.MissAnimation();
        }
        
    }

    private void Attack(){
        enemyVariant.RandomAttack();
    }
    void Start()
    {
        GameManager.Instance.OnEnemyTurnStart += GameManager_OnEnemyTurnStart;
        CreateEnemy();
        health = maxHealth;
        
    }
    private void CreateEnemy()
    {
        if (EnemyType.enemyType != null)
        {
            enemyVariant = Instantiate(EnemyType.enemyType, this.gameObject.transform);
            enemyVisual = enemyVariant.GetEnemyVisual();
            maxHealth = enemyVariant.GetMaxHealth();
        }
        else
        {
            EnemyType.enemyType = defaultEnemyVariant;

            enemyVariant = Instantiate(EnemyType.enemyType, this.gameObject.transform);
            enemyVisual = enemyVariant.GetEnemyVisual();
            maxHealth = enemyVariant.GetMaxHealth();
        }
    }

    public void Damage(int damageAmount){
        health -= damageAmount;
        if (health <= 0){
            GameManager.Instance.GameOver();
            print("Enemy has died");
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

    public bool MissedAction()
    {
        foreach (int missChance in missChances)
        {
            //for each miss change, calculate if it misses
            if (UnityEngine.Random.Range(0, 101) < missChance){
                return true;
            }
        }
        return false;
    }
    public void AddMissChance(int chance)
    {
        missChances.Add(chance);
    }
    public void RemoveMissChance(int chance)
    {
        if (missChances.Contains(chance))
        {
            missChances.Remove(chance);
        }
        else
        {
            Debug.LogError("Error, trying to remove miss chance that does not exist");
        }
    }
}
