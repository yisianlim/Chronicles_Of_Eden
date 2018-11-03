using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    [SerializeField] SceneChanger changer;

    [SerializeField] AudioSource musicSource;
    [SerializeField] float fadeDuration;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter?");
        StartCoroutine(SoundFade());
        changer.FadeToScene();
    }

    /// <summary>
    /// Fades out music over given duration.
    /// </summary>
    /// <returns></returns>
    private IEnumerator SoundFade()
    {

        float time = 0;
        float startVol = musicSource.volume;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVol, 0, time / fadeDuration);
            
            yield return null;
        }

    }

}
