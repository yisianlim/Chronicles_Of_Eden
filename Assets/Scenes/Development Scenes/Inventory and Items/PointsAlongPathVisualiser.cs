using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A path visualiser that draws an object at each point in the path.
/// </summary>
public class PointsAlongPathVisualiser : PathVisualiser
{

    private List<GameObject> representatives = new List<GameObject>();

    [SerializeField] GameObject pointRepresentative; //The object that will be drawn at each point.

   
    public override void VisualisePath(Vector3[] path)
    {
        
        for(int i = 0; i < path.Length; i++)
        {

            //If there are not enough representatived to draw all the points along the path, instatiate more.
            if (representatives.Count <= i)
                representatives.Add(Instantiate(pointRepresentative));

            representatives[i].SetActive(true);
            representatives[i].transform.position = path[i];

        }

    }

    public override void HidePath()
    {
        representatives.ForEach(r => r.SetActive(false));
    }


}
