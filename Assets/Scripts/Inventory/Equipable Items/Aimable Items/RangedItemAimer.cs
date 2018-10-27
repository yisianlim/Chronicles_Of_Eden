using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A component to attach to the player that allows them to aim a ranged item when they use it.
/// </summary>
public class RangedItemAimer : MonoBehaviour {

    public static readonly int[] layersToIgnoreWhenAiming = new int[] { 13, 14 };
    
    private AimableItem itemBeingAimed;
    private Transform userTransform; //From where the item is being aimed.

    [SerializeField] Camera cam;
    [SerializeField] PlayerController player;
    [SerializeField] float waitTime;
    private MouseRotatedFocusingCamera mouseRotatedFocusingCamera;

    private void Start()
    {

        userTransform = GetComponent<Transform>();
        if (userTransform == null)
            throw new System.Exception(gameObject.name + " should have a transform attatched to it to use a RangedItemAimer.");

        mouseRotatedFocusingCamera = cam.GetComponent<MouseRotatedFocusingCamera>();

    }

    void Update () {

        if (itemBeingAimed == null) return; //If there is no item being aimed, don't do anything.

        //Try to find a point on the map the player is aiming at, and do nothing if it does not exist.
        Vector3 aimPoint = GetAimPoint();
        if (aimPoint.Equals(Vector3.positiveInfinity)) return;

        itemBeingAimed.VisualiseAim(userTransform, aimPoint);

        //When the user releases the mouse button again, fire the item, stop aiming, and unlock the camera.
        if (Input.GetMouseButtonUp(0)) {
            player.Fire();
            StartCoroutine(WaitThenFire(aimPoint));
            
        }

	}

    IEnumerator WaitThenFire(Vector3 aimPoint) {
        yield return new WaitForSeconds(waitTime);
        itemBeingAimed.Fire(userTransform, aimPoint);
        Debug.Log("fire");
        itemBeingAimed = null;
        if (mouseRotatedFocusingCamera != null)
            mouseRotatedFocusingCamera.lockRotation = false;
    }

    /// <summary>
    /// Initilaise the aiming of the given item.
    /// </summary>
    /// <param name="itemBeingAimed"></param>
    public void AimItem(AimableItem itemBeingAimed)
    {
        this.itemBeingAimed = itemBeingAimed;
        if(mouseRotatedFocusingCamera != null)
            mouseRotatedFocusingCamera.lockRotation = true;
    }

    /// <summary>
    /// Gets the point on the map that the user is aiming at with the mouse.
    /// </summary>
    /// <returns>The point on the map the mouse is over, or infinity if it is over nothing.</returns>
    private Vector3 GetAimPoint()
    {

        //Generate a ray from the camera to the mouse point.
        Ray cameraToMouseRay = cam.ScreenPointToRay(Input.mousePosition);

        //Cast the ray and determine the point on the map that it hits, if it hits anything.
        RaycastHit hit;
        if(!Physics.Raycast(cameraToMouseRay, out hit, Mathf.Infinity, ~GameUtils.GenerateLayerMask(layersToIgnoreWhenAiming))) return Vector3.positiveInfinity;
        return hit.point;

    }

}
