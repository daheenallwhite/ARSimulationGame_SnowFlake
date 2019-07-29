using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S12O3UIController : MonoBehaviour {
    private GameObject checker;
    private MeshRenderer checkMesh;
    private GameObject map;
    private bool successActivated = false;

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("Checker");
        checkMesh = checker.GetComponent<MeshRenderer>();
        map = GameObject.Find("Canvas").transform.FindChild("Map").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //게임 성공시 함수 호출
        if (checkMesh.enabled == true)
        {
            if(!successActivated)
            {
                successActivated = true;
                Invoke("Success", 2.0f);
            }
            
        }

    }

    void Success()
    {
        GameObject.Find("Canvas").transform.FindChild("Success").gameObject.SetActive(true);
    }

    public void OnConfirmButtonClicked()
    {
        //db에 성공 내용 업데이트 후 메인화면으로 이동
        SceneManager.LoadScene("S8");
    }

    public void OnExitButtonClicked()
    {
        //db 업데이트 없이 메인으로 이동
        SceneManager.LoadScene("S8");
    }

    public void OnMapButtonClicked()
    {
        map.SetActive(!map.activeSelf);
    }

    public void OnMapExitButtonClicked()
    {
        map.SetActive(false);
    }
}
