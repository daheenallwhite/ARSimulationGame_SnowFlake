using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GpsScript : MonoBehaviour
{

    private GameObject GpsText;
    private GameObject locationText;
    private GameObject GpsButtonText;

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
                GpsText.GetComponent<Text>().text = "GPS 위도: " + Input.location.lastData.latitude + " / 경도: " + Input.location.lastData.longitude;

            }
            Input.location.Stop();
        }
    }

 

    void Start()
    {
        GpsText = GameObject.FindGameObjectWithTag("GPSText");
        locationText = GameObject.FindGameObjectWithTag("locationText");
        // GpsSucessButton.GetComponent<Button>().enabled = false;
        GpsButtonText = GameObject.FindGameObjectWithTag("GpsButtonText");
        Screen.SetResolution(2560,1440,true);
    }

    void Update()
    {
        //gps를 늦게 켜도 작동이 되도록
        StartCoroutine("GetCoordinates");


        if (Input.location.lastData.latitude > 37.54629 && Input.location.lastData.latitude < 37.54667 && Input.location.lastData.longitude > 126.9642 && Input.location.lastData.longitude < 126.9653)
        {
            locationText.GetComponent<Text>().text = "현재위치: 순헌관";
        }


        else if (Input.location.lastData.latitude > 37.54551 && Input.location.lastData.latitude < 37.54623 && Input.location.lastData.longitude > 126.9634 && Input.location.lastData.longitude < 126.9639)
        {
            locationText.GetComponent<Text>().text = "현재위치: 명신관";
        }


        else if (Input.location.lastData.latitude > 37.54624 && Input.location.lastData.latitude < 37.54657 && Input.location.lastData.longitude > 126.9635 && Input.location.lastData.longitude < 126.9641)
        {
            locationText.GetComponent<Text>().text = "현재위치: 진리관";
        }


        else if (Input.location.lastData.latitude > 37.54607 && Input.location.lastData.latitude < 37.54628 && Input.location.lastData.longitude > 126.9645 && Input.location.lastData.longitude < 126.9651)
        {
            locationText.GetComponent<Text>().text = "현재위치: 순헌관 호수";
        }

        //도서관은 테스트용 파일이므로 추후 삭제할 것
        else if (Input.location.lastData.latitude > 37.54381 && Input.location.lastData.latitude < 37.54457 && Input.location.lastData.longitude > 126.9657 && Input.location.lastData.longitude < 126.9664)
        {
            locationText.GetComponent<Text>().text = "현재위치: 도서관";
        }

        else
        {
            locationText.GetComponent<Text>().text = "현재위치: 알 수 없음";
        }

    }

    public void buttonClicked()
    {

        //순헌관을 인식하는 퀘스트
        if (Input.location.lastData.latitude > 37.54629 && Input.location.lastData.latitude < 37.54667 && Input.location.lastData.longitude > 126.9642 && Input.location.lastData.longitude < 126.9653)
        { 

            SceneManager.LoadScene("Main");
        }

        else
        {
            GpsButtonText.GetComponent<Text>().text = "GPS 인식 실패";
        }



    }

}

