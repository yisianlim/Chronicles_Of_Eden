using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string nextScene;
    public Animator sceneTransitionAnimator;

    private void FadeToLevel() {
        sceneTransitionAnimator.SetTrigger("FadeOut");
    }

    private void OnTriggerEnter(Collider other)
    {
        FadeToLevel();
    }

    private void OnFadeComplete() {
        SceneManager.LoadScene(nextScene);
    }
}
