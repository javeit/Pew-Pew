using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ButtonSelectionController : MonoBehaviour {

    public RectTransform selectBox;

    Button[] _buttons;
    int _selectedIndex;
    bool _active;

    Coroutine checkInputCoroutine;

    public void Init(Button[] buttons, int initialSelected = 0) {

        _buttons = buttons;
        _selectedIndex = initialSelected;

        for(int i = 0; i < buttons.Length; i++) {

            InitButton(_buttons[i], i);
        }
    }

    public void Enable() {

        SelectButton(_selectedIndex);

        selectBox.gameObject.SetActive(true);

        checkInputCoroutine = StartCoroutine(CheckInput());
    }

    public void Disable() {

        if (checkInputCoroutine != null) {

            StopCoroutine(checkInputCoroutine);
            checkInputCoroutine = null;
        }

        selectBox.gameObject.SetActive(false);
    }

    public void SelectButton(int index) {

        _selectedIndex = index;

        selectBox.SetParent(_buttons[index].transform);

        selectBox.anchorMin = Vector2.zero;
        selectBox.anchorMax = Vector2.one;
        selectBox.sizeDelta = Vector2.zero;
        selectBox.anchoredPosition = Vector2.zero;
    }

    void InitButton(Button button, int selectionIndex) {

        EventTrigger.Entry pointerEnterEvent = new EventTrigger.Entry();

        pointerEnterEvent.eventID = EventTriggerType.PointerEnter;
        pointerEnterEvent.callback.AddListener((eventData) => SelectButton(selectionIndex));

        button.GetComponent<EventTrigger>().triggers.Add(pointerEnterEvent);
    }

    IEnumerator CheckInput() {

        yield return null;

        while (true) {

            if (Input.GetKeyDown("down") || Input.GetKeyDown("right")) {

                _selectedIndex = (_selectedIndex + 1) % _buttons.Length;

                SelectButton(_selectedIndex);

            } else if (Input.GetKeyDown("up") || Input.GetKeyDown("left")) {

                _selectedIndex--;

                if (_selectedIndex < 0)
                    _selectedIndex = _buttons.Length - 1;

                SelectButton(_selectedIndex);

            } else if (Input.GetKeyDown("return")) {

                _buttons[_selectedIndex].onClick.Invoke();
            }

            yield return null;
        }
    }
}
