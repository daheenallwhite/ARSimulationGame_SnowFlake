using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class S6UIController : MonoBehaviour {

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("S8");
    }
}
