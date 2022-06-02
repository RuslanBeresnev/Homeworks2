using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ��������� �� ���� ���������
/// </summary>
public class GameOverMenuController : MonoBehaviour
{
    /// <summary>
    /// ��������� ������� ����
    /// </summary>
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitFromGame()
    {
        Application.Quit();
    }
}