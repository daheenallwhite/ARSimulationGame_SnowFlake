using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S12UIController : MonoBehaviour {
    public Text textPopup;
    public GameObject OKButton;
    private string question = "\n이 퀘스트를 선택하시겠습니까?";
    private string alreadyDone = "어쩌죠?ㅠㅠ 이미 이 퀘스트를 한 적이 있네요..\n 필수퀘스트는 학기당 한번만\n수행할 수 있답니다! \n다른 퀘스트를 선택해주세요.";
    private string underSemester = "눈송이는 아직 이 퀘스트를 수행할만큼 자라지 않았어요!\n열심히 공부해서 다음에 플레이 해봐요~";
    private string textContents;
    private string selectedQuestScene="";
    private int semester;
    private int questCompleted;

	// Use this for initialization
	void Start () {
        //DB에서 학번에 맞는 semester값을 불러와서 변수에 저장
        semester = 3;
        //퀘스트 진행상황(questCompleted) playerprefs에 없다면 새로 만든다.
        PlayerPrefs.SetInt("questCompleted", 3);
        questCompleted = PlayerPrefs.GetInt("questCompleted");
        //if (!PlayerPrefs.HasKey("questCompleted"))
        //{
        //    PlayerPrefs.SetInt("questCompleted", 0);
        //}
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
        if(semester == 1 && questCompleted < 1) //학기가 1이고, 이 quest 해본 적이 없으면
        {
            textContents = "\'영어쓰기와읽기\' 강의를 들으려면 \n도서관 3층 302에서 책을 찾아야 해요!\n" + question;
            selectedQuestScene = "";
            
        } else if((semester == 1 && questCompleted == 1)|| semester > 1)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        } else if(semester < 1)
        {
            textContents = underSemester;
        } else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnNecessaryButton2Clicked()
    {
        if (semester == 2 && questCompleted < 2) //학기가 일치, 이 quest 해본 적이 없으면
        {
            textContents = "\'비판적사고와토론\' 강의를 들으려면 \n비, 사, 토 3개의 몬스터를 잡아야 해요!\n" + question;
            selectedQuestScene = "";
        }
        else if ((semester == 2 && questCompleted == 2) || semester > 2)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        }
        else if (semester < 2)
        {
            textContents = underSemester; selectedQuestScene = "";
        }
        else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);

    }

    public void OnNecessaryButton3Clicked()
    {
        if (semester == 3 && questCompleted < 3) //학기가 일치, 이 quest 해본 적이 없으면
        {
            textContents = "\'융합적사고와글쓰기\' 강의를 들으려면 \n도서관 사이트에서 논문검색을 해야 해요!\n" + question;
            selectedQuestScene = "S12N3";
            Debug.Log("t");
        }
        else if ((semester == 3 && questCompleted == 3) || semester > 3)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        }
        else if (semester < 3)
        {
            textContents = underSemester; selectedQuestScene = "";
        }
        else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnNecessaryButton4Clicked()
    {
        if (semester == 4 && questCompleted < 4) //학기가 일치, 이 quest 해본 적이 없으면
        {
            textContents = "\'영어토론과발표\' 강의를 들으려면 \n글로벌라운지로 가야 해요!\n" + question;
            selectedQuestScene = "S12N4";
        }
        else if ((semester == 4 && questCompleted == 4) || semester > 4)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        }
        else if (semester < 4)
        {
            textContents = underSemester; selectedQuestScene = "";
        }
        else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnNecessaryButton5Clicked()
    {
        if (semester == 4 && questCompleted < 4) //학기가 일치, 이 quest 해본 적이 없으면
        {
            textContents = "\'역량개발\' 강의를 들으려면 \n박물관을 가야 해요!\n" + question;
            selectedQuestScene = "";
        }
        else if ((semester == 5 && questCompleted == 5) || semester > 5)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        }
        else if (semester < 5)
        {
            textContents = underSemester; selectedQuestScene = "";
        }
        else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnNecessaryButton6Clicked()
    {
        if (semester == 4 && questCompleted < 4) //학기가 일치, 이 quest 해본 적이 없으면
        {
            textContents = "\'토익\' 자격증을 취득하려면 \n토익룡을 잡아야 해요!\n" + question;
            selectedQuestScene = "";
        }
        else if ((semester == 6 && questCompleted == 6) || semester > 6)
        {
            textContents = alreadyDone; selectedQuestScene = "";
        }
        else if (semester < 6)
        {
            textContents = underSemester; selectedQuestScene = "";
        }
        else
        {
            textContents = "오류";
        }
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnNecessaryButton7Clicked()
    {
        textContents = "\'컴퓨터활용\' 자격증을 취득하려면 \n엑셀 키 문제를 통과해야 해요!\n" + question;
        selectedQuestScene = "S12N7";
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnOptionalButton1Clicked()
    {
        textContents = "\'회계원리\' 강의를 수강하려면 \n순헌관 000으로 가야 해요!\n" + question;
        selectedQuestScene = "S12O1";
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnOptionalButton2Clicked()
    {
        textContents = "\'건강교육론\' 강의를 수강하려면 \n창학 000으로 가야 해요!\n" + question;
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnOptionalButton3Clicked()
    {
        textContents = "\'형법총론\' 강의를 수강하려면 \n진리관 000으로 가야 해요!\n" + question;
        selectedQuestScene = "S12O3";
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void OnOptionalButton4Clicked()
    {
        textContents = "\'보육학개론\' 강의를 수강하려면 \n명신관 000으로 가야 해요!\n" + question;
        ActivePopup(textContents, selectedQuestScene);
        
    }

    public void ActivePopup(string textContents, string selectedQuestScene)
    {
        textPopup.text = textContents;
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(true);
        if (selectedQuestScene == "")
        {
           OKButton.SetActive(false);
        }
        
    }

    public void OnCancelPopupClicked()
    {
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(false);
        selectedQuestScene = "";
    }

    public void OnOkPopupClicked()
    {
        SceneManager.LoadScene(selectedQuestScene);
    }
}
