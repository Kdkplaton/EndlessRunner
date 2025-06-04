using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource SceneryAudioSource;


    protected virtual void Awake()
    {
        base.Awake();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        SceneryAudioSource.loop = true;
    }

    public void Listener(string name)
    {
        AudioClip selected = LoadClip(name);
        effectAudioSource.PlayOneShot(selected);
    }

    AudioClip LoadClip(string name)
    {
        AudioClip loaded = Resources.Load<AudioClip>(string.Format("Audios/{0}", name));
        return loaded;
    }

    public void PlayBGM(string name)
    {
        // SceneryAudioSource.Stop();
        AudioClip selected = LoadClip(name);
        SceneryAudioSource.clip = selected;
        SceneryAudioSource.Play();
    }
    public void StopBGM()
    {
        SceneryAudioSource.Stop();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        PlayBGM(scene.name);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
