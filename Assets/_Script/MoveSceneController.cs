using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSceneController : MonoBehaviour {

	public void MoveScene(int TargetIndex)
	{
		SceneManager.LoadSceneAsync (TargetIndex);

	}

}
