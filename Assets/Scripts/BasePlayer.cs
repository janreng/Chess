using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour, IPlayer
{
    public int id;
    public Sprite iconMask;
    public int lastMoveX, lastMoveY;
    public bool isFirstStroke = false;

    protected int width;
    protected int height;
    protected int currentPlayer;
    protected int countStroke = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(EventID.SwapMask, (param) => SwapMask((int) param));
        //this.RegisterListener(EventID.InitBoardSuccess, (param) => GetWidthHeightBoard());
    }

    public virtual void FindStroke()
    {
        GameManager.instance.board.ResetSuggest();
        countStroke = 0;
        Debug.Log("Find Stroke ...");
    }

    public virtual void SuggestStroke(int tempX, int tempY)
    {
        if(width == 0 || height == 0)
        {
            width = GameManager.instance.boardGame.GetUpperBound(0);
            height = GameManager.instance.boardGame.GetUpperBound(1);
        }

        if (0 <= tempX & tempX <= width & 0 <= tempY & tempY <= height)
        {
            Slot cell = GameManager.instance.board.getCell(tempX, tempY);
            if (!cell.isFlagged())
            {
                cell.SetColorSuggest();
                countStroke++;
            }
        }
        Debug.Log("Suggest Stroke ...");
    }

    public virtual void SwapMask(int currentPlayer)
    {
        if (currentPlayer == id)
            GameManager.instance.currentMark = iconMask;
        this.currentPlayer = currentPlayer;
    }

    public void SaveLastMove(Tuple<int, int> lastMove)
    {
        if (!isFirstStroke)
            SetFirstStroke();

        lastMoveX = lastMove.Item1;
        lastMoveY = lastMove.Item2;
    }

    public void SetFirstStroke()
    {
        isFirstStroke = true;
    }

    public void DefeatOrVictory()
    {
        if (countStroke == 0 && isFirstStroke)
        {
            string message = "Player " + (id+1) + " Lose...";
            this.PostEvent(EventID.EndGame, message);
        }
    }

    //private void GetWidthHeightBoard()
    //{
    //    width = GameManager.instance.boardGame.GetUpperBound(0);
    //    height = GameManager.instance.boardGame.GetUpperBound(1);
    //}
}
