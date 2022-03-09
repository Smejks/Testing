using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> LightShotSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> HeavyShotSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> HeatSinkSounds = new List<AudioClip>();
    [SerializeField] AudioSource audio0;
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioSource audio2;
    [SerializeField] AudioClip jackpot;
    [SerializeField] AudioClip resetSound;
    [SerializeField] AudioClip zip;

    void Start()
    {
    }

    void Update()
    {
    }

    public void PlayFireSound(float rate, float damage)
    {
        audio0.pitch = rate / 4 - damage / 12;
        audio1.pitch = rate / 4 - damage / 12;
        audio0.pitch = Mathf.Clamp(audio0.pitch, 0.5f, 1.2f);
        audio1.pitch = Mathf.Clamp(audio1.pitch, 0.5f, 1.2f);

        if (damage < 6) {
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

    public void PlayOverHeatSound()
    {
        audio2.pitch = 1;
        if (!audio2.isPlaying)
            audio2.PlayOneShot(HeatSinkSounds[0]);
    }

    public void PlayCoolDownCompleteSound()
    {
        if (audio2.isPlaying)
            audio2.Stop();
        audio2.pitch = 1;
        audio2.PlayOneShot(HeatSinkSounds[1]);
    }

    public void PlayPointSpawnSound()
    {
        audio2.pitch = 1;
        audio2.PlayOneShot(jackpot);
    }

    public void PlayStatsReadySound()
    {
        if (!audio0.isPlaying)
            audio0.pitch = 1;
        audio0.PlayOneShot(resetSound);
        audio2.pitch = 1;
        audio2.PlayOneShot(HeatSinkSounds[1]);
    }

    public void PlayZipSound()
    {
        audio0.pitch = 1;

        if (!audio0.isPlaying)
            audio0.PlayOneShot(zip);
    }

}
