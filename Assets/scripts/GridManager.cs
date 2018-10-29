using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    Grid grid;
    public GameObject tile, grass, waypointGO;

    public Vector2[] waypointList;

	// Use this for initialization
	void Start () {
        waypointList = new Vector2[12];

        //Grid and path creation
        grid = new Grid(19, 11, tile);
        grid.FillRect(new Vector2(14,5), new Vector2(19,5), grass);
        grid.FillRect(new Vector2(14, 5), new Vector2(14, 9), grass);
        grid.FillRect(new Vector2(5, 9), new Vector2(14, 9), grass);
        grid.FillRect(new Vector2(5, 3), new Vector2(5, 9), grass);
        grid.FillRect(new Vector2(5, 3), new Vector2(8, 3), grass);
        grid.FillRect(new Vector2(8, 3), new Vector2(8, 7), grass);
        grid.FillRect(new Vector2(8, 7), new Vector2(11, 7), grass);
        grid.FillRect(new Vector2(11, 1), new Vector2(11, 7), grass);
        grid.FillRect(new Vector2(2, 1), new Vector2(11, 1), grass);
        grid.FillRect(new Vector2(2, 1), new Vector2(2, 6), grass);
        grid.FillRect(new Vector2(1, 6), new Vector2(2, 6), grass);
        grid.FillRect(new Vector2(1, 6), new Vector2(1, 11), grass);

        for (int i = 0; i < waypointGO.transform.childCount; i++)
        {
            waypointList[i] = waypointGO.transform.GetChild(i).position;
        }

        grid.Display();
    }
}
