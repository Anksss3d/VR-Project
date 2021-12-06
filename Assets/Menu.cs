using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    private AudioSource audio;

    public AudioClip startMusic;

    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
        audio = GetComponent<AudioSource>();
    }

    public void PlayStartButtonMusic(){
        AudioSource.PlayClipAtPoint(startMusic, transform.position, 1);
    }


    public void PlayMusic(){
        if(audio.isPlaying) return;
        audio.Play();
    }


    public void StopMusic(){
        audio.Stop();
    }

    public void StartGame(){
        SceneManager.LoadScene("Level1");
    }
}
