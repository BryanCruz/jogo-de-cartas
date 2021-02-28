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
		// Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
		//  AddUmaCarta();

		for ( int i = 0; i < 13; i++ )
		{
			AddUmaCarta( i );
		}
	}


	void AddUmaCarta(int rank)
	{
		GameObject centro = GameObject.Find( "centroDaTela" );
		Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * 1.2f), centro.transform.position.y, centro.transform.position.z );

		// GameObject c = Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
		// GameObject c = Instantiate( carta, new Vector3( rank * 1.5f, 0, 0 ), Quaternion.identity );
		GameObject c = Instantiate( carta, novaPosicao, Quaternion.identity );
	}
}
