using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width, height;
    public List<Slot> listCell;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 tempPosition = new Vector3(i, j, 0);
                Slot cell = Instantiate(Resources.Load<Slot>("Prefabs/Slot"), tempPosition, Quaternion.identity, this.transform);
                listCell.Add(cell);
                GameManager.instance.boardGame = new int[width, height];
                GameManager.instance.ShowBoardText();
            }
        }
        //this.PostEvent(EventID.InitBoardSuccess);
    }

    public Slot getCell(int x, int y)
    {
        foreach(Slot cell in listCell)
        {
            if (cell.transform.localPosition.x == x & cell.transform.localPosition.y == y)
                return cell;
        }
        return null;
    }

    public void ResetSuggest()
    {
        foreach (Slot cell in listCell)
        {
            cell.SetColorDefault();
        }
    }
}
