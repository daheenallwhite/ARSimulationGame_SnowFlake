using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class S12Contoller : MonoBehaviour {
    public Text textPopup;
    public GameObject OKButton;
    private string question = "\n이 퀘스트를 선택하시겠습니까?";
    private string alreadyDone = "어쩌죠?ㅠㅠ 이미 이 퀘스트를 한 적이 있네요..\n 필수퀘스트는 학기당 한번만 수행할 수 있답니다! \n다른 퀘스트를 선택해주세요.";
    private string underSemester = "눈송이는 아직 이 퀘스트를 수행할만큼 자라지 않았어요!\n열심히 공부해서 다음에 플레이 해봐요~";
    private string[] necessaryContents = { "\'영어쓰기와읽기\' 강의를 들으려면 \n도서관 3층 302에서 책을 찾아야 해요!\n",
    "\'비판적사고와토론\' 강의를 들으려면 \n비, 사, 토 3개의 몬스터를 잡아야 해요!\n", "\'융합적사고와글쓰기\' 강의를 들으려면 \n도서관 사이트에서 논문검색을 해야 해요!\n",
    "\'영어토론과발표\' 강의를 들으려면 \n글로벌라운지로 가야 해요!\n", "\'역량개발\' 강의를 들으려면 \n박물관을 가야 해요!\n",
    "\'토익\' 자격증을 취득하려면 \n토익룡을 잡아야 해요!\n", "\'컴퓨터활용\' 자격증을 취득하려면 \n엑셀 키 문제를 통과해야 해요!\n"};
    private string[] necessaryScene = { "", "", "S12N3", "S12N4", "", "", "S12N7" };
    private string[] optionalContents = { "\'회계원리\' 강의를 수강하려면 \n순헌관 000으로 가야 해요!\n",
    "\'건강교육론\' 강의를 수강하려면 \n창학 000으로 가야 해요!\n", "\'형법총론\' 강의를 수강하려면 \n진리관 000으로 가야 해요!\n",
    "\'보육학개론\' 강의를 수강하려면 \n명신관 000으로 가야 해요!\n"};
    private string[] optionalScene = {"S12O1", "", "S12O3", ""};
    private string textContents;
    private string selectedQuestScene = "";
    private int semester;
    private int questCompleted;

    // Use this for initialization
    void Start () {
        //DB에서 학번에 맞는 semester값을 불러와서 변수에 저장

        StartCoroutine(GetSemester());
        //퀘스트 진행상황(questCompleted) playerprefs에 없다면 새로 만든다.
        
        
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }

    public void OnNecessaryButton1Clicked()
    {
        //Debug.Log(semester + "//" + questCompleted);
        SetNecessaryContentsAndScene(1);
    }

    public void OnNecessaryButton2Clicked()
    {
        SetNecessaryContentsAndScene(2);
    }

    public void OnNecessaryButton3Clicked()
    {
        SetNecessaryContentsAndScene(3);
    }

    public void OnNecessaryButton4Clicked()
    {
        SetNecessaryContentsAndScene(4);
    }

    public void OnNecessaryButton5Clicked()
    {
        SetNecessaryContentsAndScene(5);
    }

    public void OnNecessaryButton6Clicked()
    {
        SetNecessaryContentsAndScene(6);
    }

    public void OnNecessaryButton7Clicked()
    {
        SetNecessaryContentsAndScene(7);
    }

    private void SetNecessaryContentsAndScene(int questNum)
    {
        if (semester == questNum && questCompleted < questNum) //학기가 1이고, 이 quest 해본 적이 없으면
        {
            textContents = necessaryContents[questNum - 1] + question;
            selectedQuestScene = necessaryScene[questNum - 1];

        }
        else if ((semester == questNum && questCompleted == questNum) || semester > questNum) //이미 quest 해본적 있음
        {
            textContents = alreadyDone; selectedQuestScene = null;
            
        }
        else if (semester < questNum) //해당학기보다 높은 학기의 퀘스트
        {
            textContents = underSemester;
            selectedQuestScene = null;
            
        }
        else
        {
            textContents = "오류"; selectedQuestScene = null;
        }

        ActivePopup();
    }

    public void OnOptionalButton1Clicked()
    {
        
        textContents = optionalContents[0] +question;
        selectedQuestScene = optionalScene[0];
        ActivePopup();
    }

    public void OnOptionalButton2Clicked()
    {
        textContents = optionalContents[1] + question;
        selectedQuestScene = optionalScene[1];
        ActivePopup();
    }

    public void OnOptionalButton3Clicked()
    {
        textContents = optionalContents[2] + question;
        selectedQuestScene = optionalScene[2];
        ActivePopup();
    }

    public void OnOptionalButton4Clicked()
    {
        textContents = optionalContents[3] + question;
        selectedQuestScene = optionalScene[3];
        ActivePopup();
    }

    private void ActivePopup()
    {
        textPopup.text = textContents;
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(true);
        if (selectedQuestScene == null)
        {
            OKButton.SetActive(false);
        } else
        {
            OKButton.SetActive(true);
        }
    }

    public void OnCancelPopupClicked()
    {
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(false);
        selectedQuestScene = "";
    }

    public void OnOkPopupClicked()
    {
        PlayerPrefs.SetInt("semester", semester);
        PlayerPrefs.SetInt("questCompleted", questCompleted);
        SceneManager.LoadScene(selectedQuestScene);
    }

    IEnumerator GetSemester()
    {
        PlayerPrefs.SetString("StudentID", "1211916");
        Debug.Log(PlayerPrefs.GetString("StudentID"));
        string id = PlayerPrefs.GetString("StudentID");
        string CreateUrl = "imyj0916.cafe24.com/GetSemester.php";
        
        WWWForm form = new WWWForm();
        form.AddField("user", id);

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        string[] results = DivideData(webRequest.text);
        
        if (results[1] != null && results.Length == 3)
        {
            Int32.TryParse(results[1], out semester);
            Int32.TryParse(results[2], out questCompleted);
        }

        if (!PlayerPrefs.HasKey("questCompleted"))
        {
            PlayerPrefs.SetInt("questCompleted", questCompleted);
        }

        if (questCompleted != PlayerPrefs.GetInt("questCompleted"))
        {
            PlayerPrefs.SetInt("questCompleted", questCompleted);
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
