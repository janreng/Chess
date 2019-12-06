using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer icon;

    private void OnMouseDown()
    {
        if (icon.sprite != null)
            return;

        icon.sprite = GameManager.instance.currentMark;
        int x = (int)transform.localPosition.x;
        int y = (int)transform.localPosition.y;
        GameManager.instance.boardGame[x, y] = GameManager.instance.currentPlayer.id + 1;
        Debug.Log("Board x " + x + ",y : " + y + " - " + GameManager.instance.boardGame[x, y]);
        var lastMove = Tuple.Create(x, y);
        this.PostEvent(EventID.SwapPlayer, lastMove);
    }
}
