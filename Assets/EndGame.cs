using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    [SerializeField] SceneChanger changer;

    private void OnTriggerEnter(Collider other)
    {
        changer.FadeToScene();
    }

}
