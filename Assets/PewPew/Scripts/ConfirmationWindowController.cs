using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RedTeam.PewPew {

    public class ConfirmationWindowController : MonoBehaviour {

        public GameObject promptWindow;
        public ButtonSelectionController selectionController;

        public Button confirmButton;
        public Button cancelButton;

        public void Show(Action confirmAction, Action cancelAction) {

            // Confirm Button
            {
                confirmButton.onClick.RemoveAllListeners();
                confirmButton.onClick.AddListener(() => confirmAction());

                EventTrigger.Entry pointerEnterEvent = new EventTrigger.Entry();

                pointerEnterEvent.eventID = EventTriggerType.PointerEnter;
                pointerEnterEvent.callback.AddListener((eventData) => selectionController.SelectButton(0));

                confirmButton.GetComponent<EventTrigger>().triggers.Add(pointerEnterEvent);
            }

            // Cancel Button
            {
                cancelButton.onClick.RemoveAllListeners();
                cancelButton.onClick.AddListener(() => {
                    cancelAction?.Invoke();
                    Hide();
                });

                EventTrigger.Entry pointerEnterEvent = new EventTrigger.Entry();

                pointerEnterEvent.eventID = EventTriggerType.PointerEnter;
                pointerEnterEvent.callback.AddListener((eventData) => selectionController.SelectButton(1));

                cancelButton.GetComponent<EventTrigger>().triggers.Add(pointerEnterEvent);
            }

            promptWindow.SetActive(true);

            selectionController.Init(new Button[] { confirmButton, cancelButton });
            selectionController.Enable();
        }

        public void Hide() {

            promptWindow.SetActive(false);

            selectionController.Disable();
        }
    }
}