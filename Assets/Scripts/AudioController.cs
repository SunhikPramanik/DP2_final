using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    public AudioClip deathClip;
    public AudioClip passClip;
    public float audioClipLength;

    public static AudioController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioClipLength = audioSource.clip.length;
        InvokeRepeating("OnCompletePlayNewMusic", 0f, audioClipLength);

    }

    // Update is called once per frame
    void Update()
    {
        //if(audioSource.clip == null) { audioSource.clip = clips[Random.Range(0, clips.Length)]; audioSource.Play(); }

        
    }

    public float OnCompletePlayNewMusic()
    {
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        Debug.Log(clips[Random.Range(0, clips.Length)]);
        audioSource.Play();
        audioClipLength = audioSource.clip.length;
        return audioClipLength;
    }
}
