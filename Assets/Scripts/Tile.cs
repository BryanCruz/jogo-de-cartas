using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	private bool tileRevelada;              // indicador da carta virada ou não
	public Sprite originalCarta;            // Sprite da carta desejada
	public Sprite backCarta;                // Sprite do avesso da carta

	// Start is called before the first frame update
	void Start()
	{
		EscondeCarta();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnMouseDown()
	{
		print( "Voce pressionou num Tile" );

		/* if ( tileRevelada )
			EscondeCarta();
		else
			RevelaCarta(); */    // aqui não se guardava numero de cartas

		GameObject.Find( "gameManager" ).GetComponent<ManageCartas>().CartaSelecionada( gameObject );
	}

	///	esconde a carta trocando seu sprite para o sprite de trás
	public void EscondeCarta()
	{
		GetComponent<SpriteRenderer>().sprite = backCarta;
		tileRevelada = false;
	}

	// exibe a carta trocando seu sprite para o sprite da frente
	public void RevelaCarta()
	{
		GetComponent<SpriteRenderer>().sprite = originalCarta;
		tileRevelada = true;
	}

	public void SetCartaOriginal(Sprite novaCarta)
	{
		originalCarta = novaCarta;
	}
}
