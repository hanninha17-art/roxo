using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool gameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        if (gameOver) return;

        gameOver = true;

        gameOverPanel.SetActive(true);

        // Congela o jogo
        Time.timeScale = 0f;

        // Libera o cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Botão: Voltar ao Menu
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    // Botão: Repetir Fase
    public void RestartLevel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // Botão: Sair do Jogo
    public void ExitGame()
    {
        Time.timeScale = 1f;

        Application.Quit();

        // Funciona como alternativa no Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
