using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// ���������� ��������� �� ���������� ����
/// </summary>
public class MainMenuController : MonoBehaviour
{
    public TMP_InputField chanceInputField;

    /// <summary>
    /// ��������� ������� �����
    /// </summary>
    public void StartGame()
    {
        if (chanceInputField.text != "")
        {
            GameProperties.AppearanceChance = float.Parse(chanceInputField.text) / 100f;
        }
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    public void QuitFromGame()
    {
        Application.Quit();
    }
}