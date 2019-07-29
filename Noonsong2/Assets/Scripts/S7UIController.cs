using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S7UIController : MonoBehaviour {
    public InputField studentIDInput;
    public InputField passwordInput;
    public Text textState;
    private string LoginUrl;

    void Start()
    {

        LoginUrl = "imyj0916.cafe24.com/Login.php";
        PlayerPrefs.DeleteAll();
    }

    public void OnSubmitButtonClicked()
    {
        int id = 0; int pw = 0;
        //학번이 숫자가 아니면, 글자수도 세고...
        if (!Int32.TryParse(studentIDInput.text, out id))
        {
            textState.text = "학번을 다시 입력해주세요. (7자리)";
        }
        else if (studentIDInput.text.Length != 7)
        {
            textState.text = "학번을 다시 입력해주세요. (7자리 숫자)";
        }

        //비밀번호 자리수가 6이 아니면, 비밀번호가 숫자가 아니면,,
        else if (!Int32.TryParse(passwordInput.text, out pw))
        {
            textState.text = "비밀번호가 숫자가 아닙니다. 6자리 숫자로 다시 입력해주세요";
        }
        else if (pw >= 1000000 || pw <= 99999)
        {
            textState.text = "비밀번호를 6자리로 다시 입력해주세요.";
        }
        else
        {
            StartCoroutine(LoginCo());
        }
        
    }

    IEnumerator LoginCo()
    {
        Debug.Log(studentIDInput.text);
        Debug.Log(passwordInput.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", studentIDInput.text);
        form.AddField("Input_pass", passwordInput.text);

        WWW webRequest = new WWW(LoginUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        char[] delimeter = { '/' };
        string result = webRequest.text;
        string[] words = result.Split(delimeter);
        Debug.Log(words[0]);
        Debug.Log(words[1]);

        // 로그인 성공 s , 아이디 안맞으면 f1, 비번 안맞으면 f2
        if (words[0] == "S")
        {
            PlayerPrefs.SetString("StudentID", studentIDInput.text);
            PlayerPrefs.SetString("Name", words[1]);
            SceneManager.LoadScene("S6");
        } else if(webRequest.text == "F1")
        {
            textState.text = "아이디가 일치하지 않습니다.";
        } else if(webRequest.text == "F2")
        {
            textState.text = "비밀번호가 일치하지 않습니다.";
        }

    }

    
}
