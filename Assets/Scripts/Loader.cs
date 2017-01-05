using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loader : MonoBehaviour
{

	public string withMpaName;
	public string withoutMpaName;

	public void loadWithMpa ()
	{
		SceneManager.LoadScene (withMpaName);
	}

	public void loadWithoutMpa ()
	{
		SceneManager.LoadScene (withoutMpaName);
	}
}
