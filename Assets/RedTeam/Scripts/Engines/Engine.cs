using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    public interface IEngine {
        string SceneName { get; }
        IEnumerator StartEngine(IEngine previousEngine);
        IEnumerator StopEngine();
        void PauseGame();
        void ResumeGame();
    }

    public abstract class Engine : IEngine {

        TransitionManager _transitionManager;

        protected string sceneName;
        private EngineData data;

        public string SceneName {
            get {
                return sceneName;
            }
        }

        protected TransitionManager TransitionManager {

            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public Engine(EngineData data) {
            sceneName = data.sceneName;
        }

        public virtual IEnumerator StartEngine(IEngine previousEngine) {

            if (previousEngine != null)
                yield return TransitionManager.BeginTransition(previousEngine.SceneName);
            else
                yield return TransitionManager.BeginTransition();

            yield return TransitionManager.EndTransition(SceneName, InitGame);

            StartGame();
        }

        public virtual IEnumerator StopEngine() {
            yield return null;
        }

        public virtual void InitGame() {
            EventManager.TriggerBroadcast<GameEvent>("GameEvent", GameEvent.InitGame);
            Debug.Log("GameEvent: InitGame");
        }

        public virtual void StartGame() {
            EventManager.TriggerBroadcast<GameEvent>("GameEvent", GameEvent.StartGame);
            Debug.Log("GameEvent: StartGame");
        }

        public virtual void PauseGame() {
            EventManager.TriggerBroadcast<GameEvent>("GameEvent", GameEvent.PauseGame);
            Debug.Log("GameEvent: PauseGame");
        }

        public virtual void ResumeGame() {
            EventManager.TriggerBroadcast<GameEvent>("GameEvent", GameEvent.ResumeGame);
            Debug.Log("GameEvent: ResumeGame");
        }

        public virtual void StopGame() {
            EventManager.TriggerBroadcast<GameEvent>("GameEvent", GameEvent.StopGame);
            Debug.Log("GameEvent: StopGame");
        }
    }

    public enum GameEvent {
        InitGame,
        StartGame,
        PauseGame,
        ResumeGame,
        StopGame
    }
}