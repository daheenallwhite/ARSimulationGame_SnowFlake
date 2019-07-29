using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S10UIController : MonoBehaviour {

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }
}
