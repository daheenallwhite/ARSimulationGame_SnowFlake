using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S4UIController : MonoBehaviour {
    private string CreateUrl;

    void Start()
    {
        CreateUrl = "imyj0916.cafe24.com/CharacterSelection.php";
        //test 용
        //PlayerPrefs.SetString("StudentID", "1311333");
    }

    public void OnRightButtonClicked()
    {
        SceneManager.LoadScene("S5");
    }

    public void OnLeftButtonClicked()
    {
        SceneManager.LoadScene("S3");
    }

    public void OnSelectionButtonClicked()
    {
        //DB에 업데이트 지5 덕10 체0
        StartCoroutine(SelectCharacter());
    }

    IEnumerator SelectCharacter()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", PlayerPrefs.GetString("StudentID"));
        form.AddField("ji", "5");
        form.AddField("duk", "10");
        form.AddField("che", "0");

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        //성공 S, create 실패 F1, 이미 있는 id면 F2
        if (webRequest.text == "S")
        {
            SceneManager.LoadScene("S6");
        }


        yield return null;
    }
}
