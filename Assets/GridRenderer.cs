using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRenderer : MonoBehaviour {
    public string displayText;

    private void OnValidate()
    {
        GetComponent<Text>().text = displayText;
    }
}
