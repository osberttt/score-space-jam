using Helpers;
using System.Collections;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _musicSource1;
    [SerializeField] private AudioSource _musicSource2;
    [SerializeField] private AudioSource _sfxSource;

    //[SerializeField] private float _fadeTime = 0f;

    public void PlayMusicClip(Sound sound)
    {
        if (sound.clip == _musicSource1.clip)
            return;
        _musicSource1.clip = sound.clip;
        _musicSource1.loop = true;
        _musicSource1.Play();    
    }
    
    public void PlayMusicClipWithReverb(Sound sound, float reverbTime)
    {
        //StartCoroutine(ReverbCo(sound, reverbTime));
        PlayMusicClip(sound);
    }
   
    IEnumerator ReverbCo(Sound sound, float reverbTime)
    {
        while (true)
        {
            _musicSource1.clip = sound.clip;
            _musicSource1.Play();
            yield return new WaitForSeconds(sound.clip.length - reverbTime);

            _musicSource2.clip = sound.clip;
            _musicSource2.Play();
            yield return new WaitForSeconds(sound.clip.length - reverbTime);

        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawntransform, float volume)
    {
        AudioSource audioSource = Instantiate(_sfxSource, spawntransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
            
    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawntransform, float volume)
    {
        if (audioClip.Length==0){
            return;
        }
        int randomIndex = UnityEngine.Random.Range(0, audioClip.Length);
        PlaySoundFXClip(audioClip[randomIndex], spawntransform, GetSfxVolume() * volume);
    }

    public void SetMusicVolume(float volume)
    {
        _musicSource1.volume = Mathf.Clamp(volume, 0f, 1f);
    }

    public void SetSfxVolume(float volume)
    {
        _sfxSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }

    public float GetMusicVolume()
    {
        return _musicSource1.volume;
    }

    public float GetSfxVolume()
    {
        return _sfxSource.volume;
    }

    public void StopMusic()
    {
        _musicSource1.Stop();
    }
}
