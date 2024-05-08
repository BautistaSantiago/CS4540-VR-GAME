using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlaySoundOnRelease : MonoBehaviour
{
    public AudioClip soundClipOnRelease; // Audio clip to play on release
    public AudioClip soundClipDelayed; // Audio clip to play after a delay
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to the object if it doesn't exist
        if (!GetComponent<AudioSource>())
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Subscribe to release events from XR grab interactable
        GetComponent<XRGrabInteractable>().selectExited.AddListener((args) => OnRelease(args));
    }

    void OnRelease(SelectExitEventArgs args)
    {
        // Play the first audio clip immediately
        PlaySound(soundClipOnRelease);

        // Start a coroutine to play the second audio clip after a delay
        StartCoroutine(PlayDelayedSound(soundClipDelayed, 0.09f));
    }

    void PlaySound(AudioClip clip)
    {
        // Play the specified audio clip
        audioSource.clip = clip;
        audioSource.Play();
    }

    IEnumerator PlayDelayedSound(AudioClip clip, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the delayed audio clip
        PlaySound(clip);
    }
}