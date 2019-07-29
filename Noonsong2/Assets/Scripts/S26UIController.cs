using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S26UIController : MonoBehaviour {
    private GameObject checker;
    private MeshRenderer checkMesh;
    private GameObject map;
   
    //순서: 순헌관   명신관   진리관  호수   행정관  측정중;
    public GameObject[] mapFlags = new GameObject[6];

    // Use this for initialization
    void Start () {
        checker = GameObject.Find("Checker");
        checkMesh = checker.GetComponent<MeshRenderer>();
        map = GameObject.Find("Canvas").transform.FindChild("Map").gameObject;

    }

    // Update is called once per frame
    void Update () {
        //게임 성공시 함수 호출
        if(checkMesh.enabled == true)
        {
            Invoke("Success", 2.0f);
        }

        //지도 gps
        if(map.activeSelf == true) //map이 활성화 되어있는 상태면
        {
            StartCoroutine("GetCoordinates");


            if (Input.location.lastData.latitude > 37.54629 && Input.location.lastData.latitude < 37.54667 && Input.location.lastData.longitude > 126.9642 && Input.location.lastData.longitude < 126.9653)
            {
                //순헌관
                //map.transform.FindChild("Flag_SBuilding").gameObject.SetActive(true);
                SetActiveMapFlag(0);
            }


            else if (Input.location.lastData.latitude > 37.54551 && Input.location.lastData.latitude < 37.54623 && Input.location.lastData.longitude > 126.9634 && Input.location.lastData.longitude < 126.9639)
            {
                //명신관
                //map.transform.FindChild("Flag_MBuilding").gameObject.SetActive(true);
                SetActiveMapFlag(1);


            }


            else if (Input.location.lastData.latitude > 37.54624 && Input.location.lastData.latitude < 37.54657 && Input.location.lastData.longitude > 126.9635 && Input.location.lastData.longitude < 126.9641)
            {
                //진리관
                //map.transform.FindChild("Flag_JBuilding").gameObject.SetActive(true);
                SetActiveMapFlag(2);


            }


            else if (Input.location.lastData.latitude > 37.54607 && Input.location.lastData.latitude < 37.54628 && Input.location.lastData.longitude > 126.9645 && Input.location.lastData.longitude < 126.9651)
            {
                //호수
                //map.transform.FindChild("Flag_Lake").gameObject.SetActive(true);
                SetActiveMapFlag(3);


            }

            //도서관은 테스트용 파일이므로 추후 삭제할 것
            else if (Input.location.lastData.latitude > 37.54381 && Input.location.lastData.latitude < 37.54457 && Input.location.lastData.longitude > 126.9657 && Input.location.lastData.longitude < 126.9664)
            {
                //도서관
                //map.transform.FindChild("Flag_HBuilding").gameObject.SetActive(true);
                SetActiveMapFlag(4);
            }

            else
            {
                //그외..
                //map.transform.FindChild("Panel_State").gameObject.SetActive(true);
              
                SetActiveMapFlag(5);
                
            }
            
        }
	}

    private void SetActiveMapFlag(int num)
    {
        for(int i = 0; i < mapFlags.Length; i++)
        {
            if(i == num)
            {
                mapFlags[i].SetActive(true);
            } else
            {
                if(mapFlags[i].activeSelf == true)
                {
                    mapFlags[i].SetActive(false);
                }
            }
        }
        
    }

    void Success()
    {
        GameObject.Find("Canvas").transform.FindChild("Success").gameObject.SetActive(true);
    }
    
    public void OnConfirmButtonClicked()
    {
        //db에 성공 내용 업데이트 후(stress=0) 메인화면으로 이동
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

    IEnumerator GetCoordinates()
    {
        //while true so this function keeps running once started.
        while (true)
        {
            // check if user has location service enabled
            if (!Input.location.isEnabledByUser)
                yield break;

            // Start service before querying location
            Input.location.Start(1f, .1f);

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                print("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                print("Unable to determine device location");
                yield break;
            }
            else
            {
                //calculate the distance between where the player was when the app started and where they are now.
                //GpsText.GetComponent<Text>().text = "GPS 위도: " + Input.location.lastData.latitude + " / 경도: " + Input.location.lastData.longitude;

            }
            Input.location.Stop();
        }
    }
}
