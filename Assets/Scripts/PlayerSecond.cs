using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecond : BasePlayer
{
    public override void SwapMask(int currentPlayer)
    {
        base.SwapMask(currentPlayer);
        FindStroke();
    }

    public override void FindStroke()
    {
        if (isFirstStroke & currentPlayer == id)
        {
            base.FindStroke();

            // Top Right
            int tempX = lastMoveX + 1;
            int tempY = lastMoveY + 1;
            SuggestStroke(tempX, tempY);

            // Top Left
            tempX = lastMoveX - 1;
            tempY = lastMoveY + 1;
            SuggestStroke(tempX, tempY);

            // Bottom Right
            tempX = lastMoveX + 1;
            tempY = lastMoveY - 1;
            SuggestStroke(tempX, tempY);

            // Bottom Left
            tempX = lastMoveX - 1;
            tempY = lastMoveY - 1;
            SuggestStroke(tempX, tempY);

            DefeatOrVictory();
        }
    }
}
