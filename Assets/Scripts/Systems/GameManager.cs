using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PewPew {

    public class GameManager : MonoBehaviour {

        public string mainMenuScene;

        private void Awake() {

            EventManager.Init();

            EventManager.AddRequest<GameManager>("GameManager", () => this);

            DontDestroyOnLoad(gameObject);
        }

        private void Start() {

            SceneManager.LoadSceneAsync(mainMenuScene);
        }

        private void OnDestroy() {

            EventManager.Clean();
        }
    }
}