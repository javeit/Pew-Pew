using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RedTeam.PewPew {

    public class ConfirmationWindowController : MonoBehaviour {

        public GameObject promptWindow;
        public ButtonSelectionController selectionController;

        public Button confirmButton;
        public Button cancelButton;

        public Text confirmationText;

        public void Show(string confirmationMessage, Action confirmAction, Action cancelAction) {

            confirmationText.text = confirmationMessage;

            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(() => confirmAction());

            cancelButton.onClick.RemoveAllListeners();
            cancelButton.onClick.AddListener(() => {
                Hide();
                cancelAction?.Invoke();
            });

            promptWindow.SetActive(true);

            selectionController.Init(new Button[] { confirmButton, cancelButton });
            selectionController.Enable();
        }

        public void Hide() {

            //Debug.Log("Hide confirmation window");

            promptWindow.SetActive(false);

            selectionController.Disable();
        }
    }
}