using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S12N7UIController : MonoBehaviour {
    public Text textStatus;
    public InputField inputAnswer;

    // Use this for initialization
    void Start () {
        textStatus.text = "";
        Invoke("ShowCanvas", 1.5f);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void ShowCanvas()
    {
        GameObject.Find("Canvas").transform.FindChild("QuizPanel").gameObject.SetActive(true);
    }

    public void OnSubmitButtonClicked()
    {
        if (inputAnswer.text == "F4")
        {
            textStatus.text = "정답입니다!";
            Invoke("Success", 1.5f);
        }
        else
        {
            textStatus.text = "정답이 아닙니다. 다시 입력해주세요.";
        }
    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }

    public void OnHintButtonClicked()
    {
        textStatus.text = "힌트 : 영어대문자+숫자 총 두글자입니다.";
    }

    public void Success()
    {
        GameObject.Find("Canvas").transform.FindChild("Success").gameObject.SetActive(true);
    }

    public void OnConfirmButtonClicked()
    {
        //db에 성공 내용 업데이트 후(stress=0) 메인화면으로 이동
        SceneManager.LoadScene("S8");
    }
}
