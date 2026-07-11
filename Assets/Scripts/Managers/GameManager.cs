using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    public bool IsGameOver { get; private set; }

    private PlayerInputActions inputActions;
    private void Awake()
    {
        Time.timeScale = 1f;

        inputActions = new PlayerInputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void GameOver()
    {
        IsGameOver = true;

        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Botão clicado!");
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        if (!IsGameOver)
            return;

        if (inputActions.Player.Restart.WasPressedThisFrame())
        {
            RestartGame();
        }
    }
}