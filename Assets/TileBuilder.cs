using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuilder : MonoBehaviour {

    public int spritePixelsX, spritePixelsY;
    
    public int xGridSize,yGridSize;
    public GameObject prefab;
    GameObject[,] cards;
    public float xCardSize { get { return .01f * spritePixelsX; } }
    public float yCardSize { get { return .01f * spritePixelsY; } }

    // Use this for initialization
    void Start () {
        BuildCards();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    [ContextMenu("Clear")]
    public void Remove()
    {
        Stack<GameObject> toRemove = new Stack<GameObject>();
        for (int y = 0; y < yGridSize; y++)
        {
            for (int x = 0; x < xGridSize; x++)
            {
                toRemove.Push(cards[x, y]);
            }
        }

        cards = null;

        for (int i = toRemove.Count; i > 0; i--)
        {
            if (!Application.isPlaying)
            {
                DestroyImmediate(toRemove.Pop());
            }
            else
            {
                Destroy(toRemove.Pop());
            }
        }
    }

    [ContextMenu("BuildCards")]
    public void BuildCards()
    {
        cards = new GameObject[xGridSize,yGridSize];

        float xOffset = (((xCardSize * xGridSize) - xCardSize) / 2) * -1;
        float yOffset = ((yCardSize * yGridSize) - yCardSize) / 2;

        for (int y = 0; y < yGridSize; y++)
        {
            for (int x = 0; x < xGridSize; x++)
            {
                Vector3 pos = new Vector3(x * xCardSize + xOffset, ((y * yCardSize) * -1) + yOffset);

                GameObject newCard = Instantiate<GameObject>(prefab, pos, Quaternion.identity, transform);

                cards[x,y] = newCard;
            }
        }
    }
}
