using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int cellCount = 16;

    int[] pathID = { 1, 23, 24, 25, 47, 69, 70, 71, 93, 94, 95, 96,
                       97, 119, 141, 142, 164, 165, 166, 167,
                       189, 211, 212, 213, 214, 215, 193, 194,
                       195, 196, 197, 198};

    List<CellScript> AllCells = new List<CellScript>();

    public GameObject nodePref;
    public Transform nodesGroup;

    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
        CreatePath();
    }

    void CreateCells()
    {
        for(int i = 0; i < cellCount; i++)
        {
            for (int j = 0; j < cellCount; j++)
            {
                GameObject tmpCell = Instantiate(nodePref, Vector3.zero, nodePref.transform.rotation) as GameObject;
                tmpCell.transform.SetParent(nodesGroup, false);
                tmpCell.transform.localPosition = new Vector3(5 * j, 5 * i, 0);
                tmpCell.GetComponent<CellScript>().SetState(0);
                tmpCell.GetComponent<CellScript>().id = i + 1;
                AllCells.Add(tmpCell.GetComponent<CellScript>());
            }
        }
    }

    void CreatePath()
    {
        for (int i = 0; i < pathID.Length; i++)
            AllCells[pathID[i] - 1].SetState(1);
    }
}
