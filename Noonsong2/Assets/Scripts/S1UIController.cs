using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S1UIController : MonoBehaviour {

    public void OnButton1Clicked()
    {
        SceneManager.LoadScene("S2");
    }

    public void OnButton2Clicked()
    {
        SceneManager.LoadScene("S7");
    }
}
