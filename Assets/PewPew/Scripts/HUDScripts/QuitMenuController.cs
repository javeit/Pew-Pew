using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class QuitMenuController : MonoBehaviour {

        public GameObject menu;

        public void Quit() {

            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        public void Open() {

            menu.SetActive(true);
        }

        public void Cancel() {

            menu.SetActive(false);
        }
    }
}