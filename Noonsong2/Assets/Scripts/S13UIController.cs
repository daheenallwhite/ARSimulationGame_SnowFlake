using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S13UIController : MonoBehaviour {
    public Text textPopup;
    public GameObject OKButton;
    private string question = "\n이 이벤트를 선택하시겠습니까?";
    private string underSemester = "눈송이는 아직 이 이벤트를 수행할만큼 자라지 않았어요!\n열심히 공부해서 다음에 플레이 해봐요~";
    private string[] semesterContents = { "선배님이 밥사주신대!\n지금 바로 순헌관 앞으로 가세요!", "숙명의 축제 청파제를 즐기자!\n만보기로 30걸음 이상 걸어야 해요!",
    "선배님의 피가되고 살이되는 덕담!\n지금 바로 000 앞으로 가세요!", "고뇌에 잠기며 순헌관에서 낚시를... \n순헌관 호수로 가서 물고기를 잡아요",
    "나도 이제 선배인데 후배에게 밥 사주자!\n지금 바로 000 앞으로 가세요!", "숙명의 축제 청파제를 즐기자!\n만보기로 30걸음 이상 걸어야 해요!",
    "취업설명회", "취업설명회"};
    private string[] semesterScene = {"", "S13S2", "", "", "", "S13S2", "", "" };
    private string[] repeatContents = {"술 마시기\n(스트레스가 -1 감소합니다)\n단, 술을 연속으로 3번 마시면 병이 날지도 몰라요ㅠㅠ (지나친 음주는 건강에 해롭습니다)\n",
    "영화 보기\n(스트레스가 -1 감소합니다)\n", "노래방 가기\n(스트레스가 -1 감소합니다)\n", "내일로 가기\n학교에서 00km 이상 떨어져야 해요!\n(스트레스가 -2 감소합니다)\n"};
    private string[] repeatScene = { "", "", "", "" };
    private string selectedEventScene = "";
    private int semester;
    private int questCompleted;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnSemesterButton1Clicked()
    {
        string textContents = "선배님이 밥사주신대!\n지금 바로 순헌관 앞으로 가세요!" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton2Clicked()
    {
        string textContents = "숙명의 축제 청파제를 즐기자!\n만보기로 30걸음 이상 걸어야 해요!" + question;
        ActivePopup(textContents);
        selectedEventScene = "S13S2";
    }

    public void OnSemesterButton3Clicked()
    {
        string textContents = "선배님의 피가되고 살이되는 덕담!\n지금 바로 000 앞으로 가세요!" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton4Clicked()
    {
        string textContents = "고뇌에 잠기며 순헌관에서 낚시를... \n순헌관 호수로 가서 물고기를 잡아요" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton5Clicked()
    {
        string textContents = "나도 이제 선배인데 후배에게 밥 사주자!\n지금 바로 000 앞으로 가세요!" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton6Clicked()
    {
        string textContents = "숙명의 축제 청파제를 즐기자!\n만보기로 30걸음 이상 걸어야 해요!" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton7Clicked()
    {
        string textContents = "취업설명회.." + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnSemesterButton8Clicked()
    {
        string textContents = "취업설명회.." + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    private void SetSemesterContentsAndScene(int eventNum)
    {

    }

    public void OnRepeatButton1Clicked()
    {
        string textContents = "술 마시기\n(스트레스가 -1 감소합니다)\n단, 술을 연속으로 3번 마시면 병이 날지도 몰라요ㅠㅠ" +
            "(지나친 음주는 건강에 해롭습니다)\n" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnRepeatButton2Clicked()
    {
        string textContents = "영화 보기\n(스트레스가 -1 감소합니다)\n" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnRepeatButton3Clicked()
    {
        string textContents = "노래방 가기\n(스트레스가 -1 감소합니다)\n" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    public void OnRepeatButton4Clicked()
    {
        string textContents = "내일로 가기\n학교에서 00km 이상 떨어져야 해요!\n(스트레스가 -2 감소합니다)\n" + question;
        ActivePopup(textContents);
        //selectedEventScene = ~~
    }

    private void ActivePopup(string textContents)
    {
        textPopup.text = textContents;
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(true);
    }

    public void OnCancelPopupClicked()
    {
        GameObject.Find("Canvas").transform.FindChild("Panel_Popup").gameObject.SetActive(false);
        selectedEventScene = "";
    }

    public void OnOkPopupClicked()
    {
        //해당하는 씬으로 이동 - selectedEventScene 변수 확인해서..
        SceneManager.LoadScene(selectedEventScene);
    }

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }
}
