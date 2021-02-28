using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

		float escalaCartaOriginal = carta.transform.localScale.x;
		float fatorEscalaX = (650 * escalaCartaOriginal) / 100.0f;

		// Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * 1.2f), centro.transform.position.y, centro.transform.position.z );
		Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y, centro.transform.position.z );

		// GameObject c = Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
		// GameObject c = Instantiate( carta, new Vector3( rank * 1.5f, 0, 0 ), Quaternion.identity );
		GameObject c = Instantiate( carta, novaPosicao, Quaternion.identity );
		c.tag = "" + rank;
		c.name = "" + rank;

		string numeroCarta;

		if ( rank == 0 )
			numeroCarta = "ace";
		else if ( rank == 10 )
			numeroCarta = "jack";
		else if ( rank == 11 )
			numeroCarta = "queen";
		else if ( rank == 12 )
			numeroCarta = "king";
		else
			numeroCarta = "" + (rank + 1);

		string nomeDaCarta = numeroCarta + "_of_clubs";

		Sprite s1 = Resources.Load<Sprite>( nomeDaCarta );
		print( "S1: " + s1 );

		GameObject.Find( "" + rank ).GetComponent<Tile>().SetCartaOriginal( s1 );
	}
}
