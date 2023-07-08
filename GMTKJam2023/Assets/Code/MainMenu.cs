using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Button creditsCloseButton;

    public GameObject creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(HandleStartPressed);
        creditsButton.onClick.AddListener(HandleCreditsPressed);
        creditsCloseButton.onClick.AddListener(HandleCreditsClosePressed);
    }

    void HandleStartPressed()
    {
        SceneTransition.Instance.TransitionToScene(1);
    }

    void HandleCreditsPressed()
    {
        creditsMenu.SetActive(true);
    }

    void HandleCreditsClosePressed()
    {
        creditsMenu.SetActive(false);
    }
}
