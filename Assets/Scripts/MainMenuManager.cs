using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void MeatChoiceScenePlay()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void CookTechnologiesScenePlay()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void MarinadeReceptsScenePlay()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
