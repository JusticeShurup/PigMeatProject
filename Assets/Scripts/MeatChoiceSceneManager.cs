using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeatChoiceSceneManager : MonoBehaviour
{
	public void BackToMainMenu()
	{
		SceneManager.LoadSceneAsync(0);
	}
}
