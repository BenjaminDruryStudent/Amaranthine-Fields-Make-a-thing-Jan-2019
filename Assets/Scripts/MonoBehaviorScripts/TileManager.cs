using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public CardStateSO plantStates;

    public SpriteRenderer[] cards;
    public CardData[] cardData;

    [ContextMenu("UpdateCards")]
    public void UpdateCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].sprite = plantStates.stateSprites[cardData[i].state];
        }
    }
}
