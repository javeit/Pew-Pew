using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectionController : MonoBehaviour {

    public RectTransform selectBox;

    Button[] _buttons;
    int _selectedIndex;
    bool _active;

    public void Init(Button[] buttons, int initialSelected = 0) {

        _buttons = buttons;
        _selectedIndex = initialSelected;
    }

    public void Enable() {

        SelectButton(_selectedIndex);

        _active = true;
        selectBox.gameObject.SetActive(true);
    }

    public void Disable() {

        _active = false;
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

    void Update() {

        if (!_active)
            return;

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
    }
}
