using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S5UIController : MonoBehaviour {
    private string CreateUrl;

    void Start()
    {
        CreateUrl = "imyj0916.cafe24.com/CharacterSelection.php";
    }

    public void OnLeftButtonClicked()
    {
        SceneManager.LoadScene("S4");
    }

    public void OnSelectionButtonClicked()
    {
        //DB에 업데이트 지0 덕5 체10
        StartCoroutine(SelectCharacter());
    }

    IEnumerator SelectCharacter()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", PlayerPrefs.GetString("StudentID"));
        form.AddField("ji", "0");
        form.AddField("duk", "5");
        form.AddField("che", "10");

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
