using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SetupAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private string _folder;
        private List<AudioClip> _audioClips;

        public void StartLoad()
        {
            _audioClips = new List<AudioClip>(Resources.LoadAll<AudioClip>("Sound"));
            StartCoroutine(PlayMusic());
        }

        private IEnumerator PlayMusic()
        {
            while (true)
            {
                AudioClip clip = _audioClips[Random.Range(0, _audioClips.Count)];
                audioSource.clip = clip;
                audioSource.Play();
                yield return new WaitForSeconds(clip.length);
            }
        }
    }
}
