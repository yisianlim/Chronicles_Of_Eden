using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

    public Transform NewMainCharacter;

	private void LateUpdate()
	{
        Vector3 newPosition = NewMainCharacter.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, NewMainCharacter.eulerAngles.y, 0f);
	}
}
