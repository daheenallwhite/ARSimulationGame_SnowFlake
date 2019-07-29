using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S2UIController : MonoBehaviour {
    [Header("CreateAccountPanel")]
    public InputField studentIDInput;
    public InputField passwordInput;
    public InputField nameInput;
    public Text textState;

    private string CreateUrl;
    // Use this for initialization
    void Start () {
        CreateUrl = "imyj0916.cafe24.com/CreateAccount.php";
        //기존의 모든 playerprefs값 지우기
        PlayerPrefs.DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSubmitButtonClicked()
    {
        int id = 0; int pw = 0;
        //학번이 숫자가 아니면, 학번이 7자리가 아니면
        if (!Int32.TryParse(studentIDInput.text, out id))
        {
            textState.text = "학번을 다시 입력해주세요. (7자리 숫자)";
        } else if(studentIDInput.text.Length != 7) {
            textState.text = "학번을 다시 입력해주세요. (7자리 숫자)";
        }
   
        //비밀번호 자리수가 6이 아니면, 비밀번호가 숫자가 아니면,,
        else if(!Int32.TryParse(passwordInput.text, out pw))
        {
            textState.text = "비밀번호가 숫자가 아닙니다. 6자리 숫자로 다시 입력해주세요"; 
        } else if(pw >=1000000 || pw <= 99999)
        {
            textState.text = "비밀번호를 6자리로 다시 입력해주세요.";
        }
        //이름
        else if(nameInput.text == "")
        {
            textState.text = "이름을 입력해주세요.";
        }
        else
        {
            StartCoroutine(CreateAccount());
        }
    }

    IEnumerator CreateAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("Input_user", studentIDInput.text);
        form.AddField("Input_pass", passwordInput.text);
        form.AddField("Input_Info", nameInput.text);

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        //성공 S, create 실패 F1, 이미 있는 id면 F2
        if (webRequest.text == "S\n")
        {
            PlayerPrefs.SetString("StudentID", studentIDInput.text);
            PlayerPrefs.SetString("Name", nameInput.text);
            SceneManager.LoadScene("S3");
        } else if(webRequest.text == "F1") //계정 생성 실패
        {
            textState.text = "계정을 생성하는데 실패했습니다. 다시 시도해주세요.";
        } else if(webRequest.text == "F2") //존재하는 아이디
        {
            textState.text = "이미 존재하는 아이디입니다.";
        }

        yield return null;
    }


}
