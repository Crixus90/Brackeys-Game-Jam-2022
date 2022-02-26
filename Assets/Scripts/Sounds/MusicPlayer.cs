using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
  
    //public AudioListener AudioListener;
    public AudioMixer mixer;
    public MusicPlayer instance;
    void Start()
    {
        if(instance != null){
            Destroy(this.gameObject);
        }else{
            instance  = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //AudioListener =  GetComponent<AudioSource>();
        //AudioListener.Play();
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void SetVolume(float sliderValue){
        mixer.SetFloat("vol",Mathf.Log10 (sliderValue) *20);
    }
    

    public IEnumerator FadeMusic ( float fadeTime, float volumeGoal) {
        float startVolume = AudioListener.volume;
 
        //float velocity = 0f;
        if(volumeGoal ==0){
            while (AudioListener.volume > volumeGoal) {
                AudioListener.volume -= (startVolume * Time.deltaTime / fadeTime);
                //AudioListener.volume = Mathf.SmoothDamp(AudioListener.volume, volumeGoal, ref velocity, fadeTime);

                yield return null;
            } 
        }else{
            while (AudioListener.volume < volumeGoal-.0001f) {
                AudioListener.volume += (volumeGoal * Time.deltaTime / fadeTime);
                //musicSource.volume = Mathf.SmoothDamp(musicSource.volume, volumeGoal, ref velocity, fadeTime);

                yield return null;
            } 
        }
    }
}
