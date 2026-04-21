using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField PlayerNameInputField;
    [SerializeField] private TextMeshProUGUI BestScoreMenuText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (DataManager.Instance.PlayerName != "")
            BestScoreMenuText.text = $"Best Score : {DataManager.Instance.PlayerName} : {DataManager.Instance.PlayerScore}";
        else
            Debug.Log("No player name found in DataManager, best score will not be displayed.");
            Debug.Log($"Player name: {DataManager.Instance.PlayerName}");
            Debug.Log($"Player score: {DataManager.Instance.PlayerScore}");
            Debug.Log("Updating text object: " + BestScoreMenuText.name);
    }

    public void SaveCurrentPlayerName()
    {
        DataManager.Instance.CurrentPlayerName = PlayerNameInputField.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
