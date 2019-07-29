using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S9UIController : MonoBehaviour {

    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }
}
