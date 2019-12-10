using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer icon;
    [SerializeField]
    private SpriteRenderer spriteCell;
    private int xCell, yCell;


    private void Start()
    {
        spriteCell = GetComponent<SpriteRenderer>();
        xCell = (int)transform.localPosition.x;
        yCell = (int)transform.localPosition.y;
    }

    private void OnMouseDown()
    {
        //if (icon.sprite != null)
        //    return;

        if(!this.isFlagged())
        {
            icon.sprite = GameManager.instance.currentMark;
            GameManager.instance.boardGame[xCell, yCell] = GameManager.instance.currentPlayer.id + 1;
            Debug.Log("Board x " + xCell + ",y : " + yCell + " - " + GameManager.instance.boardGame[xCell, yCell]);
            var lastMove = Tuple.Create(xCell, yCell);
            this.PostEvent(EventID.SwapPlayer, lastMove);
        }
    }

    public void SetColorSuggest()
    {
        spriteCell.color = new Color(1, 0, 0, 1);
    }

    public void SetColorDefault()
    {
        spriteCell.color = Color.white;
    }

    public bool isFlagged()
    {
        return GameManager.instance.boardGame[xCell, yCell] != 0;
    }
}
