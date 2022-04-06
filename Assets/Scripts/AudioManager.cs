using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    protected AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    public void Play(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }

    public bool isPlaying()
    {
        return _source.isPlaying;
    }

    public void Pause()
    {
        _source.Pause();
    }

    public void unPause()
    {
        _source.UnPause();
    }

    public void Loop()
    {
        _source.loop = true;
    }

    public void unLoop()
    {
        _source.loop = false;
    }
}
