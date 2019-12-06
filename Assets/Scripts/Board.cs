using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width, height;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 tempPosition = new Vector3(i, j, 0);
                Instantiate(Resources.Load<GameObject>("Prefabs/Slot"), tempPosition, Quaternion.identity, this.transform);
                GameManager.instance.boardGame = new int[width, height];
                GameManager.instance.ShowBoardText();
            }
        }
    }
}
