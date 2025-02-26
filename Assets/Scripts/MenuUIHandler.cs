using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;


public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public TMP_InputField UserNameInput;

    // Start is called before the first frame update
    private void Start()
    {
        if (RecordManager.Instance != null)
        {
            RecordManager.Instance.LoadRecord();
            if (RecordManager.Instance.Record > 0)
            {
                BestScoreText.text = "Best Score : " + RecordManager.Instance.Record + " by " + RecordManager.Instance.BestUserName;
            }
            else
            {
                BestScoreText.text = "Best Score : 0";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (string.IsNullOrEmpty(UserNameInput.text))
        {
            UserNameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Please enter your name!";
            return;
        }
        RecordManager.Instance.CurrentUserName = UserNameInput.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
