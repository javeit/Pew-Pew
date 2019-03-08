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

    public interface IEngineData {}

    public class EngineData : IEngineData {

        public string sceneName;

        public EngineData(string sceneName) {

            this.sceneName = sceneName;
        }
    }

    public abstract class Engine : IEngine {

        TransitionManager _transitionManager;

        protected string sceneName;

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

        protected Engine(EngineData data) {
            sceneName = data.sceneName;
        }

        public virtual IEnumerator StartEngine(IEngine previousEngine) {

            yield return TransitionManager.BeginTransition(previousEngine.SceneName);

            InitGame();

            yield return TransitionManager.EndTransition(SceneName);

            StartGame();
        }

        public virtual IEnumerator StopEngine() {
            yield return null;
        }

        public virtual void InitGame() {
            EventManager.TriggerBroadcast<GameStateEvents>("GameStateEvent", GameStateEvents.InitGame);
        }

        public virtual void StartGame() {
            EventManager.TriggerBroadcast<GameStateEvents>("GameStateEvent", GameStateEvents.StartGame);
        }

        public virtual void PauseGame() {
            EventManager.TriggerBroadcast<GameStateEvents>("GameStateEvent", GameStateEvents.PauseGame);
        }

        public virtual void ResumeGame() {
            EventManager.TriggerBroadcast<GameStateEvents>("GameStateEvent", GameStateEvents.ResumeGame);
        }

        public virtual void StopGame() {
            EventManager.TriggerBroadcast<GameStateEvents>("GameStateEvent", GameStateEvents.StopGame);
        }
    }

    public enum GameStateEvents {
        InitGame,
        StartGame,
        PauseGame,
        ResumeGame,
        StopGame
    }
}