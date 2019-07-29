using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class S8UIController : MonoBehaviour
{
    public Text textSemester;

    public Slider sliderGrade;
    public Text textGrade;
    public Slider sliderJi;
    public Text textJi;
    public Slider sliderDuk;
    public Text textDuk;
    public Slider sliderChe;
    public Text textChe;
    public Slider sliderStress;
    public Text textStress;

    public Text textName;
    
    private string CreateUrl;

    private const float maxGrade = 140f;
    private const float maxScore = 150f;
    private const float maxStress = 5f;

    private void Start()
    {
        //PlayerPrefs.SetString("StudentID", "1211916");
        //PlayerPrefs.SetString("Name", "이다흰");
        //이름
        textName.text = PlayerPrefs.GetString("Name") + " 눈송이";
        CallInitialMethod();

    }

    private void Update()
    {

    }

    private void CallInitialMethod()
    {
        StartCoroutine(SetInitialScore());
    }

    IEnumerator SetInitialScore()
    {
        CreateUrl = "imyj0916.cafe24.com/Main.php";
        WWWForm form = new WWWForm();
        form.AddField("user", PlayerPrefs.GetString("StudentID"));

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        string[] score = DivideData(webRequest.text); //총 7개(성공여부,지,덕,체,스트레스,이수학점,학기)

        Debug.Log(score.Length);


        int[] scoreInt = ConvertData(score);

        if(score[1] != null || score.Length == 7)
        {
            //slider valude: 0~1
            //지
            textJi.text = score[1] + "/100";
            sliderJi.value = (scoreInt[0] / maxScore);
            //덕
            textDuk.text = score[2] + "/100";
            sliderDuk.value = (scoreInt[1] / maxScore);
            //체
            textChe.text = score[3] + "/100";
            sliderChe.value = (scoreInt[2] / maxScore);

            //스트레스
            textStress.text = score[4] + "/5";
            sliderStress.value = (scoreInt[3] / maxStress);

            //이수학점
            textGrade.text = score[5] + "/140";
            sliderGrade.value = (scoreInt[4] / maxGrade);

            //학기
            textSemester.text = CalculateSemester(scoreInt[5]);
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

    private string CalculateSemester(int semester)
    {
        string s = "";
        switch (semester)
        {
            case 1:
                s = "1-1";
                break;
            case 2:
                s = "1-2";
                break;
            case 3:
                s = "2-1";
                break;
            case 4:
                s = "2-2";
                break;
            case 5:
                s = "3-1";
                break;
            case 6:
                s = "3-2";
                break;
            case 7:
                s = "4-1";
                break;
            case 8:
                s = "4-2";
                break;
        }
        return s;
    }

    public void OnMapButtonClicked()
    {
        SceneManager.LoadScene("S9");
    }

    public void OnSettingButtonClicked()
    {
        SceneManager.LoadScene("S10");
    }

    public void OnHelpButtonClicked()
    {
        SceneManager.LoadScene("S11");
    }

    public void OnQuestButtonClicked()
    {
        SceneManager.LoadScene("S12");
    }

    public void OnEventButtonClicked()
    {
        SceneManager.LoadScene("S13");
    }
}
