using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    /// <summary>
    /// Controls the basic loading scene effects of a "Loading..." 
    /// animating text and a loading bar
    /// </summary>
    public class LoadingSceneController : MonoBehaviour {

        public Text loadingText;
        public Image loadingBar;

        public string[] loadingTextContents;
        public float loadingTextUpdateDuration;

        float loadingBarFullLength;

        Vector3 loadingBarLocalScale;

        IEnumerator UpdateLoadingText() {

            int loadingTextContentIndex = 0;

            while (true) {

                loadingText.text = loadingTextContents[loadingTextContentIndex];

                loadingTextContentIndex = (loadingTextContentIndex + 1) % loadingTextContents.Length;

                yield return new WaitForSecondsRealtime(loadingTextUpdateDuration);
            }
        }

        void UpdateLoadingBar(float progress) {

            progress = Mathf.Clamp01(progress);

            loadingBarLocalScale.x = loadingBarFullLength * progress;
            loadingBar.transform.localScale = loadingBarLocalScale;
        }

        void Awake() {

            loadingBarLocalScale = loadingBar.transform.localScale;
            loadingBarFullLength = loadingBarLocalScale.x;

            StartCoroutine(UpdateLoadingText());

            EventManager.AddBroadcastListener<float>("LoadingProgress", UpdateLoadingBar);
        }

        void OnDestroy() {

            EventManager.RemoveBroadcastListener<float>("LoadingProgress", UpdateLoadingBar);
        }
    }
}