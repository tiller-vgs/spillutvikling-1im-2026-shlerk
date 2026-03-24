using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    void Awake()
    {
        buttons[0].onClick.AddListener(LoadMainMenu);
        buttons[3].onClick.AddListener(QuitGame);
    }

    private void LoadMainMenu() { SceneManager.LoadSceneAsync("MainScene"); }
    private void QuitGame() { Application.Quit(); }
}
