using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string nextScene;
    public Animator sceneTransitionAnimator;

    public void FadeToLevel() {
        sceneTransitionAnimator.SetBool("FadeOut", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        FadeToLevel();
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(nextScene);
    }
}
