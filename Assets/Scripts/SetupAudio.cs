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
        private ResourceLoader<AudioClip> loader = new ResourceLoader<AudioClip>();

        public void StartLoad()
        {
            StartCoroutine(loader.Load(Setup, _folder));
        }
        private void Setup(IList<AudioClip> audioclips)
        {
            _audioClips = new List<AudioClip>(audioclips);
            StartCoroutine(PlayMusic());
        }
        private IEnumerator PlayMusic()
        {
            while (true)
            {
                AudioClip clip = _audioClips[Random.Range(0, _audioClips.Count)];
                audioSource.PlayOneShot(clip);
                yield return new WaitForSeconds(clip.length);
            }
        }

    }
}
