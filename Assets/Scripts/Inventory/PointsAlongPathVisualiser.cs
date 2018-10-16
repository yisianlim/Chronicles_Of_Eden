using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A path visualiser that draws an object at each point in the path.
/// </summary>
[CreateAssetMenu(fileName = "Points Along Path Visualiser", menuName = "Visualisers/Path Visualisers/Points Along Path Visualiser", order = 3)]
public class PointsAlongPathVisualiser : PathVisualiser
{

    private List<Transform> representatives = new List<Transform>();

    [SerializeField] Transform pointRepresentative; //The object that will be drawn at each point.

   
    public override void VisualisePath(Vector3[] path)
    {
        
        for(int i = 0; i < path.Length; i++)
        {

            //If there are not enough representatived to draw all the points along the path, instatiate more.
            if (representatives.Count <= i)
                representatives.Add(Instantiate(pointRepresentative) as Transform);

            Debug.Log(representatives[i]);

            representatives[i].gameObject.SetActive(true);
            representatives[i].position = path[i];

        }

    }

    public override void HidePath()
    {
        representatives.ForEach(r => r.gameObject.SetActive(false));
    }


}
