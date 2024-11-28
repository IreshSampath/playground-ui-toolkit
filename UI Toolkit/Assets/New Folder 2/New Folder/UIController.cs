using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    VisualElement _bottomContainer;
    VisualElement _bottomPanel;
    VisualElement _darkPanel;
    VisualElement _boyImg;

    Button _openButton;
    Button _closeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var root =GetComponent<UIDocument>().rootVisualElement;

        _bottomContainer = root.Q<VisualElement>("Container_Bottom");
        _bottomPanel = root.Q<VisualElement>("Panel_Bottom");
        _darkPanel = root.Q<VisualElement>("Panel_Dark");
        _boyImg = root.Q<VisualElement>("Image_Man");

        _openButton = root.Q<Button>("Button_Open");
        _closeButton = root.Q<Button>("Button_Close");

        _bottomContainer.style.display = DisplayStyle.None;

        _openButton.RegisterCallback<ClickEvent>(OnOpenButtonClicked);
        _closeButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);

        Invoke("AnimateMan", 0.1f);
    }

    void OnOpenButtonClicked(ClickEvent evt)
    {
        _bottomContainer.style.display = DisplayStyle.Flex;
        _bottomPanel.AddToClassList("bottom-sheet-up");
        _darkPanel.AddToClassList("dark-fade-in");

    }

    void OnCloseButtonClicked(ClickEvent evt)
    {
        //_darkPanel.AddToClassList("dark-fade-Out");
        //_bottomPanel.AddToClassList("bottom-sheet-down");
        _darkPanel.RemoveFromClassList("dark-fade-in");
        _bottomPanel.RemoveFromClassList("bottom-sheet-up");

        StartCoroutine(CloseDelay());
    }

    IEnumerator CloseDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _bottomContainer.style.display = DisplayStyle.None;

    }

    void AnimateMan()
    {
        _boyImg.RemoveFromClassList("charactor-out");
    }
}
