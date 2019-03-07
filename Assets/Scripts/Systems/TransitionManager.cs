using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RedTeam {

    /// <summary>
    /// The TransitionManager is responsible for transitioning between the current scene and another scene smoothly, 
    /// using an image overlay to hide when the loading scene is loaded in and out and using the loading scene to 
    /// hide when the game scenes are being loaded in and out.
    /// </summary>
    public class TransitionManager : MonoBehaviour {

        public string loadingScene;
        public Image transitionOverlay;

        /// <summary>
        /// Transitions from the currently active scene to the scene specified by <paramref name="sceneName"/> by
        /// first loading an loading scene, using an overlay to cover when the loading scene is loaded in and out.
        /// </summary>
        /// <param name="sceneName">Scene name.</param>
        public IEnumerator TransitionTo(string sceneName) {

            string sceneToTransitionFrom = SceneManager.GetActiveScene().name;

            yield return FadeOut(1f, Color.black);

            yield return LoadScene(loadingScene);

            yield return FadeIn(1f, Color.black);

            yield return UnloadScene(sceneToTransitionFrom, (progress) => EventManager.TriggerBroadcast<float>("LoadingProgress", progress / 2f));

            yield return LoadScene(sceneName, (progress) => EventManager.TriggerBroadcast<float>("LoadingProgress", 0.5f + progress / 2f));

            yield return FadeOut(1f, Color.black);

            yield return UnloadScene(loadingScene);

            yield return FadeIn(1f, Color.black);
        }

        /// <summary>
        /// Additively loads the scene specified by <paramref name="sceneName"/> asyncronously, 
        /// triggering the <paramref name="progressCallback"/> every frame with the current progress (from 0 to 1)
        /// </summary>
        /// <param name="sceneName">Scene name.</param>
        /// <param name="progressCallback">Progress callback.</param>
        IEnumerator LoadScene(string sceneName, Action<float> progressCallback = null) {

            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!loadingOperation.isDone) {

                if (progressCallback != null)
                    progressCallback(loadingOperation.progress);

                yield return null;
            }
        }

        /// <summary>
        /// Unloads the scene specified by <paramref name="sceneName"/> asyncronously, 
        /// triggering the <paramref name="progressCallback"/> every frame with the current progress (from 0 to 1)
        /// </summary>
        /// <param name="sceneName">Scene name.</param>
        /// <param name="progressCallback">Progress callback.</param>
        IEnumerator UnloadScene(string sceneName, Action<float> progressCallback = null) {

            AsyncOperation loadingOperation = SceneManager.UnloadSceneAsync(sceneName);

            while (!loadingOperation.isDone) {

                if (progressCallback != null)
                    progressCallback(loadingOperation.progress);

                yield return null;
            }
        }

        /// <summary>
        /// Fades out the current scene (doesn't unload the scene) by fading in an image overlay
        /// </summary>
        /// <param name="duration">Duration.</param>
        /// <param name="color">Color.</param>
        IEnumerator FadeOut(float duration, Color color) {

            color.a = 0f;
            transitionOverlay.color = color;

            float startTime = Time.time;

            while(Time.time < startTime + duration) {

                color.a = (Time.time - startTime) / duration;
                transitionOverlay.color = color;

                yield return null;
            }
        }

        /// <summary>
        /// Fades in the current scene (doesn't load the scene) by fading out an image overlay
        /// </summary>
        /// <param name="duration">Duration.</param>
        /// <param name="color">Color.</param>
        IEnumerator FadeIn(float duration, Color color) {

            color.a = 1f;
            transitionOverlay.color = color;

            float startTime = Time.time;

            while (Time.time < startTime + duration) {

                color.a = 1f - (Time.time - startTime) / duration;
                transitionOverlay.color = color;

                yield return null;
            }
        }
    }
}