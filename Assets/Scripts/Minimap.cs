using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform Character_Main;

	private void LateUpdate()
	{
        Vector3 newPosition = Character_Main.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, Character_Main.eulerAngles.y, 0f);
	}
}
