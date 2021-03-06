using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButton : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void NovoJogo()
	{
		SceneManager.LoadScene( "Lab3" );
	}

	public void Creditos()
	{
		SceneManager.LoadScene( "Lab3_Creditos" );
	}
}
