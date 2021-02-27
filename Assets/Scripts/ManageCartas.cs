using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCartas : MonoBehaviour
{
	public GameObject carta;        // A carta a ser descartada

	// Start is called before the first frame update
	void Start()
	{
		MostraCartas();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void MostraCartas()
	{
		Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
	}
}
