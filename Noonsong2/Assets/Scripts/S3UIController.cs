using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S3UIController : MonoBehaviour {
    private string CreateUrl;

    void Start()
    {
        CreateUrl = "imyj0916.cafe24.com/CharacterSelection.php";
    }

    public void OnRightButtonClicked()
    {
        SceneManager.LoadScene("S4");
    }


    public void OnSelectionButtonClicked()
    {
        //DB에 업데이트 지10 덕0 체5
        StartCoroutine(SelectCharacter());
    }

    IEnumerator SelectCharacter()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", PlayerPrefs.GetString("StudentID"));
        form.AddField("ji", "10");
        form.AddField("duk", "0");
        form.AddField("che", "5");

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        //성공 S
        if (webRequest.text == "S")
        {
            SceneManager.LoadScene("S6");
        }
        

        yield return null;
    }
}
