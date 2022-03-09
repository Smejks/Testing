using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> LightShotSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> HeavyShotSounds = new List<AudioClip>();
    [SerializeField] AudioSource audio0;
    [SerializeField] AudioSource audio1;

    void Start()
    {
    }

    void Update()
    {
    }

    public void PlayFireSound(float rate, float damage)
    {
        audio0.pitch = rate / 4;
        audio1.pitch = rate / 4;
        audio0.pitch = Mathf.Clamp(audio0.pitch, 0.5f, 1.2f);
        audio1.pitch = Mathf.Clamp(audio1.pitch, 0.5f, 1.2f);

        if (damage < 4) {
            audio0.PlayOneShot(LightShotSounds[Random.Range(0, LightShotSounds.Count)]);
        }
        else {
            audio0.volume = damage / 6;
            audio1.volume = 1 - damage / 12;
            if (audio0.isPlaying)
                audio0.Stop();
            if (audio1.isPlaying)
                audio1.Stop();
            audio0.PlayOneShot(HeavyShotSounds[0]);
            audio1.PlayOneShot(HeavyShotSounds[1]);
        }
    }
}
