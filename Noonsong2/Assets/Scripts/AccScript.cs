using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AccScript : MonoBehaviour {

    public Text AccText;
    public Text AccText1;
    public Slider shakeBarSlider;
    private const float maxShakeCount = 35f;
    private float shakeCount,x,y,z,cx,cy,cz = 0f;
    
    // Use this for initialization
    void Start () { 
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = false;

        Invoke("startAcc", 1);
        InvokeRepeating("updateAcc", 2, 0.3f);

    }
	
	// Update is called once per frame
	void Update () {

        if(shakeCount < 5f)
        {
            AccText1.text = "과 주점을 홍보하는 중입니다.";
        }

        else if(shakeCount < 15f)
        {
            AccText1.text = "손님들이 몰려오고 있습니다.";
        }

        else if(shakeCount < 25f)
        {
            AccText1.text = "열심히 서빙하는 중입니다.";
        }

        else if(shakeCount < 35f)
        {
            AccText1.text = "축제날 밤이 무르익어 가고 있습니다.";
        }

        else
        {
            AccText1.text = "축제가 성공적으로 끝났습니다.";
            AccText.text = "잠시만 기다려주세요";
            Screen.autorotateToLandscapeRight = true;
            Invoke("returnMain", 2f);
            //씬전환.
        }

       AccText.text = "핸드폰을 흔들어 주세요";
       shakeBarSlider.value = (shakeCount / maxShakeCount);

    }

    void startAcc()
    {
        x = Input.acceleration.x;
        y = Input.acceleration.y;
        z = Input.acceleration.z;
    }

    void updateAcc()
    {
        cx = Input.acceleration.x;
        cy = Input.acceleration.y;
        cz = Input.acceleration.z;

        if (Mathf.Abs(x + y + z - cx - cy - cz) > 0.8) shakeCount++;

        x = cx;
        y = cy;
        z = cz;

    }

    void returnMain()
    {
        SceneManager.LoadScene("S8");
    }

}
