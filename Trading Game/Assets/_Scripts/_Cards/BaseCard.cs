using System;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseCard : MonoBehaviour
{
    //Other card types inherit from this
    //just testing out polymorphism
    //could maybe be replaced by an interface, or maybe just add an interface in addition to this

    //All cards get their name and cost from their scriptable object. Each has their own script derived from this one as well


    protected CardSO cardSO; //never actually assigned
    [SerializeField] protected CardVisual visual;
    [SerializeField] protected Button button;

    [SerializeField]
    protected int index;
    [SerializeField]
    private List<BaseCard> location;
    
    protected void Start() {
        button.onClick.AddListener(TryPlayCard);
        SetUpCard();
    }

    public virtual void SetUpCard(){

    }
    public void SetIndex(int i) {
        index = i;
    }
    public void SetLocation(List<BaseCard> i) {
        location = i;
    }

    public void TryPlayCard() {
        Player.Instance.PlayCard(index);

    }
    //just example, always overriden by child classes
    public virtual void PlayCard() {
        Player.Instance.ChangeManaBy(cardSO.manaCost);
    }
    //get mana cost to play card. Not overriden by child classe.
    public int GetManaCost() {
        return cardSO.manaCost;
    }
    //get card name. Not overriden by child class.
    public string GetCardName() {
        return cardSO.cardName;
    }
    public string GetCardDescription() {
        return cardSO.cardDescription;
    }
    public void Show() {
        visual.gameObject.SetActive(true);
    }
    public void Hide() {
        visual.gameObject.SetActive(false);
    }
}