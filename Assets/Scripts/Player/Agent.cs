using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    bool isMoving = false;

    protected void SetIsMoving(bool isMoving) { this.isMoving = isMoving; }
    public bool IsMoving { get { return isMoving; } } 

}
