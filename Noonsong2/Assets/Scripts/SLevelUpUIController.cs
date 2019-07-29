using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SLevelUpUIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnConfirmButtonClicked()
    {
        StartCoroutine(UpdateStatus());
        
    }

    IEnumerator UpdateStatus()
    {
        PlayerPrefs.SetString("StudentID", "1211916");
        //Debug.Log(PlayerPrefs.GetString("StudentID"));
        string id = PlayerPrefs.GetString("StudentID");
        string CreateUrl = "imyj0916.cafe24.com/LevelUp.php";

        WWWForm form = new WWWForm();
        form.AddField("user", id);
        form.AddField("semester", "1");

        WWW webRequest = new WWW(CreateUrl, form);
        yield return webRequest;

        Debug.Log(webRequest.text);

        if (webRequest.text == "S")
        {
            SceneManager.LoadScene("S8");
        }


        yield return null;
    }
}
