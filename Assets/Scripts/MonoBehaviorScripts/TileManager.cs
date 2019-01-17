using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public CardStateSO plantStates;
    public Color[] colourStates;
    public SpriteRenderer[] cards;    
    public CardData[] cardData;

    private void Start()
    {
        GetComponent<TileBuilder>().BuildCards();
    }

    [ContextMenu("UpdateCards")]
    public void UpdateCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cardData[i].UpdateCard(Time.deltaTime);
            cards[i].sprite = plantStates.stateSprites[cardData[i].state];
            cards[i].color = colourStates[cardData[i].state];
        }
    }

    private void Update()
    {
        UpdateCards();
    }
}
