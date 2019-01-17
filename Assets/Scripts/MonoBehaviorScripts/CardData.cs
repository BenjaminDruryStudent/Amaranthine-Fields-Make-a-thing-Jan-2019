using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {
    public int x;
    public int y;
    public int state;
    [HideInInspector]
    public float counter = -1;

    private void OnMouseDown()
    {
        if (state == 0)
        {
            state = 1;
            counter = 0;
        }else if (state == 5)
        {
            state = 6;
            counter = -1;
        }
        else
        {
            state = 0;
            counter = -1;
        }
    }

    public void UpdateCard(float time)
    {
        if (counter != -1)
        {
            counter += time;

            StateMachine();
        }
    }

    void StateMachine()
    {
        switch (state)
        {
            case 1:
                if (counter > 2)
                {
                    state = 2;
                    counter = 0;
                }
                break;
            case 2:
                if (counter > 3)
                {
                    state = 3;
                    counter = 0;
                }
                break;
            case 3:
                if (counter > 4)
                {
                    state = 4;
                    counter = 0;
                }
                break;
            case 4:
                if (counter > 5)
                {
                    state = 5;
                    counter = 0;
                }
                break;
            case 5:
                if (counter > 6)
                {
                    state = 6;
                    counter = -1;
                }
                break;
            default:
                break;
        }
    }
}
