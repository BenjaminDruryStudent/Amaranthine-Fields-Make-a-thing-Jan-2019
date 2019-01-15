using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuilder : MonoBehaviour {

    public int spritePixelsX, spritePixelsY;
    
    public int xGridSize,yGridSize;
    public GameObject prefab;
    GameObject[] cards;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("BuildCards")]
    public void BuildCards()
    {
        cards = new GameObject[xGridSize * yGridSize];

        GameObject newCard = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, transform);

        cards[0] = newCard;
    }
}
