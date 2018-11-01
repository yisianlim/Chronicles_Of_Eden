using UnityEngine;

internal class GameUtils
{
    // Return the closest enemy. 
    // Reference: https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html.
    public static GameObject FindClosestEnemy(GameObject[] gos, Vector3 currentPosition)
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = currentPosition;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    /// <summary>
    /// Creates a layer mask that includes the layers of the given numbers.
    /// </summary>
    /// <param name="layersToMask"></param>
    /// <returns></returns>
    public static int GenerateLayerMask(int[] layersToMask)
    {

        int mask = 0;
        foreach (int layer in layersToMask)
            mask += 1 << layer;

        return mask;

    }

}