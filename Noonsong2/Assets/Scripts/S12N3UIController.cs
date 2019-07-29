using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S12N3UIController : MonoBehaviour {
    public Text textStatus;
    public InputField inputAnswer;

    private int[] standardGrade = { 10, 10, 15, 15, 20, 20, 25, 25 };

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
        if (inputAnswer.text == "LION")
        {
            textStatus.text = "정답입니다!";
            Invoke("Success", 1.5f);
        } else
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
        textStatus.text = "힌트 : 4글자 영어 대문자입니다.";
    }

    public void Success()
    {
        GameObject.Find("Canvas").transform.FindChild("Success").gameObject.SetActive(true);
    }

    public void OnConfirmButtonClicked()
    {
        //db에 성공 내용 업데이트 후(stress=0) 메인화면으로 이동
        //levelup 조건 만족시 levelup scene으로 이동
        StartCoroutine(UpdateStatus());
    }

    IEnumerator UpdateStatus()
    {
        PlayerPrefs.SetString("StudentID", "1211916");
        //Debug.Log(PlayerPrefs.GetString("StudentID"));
        string id = PlayerPrefs.GetString("StudentID");
        string CreateUrl = "imyj0916.cafe24.com/Quest.php";

        WWWForm form = new WWWForm();
        form.AddField("user", id);
        form.AddField("ji", "5");
        form.AddField("duk", "0");
        form.AddField("che", "0");
        form.AddField("stress", "1");
        form.AddField("grade", "5");
        form.AddField("semester", PlayerPrefs.GetInt("semester"));
        form.AddField("qCompleted", "1");

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        // 성공여부/stress/grade/semester/qCompleted
        string[] results = DivideData(webRequest.text);
        // stress/grade/semester/qCompleted
        int[] resultsInt = ConvertData(results);
        int stress = resultsInt[0];
        int grade = resultsInt[1];
        int semester = resultsInt[2];
        int qCompleted = resultsInt[3];


        if (results[1] != null && results.Length == 5)
        {
            if(stress >=5) //정양실
            {
                SceneManager.LoadScene("S25");
            }

            if(semester == qCompleted && grade == standardGrade[semester-1])
            {
                SceneManager.LoadScene("SLevelUp");
            }
        }


        yield return null;
    }

    private string[] DivideData(string data)
    {
        char[] delimeter = { '/' };
        return data.Split(delimeter);
    }

    private int[] ConvertData(string[] score)
    {
        int[] scoreInt = new int[score.Length - 1];
        for (int i = 0; i < scoreInt.Length; i++)
        {
            Int32.TryParse(score[i + 1], out scoreInt[i]);
            //Debug.Log(scoreInt[i]);
        }
        return scoreInt;
    }
}
