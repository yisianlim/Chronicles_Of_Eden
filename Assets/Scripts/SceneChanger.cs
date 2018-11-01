using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string nextScene;
    public Animator sceneTransitionAnimator;

    public void FadeToScene() {
        sceneTransitionAnimator.SetBool("GameOver", true);
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(nextScene);
    }
}
