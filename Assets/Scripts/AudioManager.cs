using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> AllSfxClips = new List<AudioClip>();

    public List<AudioClip> AllCharacterMusics = new List<AudioClip>();

    public string sfxFolder;
    public string musicsFolder;

    private Camera cam;

    private bool clipFound;

    private void OnEnable()
    {
        AddClipsToList(sfxFolder, AllSfxClips);
        AddClipsToList(musicsFolder, AllCharacterMusics);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void PlaySfx(GameObject sender, string clipName)
    {
        sender.AddComponent<AudioSource>().clip = GetClip(clipName);
        sender.GetComponent<AudioSource>().Play();
    }

    public void StopSfx(GameObject sender)
    {
        sender.GetComponent<AudioSource>().Stop();
        Destroy(sender.GetComponent<AudioSource>());
    }

    public void MainMusic()
    {
        foreach (AudioClip lMusic in AllCharacterMusics)
        {
            cam.gameObject.AddComponent<AudioSource>().clip = lMusic;
        }
    }

    AudioClip GetClip(string clipName)
    {
        foreach (AudioClip lClip in AllSfxClips)
        {
            if (clipName == lClip.name)
            {
                clipFound = true;
                return lClip;
            }
            else
                clipFound = false;

            if (!clipFound)
                Debug.Log("Audio Clip Not Found");
        }
        return null;
    }

    void AddClipsToList(string folder, List<AudioClip> list)
    {
        var audio = Resources.LoadAll(folder, typeof(AudioClip));

        foreach (var lAudio in audio)
            list.Add((AudioClip)lAudio);
    }
}