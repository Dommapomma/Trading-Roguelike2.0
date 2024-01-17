using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IStatusEffectable
{
    #region variables
    [SerializeField] private GameObject statusEffectParent;
    [SerializeField] private List<_SE_Base> statusEffects = new List<_SE_Base>();
    public static Player Instance { get; private set; }
    [SerializeField] PlayerVisual playerVisual;

    //The three different locations that cards can be in during the game
    private List<List<BaseCard>> locations = new List<List<BaseCard>>();

    [SerializeField] public List<BaseCard> deck = new List<BaseCard>();
    [SerializeField] private List<BaseCard> discard = new List<BaseCard>();
    [SerializeField] private List<BaseCard> hand = new List<BaseCard>();
    [SerializeField] private GameObject handParent;
    [SerializeField] private GameObject deckParent;
    [SerializeField] private GameObject discardParent;

    //The possible starting cards, the game picks 10 random ones from this list of possibilities
    [SerializeField] private List<BaseCard> startingCards = new List<BaseCard>();

    //Parent gameobject of NRG orbs
    [SerializeField] private GameObject inventory;

    [SerializeField] private int handWidth = 1000;

    //The maximum hand size. When a round begins you draw this many into your hand from your deck
    private int drawHandSize = 5;
    //The mana amount and maximum mana amount. Spend mana to play cards
    [SerializeField] private int mana;
    [SerializeField] private int maxMana;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    #endregion variables

    private void Awake(){
        Instance = this;
    }
    private void Start() {
        GameManager.Instance.OnPlayerTurnOver += GameManager_OnPlayerTurnOver;
        GameManager.Instance.OnPlayerTurnStart += GameManager_OnPlayerTurnStart;

        locations.Add(hand);
        locations.Add(deck);
        locations.Add(discard);

        LoadCards();
        
        health = PlayerSave.health;
        maxHealth = PlayerSave.maxHealth;
    }

    private void GameManager_OnPlayerTurnStart(object sender, EventArgs e)
    {
        print("PlayerTurnStarting");
        ApplyStatusEffects();
        //Draws maxHandSize amount of cards
        DrawCards(drawHandSize);
        //regain mana
        mana = maxMana;
        playerVisual.UpdateVisual();
    }

    private void LoadCards()
    {
        List<BaseCard> intuitives = new List<BaseCard>();
        List<BaseCard> regulars = new List<BaseCard>();
        foreach (BaseCard card in PlayerSave.savedStartingCards) {
            if (card.IIntuitive)
            {
                intuitives.Add(Instantiate(card));
                continue;
            }
            regulars.Add(Instantiate(card));
        }
        while (intuitives.Count > 0) //add intuitive cards first at random
        {
            BaseCard removingCard = intuitives[UnityEngine.Random.Range(0, intuitives.Count)];
            intuitives.Remove(removingCard);
            deck.Add(removingCard);
            removingCard.transform.parent = deckParent.transform;
        }
        while (regulars.Count > 0)// add regular, non-intuitive cards next at random
        {
            BaseCard removingCard = regulars[UnityEngine.Random.Range(0, regulars.Count)];
            regulars.Remove(removingCard);
            deck.Add(removingCard);
            removingCard.transform.parent = deckParent.transform;
        }
    }

    #region debug stuff
            //nothing here
    #endregion
    //When a new round starts, we listen to the event
    private void GameManager_OnPlayerTurnOver(object sender, EventArgs e) {
        print("Player Turn Over");
        //remove any old cards from your hand
        int handLength = hand.Count;
        int persistants = 0;
        for (int x = 0; x < handLength; x ++) {
            if (hand[0].IPersistant == false)
            {
                Discard(hand[0 + persistants]);
            }
            else
            {
                persistants += 1;   
            }
        }
        playerVisual.UpdateVisual();
    }

    //Play a card, takes the index position of the card in the hand list. Plays the card and then discards it. If you do not have enough mana to play the card it does not let you play it
    public void PlayCard(int index = 0) {
        print("playing card number " + index);
        BaseCard activeCard = hand[index];
        if (mana + activeCard.GetManaCost() >= 0 && activeCard.IsPlayable()) {
            print("playing card");
            activeCard.PlayCard();
            playerVisual.UpdateVisual();
            DealWithCard(activeCard);//sorts consummable, exhaustable, and regular cards

            print("discard");
        } else {
            print("Not Enough Mana");
        }
    }

    #region card movement
    //Discard a card, receives a reference for a specific card (not the index) and moves it from the hand list to the discard list.
    //WILL NOT WORK FOR MOVING DECK CARDS TO DISCARD PILE
    private void Discard(BaseCard card){
        hand.Remove(card);
        discard.Add(card);
        card.Hide();
        UpdateCards();
        UpdateHandVisual();
        card.transform.parent = discardParent.transform;//don't forget the transform of the actual game object
    }
    //Add a check if no cards are in both the discard and deck (all in hand)
    //Draw cards from the deck into your hand. Receives an integer for how many cards to draw. If the deck contains no more cards, shuffle the discard into the deck.
    public void DrawCards(int numberDrawn) {
        for (int i = 0;  i < numberDrawn; i ++) {
            if (deck.Count == 0) {
                ShuffleCards();
                if (deck.Count == 0)
                {
                    print("no more cards left");
                    UpdateHandVisual();
                    return;
                }
            }
            BaseCard card = deck[0];
            deck.Remove(card);
            hand.Add(card);
            UpdateCards();
            card.transform.parent = handParent.transform;
        }
        UpdateHandVisual();
    }
    //Moves the cards from the discard to the deck randomly until all are in deck.
    private void ShuffleCards() {
        while (discard.Count > 0) {
            BaseCard removingCard = discard[UnityEngine.Random.Range(0, discard.Count)];
            discard.Remove(removingCard);
            deck.Add(removingCard);
            removingCard.transform.parent = deckParent.transform;
        }
    }
    
    private void UpdateCards() {
        foreach (List<BaseCard> location in locations) {
            foreach (BaseCard card in location) {
                card.SetIndex(location.IndexOf(card));
                card.SetLocation(location);
            }
        }
    }
    #endregion
    
    private void UpdateHandVisual() {
        for (int i = 0; i < hand.Count; i++) {
            int pos = handWidth/hand.Count;
            Vector3 vector3 = new Vector3(handParent.transform.position.x + (pos * i), handParent.transform.position.y);
            hand[i].transform.position = vector3;
            hand[i].Show();
        }
    }
    private void DealWithCard(BaseCard card)
    {
        if (card.IConsumable)
        {
            Type cardType = card.GetType();
            foreach (BaseCard saveCard in PlayerSave.savedStartingCards)
            {
                if (saveCard.GetType().Equals(cardType))
                {
                    PlayerSave.savedStartingCards.Remove(saveCard);
                    break;
                }
            }
            PlayerSave.savedStartingCards.Remove(card);
            hand.Remove(card);
            UpdateCards();
            UpdateHandVisual();
            Destroy(card.gameObject);
        } else if (card.IExhaustable) {
            hand.Remove(card);
            UpdateCards();
            UpdateHandVisual();
            Destroy(card.gameObject);
        } else
        {
            Discard(card);
        }
    }


    #region card functions
    //To be used by the cards, gains mana, takes in integer mana amount
    public void ChangeManaBy(int manaAmount) {
        mana += manaAmount;
    }
    public int GetMana(){
        return mana;
    }
    public int GetMaxMana() {
        return maxMana;
    }
    public void Damage(int damageAmount){
        health -= damageAmount;
        if (health <= 0){
            GameManager.Instance.GameOver();
            print("You have died");
        }
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public int GetPlayerHealth(){
        return health;
    }
    public int GetMaxPlayerHealth(){
        return maxHealth;
    }
    private void ApplyStatusEffects(){
        List<_SE_Base> effectsToRemove = new List<_SE_Base>();
        for (int i = statusEffects.Count - 1; i >= 0; i--){
            statusEffects[i].ApplyEffect();
        }
    }
    public void AddStatusEffect(_SE_Base statusEffect) { statusEffects.Add(statusEffect); }
    public void RemoveStatusEffect(_SE_Base statusEffect) { statusEffects.Remove(statusEffect); }
    public GameObject GetStatusEffectParent(){
        return statusEffectParent;
    }
    public List<_SE_Base> GetStatusEffectList(){
        return statusEffects;
    }

    #endregion
}
