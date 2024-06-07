using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public Button winRestartButton;
    public Button winReturnToMenuButton;
    public Button loseRestartButton;
    public Button loseReturnToMenuButton;

    void Start()
    {
        // 初始化界面为隐藏状态
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        // 为按钮添加点击事件
        winRestartButton.onClick.AddListener(RestartGame);
        winReturnToMenuButton.onClick.AddListener(ReturnToMenu);
        loseRestartButton.onClick.AddListener(RestartGame);
        loseReturnToMenuButton.onClick.AddListener(ReturnToMenu);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        losePanel.SetActive(false);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0); // 使用场景编号 0 返回主菜单
    }
}
