using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstract class for visualising a path described as a series of points.
/// </summary>
public abstract class PathVisualiser : ScriptableObject {

    /// <summary>
    /// Visulaises the path described by the point.
    /// </summary>
    /// <param name="path"></param>
    public abstract void VisualisePath(Vector3[] path);

    /// <summary>
    /// Has the path visulaisation no longer be displayed.
    /// </summary>
    public abstract void HidePath();

}
