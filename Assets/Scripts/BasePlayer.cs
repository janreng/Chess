using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer
{
    public int id;
    public Sprite iconMask;
    public int lastMoveX, lastMoveY;

    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(EventID.SwapMask, (param) => SwapMask((int) param));
    }

    public virtual void FindStroke()
    {
        Debug.Log("Find Stroke ...");
    }

    public virtual void Move()
    {
        Debug.Log("Move ...");
    }

    public void SwapMask(int currentPlayer)
    {
        if (currentPlayer == id)
            GameManager.instance.currentMark = iconMask;
    }

    public void SaveLastMove(Tuple<int, int> lastMove)
    {
        lastMoveX = lastMove.Item1;
        lastMoveY = lastMove.Item2;
    }
}
