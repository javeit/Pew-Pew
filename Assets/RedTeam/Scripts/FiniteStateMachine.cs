using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    public class FiniteStateMachine<T, U> where T : Enum where U : Enum {

        T _currentState;

        Dictionary<FSMTransition<T, U>, T> _transitions;
        Dictionary<FSMTransition<T, U>, Action> _actions;

        public FiniteStateMachine(T startState) {

            _transitions = new Dictionary<FSMTransition<T, U>, T>();
            _actions = new Dictionary<FSMTransition<T, U>, Action>();
            _currentState = startState;
        }

        public void RegisterTransition(T fromState, U command, T toState, Action action = null) {

            FSMTransition<T, U> transition = new FSMTransition<T, U>(fromState, command);

            if (!_transitions.ContainsKey(transition)) {

                _transitions.Add(transition, toState);

                if(action != null)
                    _actions.Add(transition, action);

            } else {

                Debug.LogErrorFormat("Transition already registered: {0}, {1} -> {2}", transition.currentState, transition.command, toState);
            }

        }

        public void ExecuteCommand(U command) {

            FSMTransition<T, U> transition = new FSMTransition<T, U>(_currentState, command);

            if (_transitions.ContainsKey(transition)) {

                _currentState = _transitions[transition];

                if (_actions.ContainsKey(transition))
                    _actions[transition]();

            } else {

                Debug.LogErrorFormat("No transition registered for: {0}, {1} -> ?", transition.currentState, transition.command);
            }
        }

        public T GetCurrentState() {

            return _currentState;
        }
    }

    class FSMTransition<T, U> where T : Enum where U : Enum {

        public readonly T currentState;
        public readonly U command;

        public FSMTransition(T state, U command) {

            currentState = state;
            this.command = command;
        }

        public override int GetHashCode() {

            return currentState.GetHashCode() + command.GetHashCode();
        }

        public override bool Equals(object obj) {

            FSMTransition<T, U> otherTransition = obj as FSMTransition<T, U>;

            if (otherTransition == null)
                return false;

            return otherTransition.currentState.Equals(currentState) && otherTransition.command.Equals(command);
        }
    }
}