using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    void FindStroke();
    void SuggestStroke(int tempX, int tempY);
}
