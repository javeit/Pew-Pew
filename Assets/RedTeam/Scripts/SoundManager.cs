using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    /// <summary>
    /// Handles sound playing requests using a pool of audio sources
    /// </summary>
    public class SoundManager : MonoBehaviour {

        public ObjectPool audioSourcePool;
        public List<AudioClip> clips;

        /// <summary>
        /// Determines if the requested audio clip exists and, if so, plays it
        /// through one of the pooled audio sources
        /// </summary>
        /// <param name="clipName"></param>
        /// <param name="clipParent"></param>
        /// <param name="clipLocalPos"></param>
        public void PlayAudioClip(string clipName, Transform clipParent, Vector3 clipLocalPos) {

            GameObject sourceGO = audioSourcePool.GetPooledObject();

            if (sourceGO == null || sourceGO.GetComponent<AudioSource>() == null) {
                Debug.Log("Error, no source");
                return;
            }

            AudioSource source = sourceGO.GetComponent<AudioSource>();

            AudioClip clip = clips.Find(c => c.name == clipName);

            if (clip == null) {

                Debug.LogError("Error: the audio clip specified does not exist");

            } else {

                sourceGO.transform.SetParent(clipParent);
                sourceGO.transform.localPosition = clipLocalPos;
                sourceGO.SetActive(true);
                StartCoroutine(PlayAudioClipCoroutine(source, clip));
            }
        }

        /// <summary>
        /// Determines if the requested audio clip exists and, if so, plays it
        /// through one of the pooled audio sources
        /// </summary>
        /// <param name="clipName"></param>
        /// <param name="clipParent"></param>
        public void PlayAudioClip(string clipName, Transform clipParent) {
            PlayAudioClip(clipName, clipParent, Vector3.zero);
        }

        /// <summary>
        /// Plays the specified audio clip through the specified audio source
        /// then returns the audio source to the object pool
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clip"></param>
        /// <returns></returns>
        IEnumerator PlayAudioClipCoroutine(AudioSource source, AudioClip clip) {

            source.clip = clip;
            source.Play();

            while (source.isPlaying)
                yield return null;

            audioSourcePool.ReturnToPool(source.gameObject);
        }
    }
}