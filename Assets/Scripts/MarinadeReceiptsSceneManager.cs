using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarinadeReceiptsSceneManager : MonoBehaviour
{
    public void OnClickBackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
