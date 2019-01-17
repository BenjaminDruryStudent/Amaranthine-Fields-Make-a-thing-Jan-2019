using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBuilder : MonoBehaviour {

    public int spritePixelsX, spritePixelsY;
    
    public int xGridSize,yGridSize;
    public GameObject prefab;
    [SerializeField]
    GameObject[,] cards;
    public float xCardSize { get { return .01f * spritePixelsX; } }
    public float yCardSize { get { return .01f * spritePixelsY; } }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("Clear")]
    public void Remove()
    {
        Stack<GameObject> toRemove = new Stack<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            toRemove.Push(transform.GetChild(i).gameObject);
        }

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
        TileManager tileManager = GetComponent<TileManager>();

        cards = new GameObject[xGridSize,yGridSize];
        GameDataManager.cardDatas = new CardData[xGridSize, yGridSize];
        tileManager.cards = new SpriteRenderer[xGridSize * yGridSize];
        tileManager.cardData = new CardData[xGridSize * yGridSize];

        float xOffset = (((xCardSize * xGridSize) - xCardSize) / 2) * -1;
        float yOffset = ((yCardSize * yGridSize) - yCardSize) / 2;

        Debug.LogFormat("grid size X {0} | grid size Y {1} | Offset X {2} | Offset Y {3}",xCardSize,yCardSize, xOffset,yOffset);

        for (int y = 0; y < yGridSize; y++)
        {
            for (int x = 0; x < xGridSize; x++)
            {
                Vector3 pos = new Vector3(x * xCardSize + xOffset, ((y * yCardSize) * -1) + yOffset);
                GameObject newCard = Instantiate<GameObject>(prefab, pos, Quaternion.identity, transform);
                cards[x,y] = newCard;

                CardData data = newCard.GetComponent<CardData>();
                if (data != null)
                {
                    data.x = x;
                    data.y = y;
                }
                GameDataManager.cardDatas[x, y] = data;
                tileManager.cardData[x + (y * cards.GetLength(0))] = data;
                tileManager.cards[x + (y * cards.GetLength(0))] = newCard.GetComponent<SpriteRenderer>();
            }
        }
    }
}
