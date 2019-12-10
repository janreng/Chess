using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFirst : BasePlayer
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

            // Right
            int tempX = lastMoveX + 1;
            int tempY = lastMoveY;
            SuggestStroke(tempX, tempY);
            
            // Left
            tempX = lastMoveX - 1;
            tempY = lastMoveY;
            SuggestStroke(tempX, tempY);

            // Top
            tempX = lastMoveX;
            tempY = lastMoveY + 1;
            SuggestStroke(tempX, tempY);

            // Bottom
            tempX = lastMoveX;
            tempY = lastMoveY - 1;
            SuggestStroke(tempX, tempY);

            DefeatOrVictory();
        }
    }

}
