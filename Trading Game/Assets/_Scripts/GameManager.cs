
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button endTurnButton;
    [SerializeField] private MatchOverUI gameOverVisual;
    //Only manages round numbers and changing rounds for now. Sends off event when new round happens.
    public static GameManager Instance;
    public event EventHandler OnPlayerTurnOver;
    public event EventHandler OnPlayerTurnStart;
    public event EventHandler OnEnemyTurnStart;
    [SerializeField] private int roundNumber;

    [SerializeField] private float gameStartTimer = 3;
    public enum BattleState{
        WaitingToStart,
        PlayerTurn,
        EnemyTurn,
        GameOver,
    }

    public BattleState battleState;

    private void Awake() {
        Instance = this;
        battleState = BattleState.WaitingToStart;
        
    }

    private void EnemyManager_OnEnemyTurnOver(object sender, EventArgs e)
    {
        battleState = BattleState.PlayerTurn;
        OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
    }

    private void Start() {
        endTurnButton.onClick.AddListener(EndPlayerTurn);
        EnemyManager.Instance.OnEnemyTurnOver += EnemyManager_OnEnemyTurnOver;
        gameOverVisual.gameObject.SetActive(false);
    }

    private void Update() {
        switch(battleState){
            case BattleState.WaitingToStart:
                gameStartTimer -= Time.deltaTime;
                if (gameStartTimer < 0){
                    battleState = BattleState.PlayerTurn;
                    OnPlayerTurnStart?.Invoke(this, EventArgs.Empty);
                }
                break;
            case BattleState.PlayerTurn:

                break;
            case BattleState.EnemyTurn:

                break;
            case BattleState.GameOver:
                break;
        }
    }

    public void EndPlayerTurn() {
        if (battleState == BattleState.PlayerTurn){
            OnPlayerTurnOver?.Invoke(this, EventArgs.Empty);
            roundNumber += 1;
            battleState = BattleState.EnemyTurn;
            OnEnemyTurnStart?.Invoke(this, EventArgs.Empty);
        }
    }
    public void GameOver(){
        Debug.Log("The Game is Over");
        battleState = BattleState.GameOver;
        gameOverVisual.gameObject.SetActive(true);
        if (Player.Instance.GetPlayerHealth() > 0)
        {
            gameOverVisual.SetGameOverText("You have defeated the Enemy!");
            PlayerSave.health = Player.Instance.GetPlayerHealth();
            PlayerSave.maxHealth = Player.Instance.GetMaxPlayerHealth();
        } else
        {
            gameOverVisual.SetGameOverText("You Died :(");
        }
        OnPlayerTurnOver?.Invoke(this, EventArgs.Empty);
    }
}
