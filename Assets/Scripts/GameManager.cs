using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Sprite currentMark;
    public Text boardText;
    public int[,] boardGame;

    [HideInInspector]
    public BasePlayer currentPlayer = null;
    public BasePlayer[] listPlayer;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = listPlayer[0];
        this.RegisterListener(EventID.SwapPlayer, (param) => SwapTurnPlayer((Tuple<int, int>) param));
    }

    private void SwapTurnPlayer(Tuple<int, int> lastMove)
    {
        currentPlayer.SaveLastMove(lastMove);

        Debug.Log("Swap Turn ");
        currentPlayer = currentPlayer.id == listPlayer[1].id ? listPlayer[0] : listPlayer[1];
        this.PostEvent(EventID.SwapMask, currentPlayer.id);
        ShowBoardText();
    }

    public void ShowBoardText()
    {
        boardText.text = "";

        int width = boardGame.GetUpperBound(0);
        int height = boardGame.GetUpperBound(1);
        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                if (j == height)
                    boardText.text += " " + boardGame[i, j] + "\n";
                else
                    boardText.text += " " + boardGame[i, j];
            }
        }
    }
}
