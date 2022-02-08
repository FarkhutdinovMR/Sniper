using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompeledWindow;
    [SerializeField] private GameObject _levelFailedWindow;
    [SerializeField] private Objective _objective;
    [SerializeField] private PlayerInput _playerInput;

    private const string Menu = "Menu";

    private void OnEnable()
    {
        _objective.Completed += OnCompleted;
        _objective.Failed += OnFailed;
    }

    private void OnDisable()
    {
        _objective.Completed -= OnCompleted;
        _objective.Failed -= OnFailed;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_01");
    }

    private void OnCompleted()
    {
        _levelCompeledWindow.SetActive(true);
        EndGame();
    }

    private void OnFailed()
    {
        _levelFailedWindow.SetActive(true);
        EndGame();
    }

    private void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        _playerInput.SwitchCurrentActionMap(Menu);
    }
}