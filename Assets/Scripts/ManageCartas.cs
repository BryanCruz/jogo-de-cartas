using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ManageCartas : MonoBehaviour
{
	public GameObject carta;        // A carta a ser descartada
	private bool primeiraCartaSelecionada, segundaCartaSelecionada; // indicadores para cada carta escolhida em cada linha
	private GameObject carta1, carta2;
	private string linhaCarta1, linhaCarta2;

	bool timerPausado, timerAcionado;
	float timer;

	int numTentativas = -1;
	int numAcertos = 0;

	// Start is called before the first frame update
	void Start()
	{
		MostraCartas();
		UpdateTentativas();
	}

	// Update is called once per frame
	void Update()
	{
		if ( timerAcionado )
		{
			timer += Time.deltaTime;
			print( timer );

			if ( timer > 1 )
			{
				timerPausado = true;
				timerAcionado = false;

				if ( carta1.tag == carta2.tag )
				{
					Destroy( carta1 );
					Destroy( carta2 );

					numAcertos++;
					if ( numAcertos == 13 )
					{
						SceneManager.LoadScene( SceneManager.GetActiveScene().name );
					}
				}
				else
				{
					carta1.GetComponent<Tile>().EscondeCarta();
					carta2.GetComponent<Tile>().EscondeCarta();
				}

				primeiraCartaSelecionada = false;
				segundaCartaSelecionada = false;

				carta1 = null;
				carta2 = null;

				linhaCarta1 = "";
				linhaCarta2 = "";

				timer = 0;
			}
		}
	}

	void MostraCartas()
	{
		int[] arrayEmbaralhado = CriaArrayEmbaralhado();
		int[] arrayEmbaralhado2 = CriaArrayEmbaralhado();

		// Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
		//  AddUmaCarta();

		for ( int i = 0; i < 13; i++ )
		{
			// AddUmaCarta( i );
			// AddUmaCarta( i, arrayEmbaralhado[i] );
			AddUmaCarta( 0, i, arrayEmbaralhado[i] );
			AddUmaCarta( 1, i, arrayEmbaralhado2[i] );
		}
	}


	void AddUmaCarta(int linha, int rank, int valor)
	{
		GameObject centro = GameObject.Find( "centroDaTela" );

		float escalaCartaOriginal = carta.transform.localScale.x;
		float fatorEscalaX = (650 * escalaCartaOriginal) / 110.0f;
		float fatorEscalaY = (945 * escalaCartaOriginal) / 110.0f;

		// Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * 1.2f), centro.transform.position.y, centro.transform.position.z );
		// Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y, centro.transform.position.z );
		Vector3 novaPosicao = new Vector3( centro.transform.position.x + ((rank - 13 / 2) * fatorEscalaX), centro.transform.position.y + ((linha - 2 / 2) * fatorEscalaY), centro.transform.position.z );

		// GameObject c = Instantiate( carta, new Vector3( 0, 0, 0 ), Quaternion.identity );
		// GameObject c = Instantiate( carta, new Vector3( rank * 1.5f, 0, 0 ), Quaternion.identity );
		GameObject c = Instantiate( carta, novaPosicao, Quaternion.identity );
		c.tag = "" + valor;

		// c.name = "" + valor;
		c.name = "" + linha + "_" + valor;

		string naipe;
		if ( linha == 0 )
			naipe = "clubs";
		else
			naipe = "hearts";

		string numeroCarta;

		/* if ( rank == 0 )
			numeroCarta = "ace";
		else if ( rank == 10 )
			numeroCarta = "jack";
		else if ( rank == 11 )
			numeroCarta = "queen";
		else if ( rank == 12 )
			numeroCarta = "king";
		else
			numeroCarta = "" + (rank + 1);
		*/ // if else para array ordenado no deck

		if ( valor == 0 )
			numeroCarta = "ace";
		else if ( valor == 10 )
			numeroCarta = "jack";
		else if ( valor == 11 )
			numeroCarta = "queen";
		else if ( valor == 12 )
			numeroCarta = "king";
		else
			numeroCarta = "" + (valor + 1);

		string nomeDaCarta = numeroCarta + "_of_" + naipe;

		Sprite s1 = Resources.Load<Sprite>( nomeDaCarta );
		print( "S1: " + s1 );

		// GameObject.Find( "" + rank ).GetComponent<Tile>().SetCartaOriginal( s1 );
		// GameObject.Find( "" + valor ).GetComponent<Tile>().SetCartaOriginal( s1 );
		GameObject.Find( "" + linha + "_" + valor ).GetComponent<Tile>().SetCartaOriginal( s1 );
	}

	public int[] CriaArrayEmbaralhado()
	{
		// cria um array para ser embaralhado
		int[] novoArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

		// embaralha o array
		for ( int t = 0; t < 13; t++ )
		{
			// pega um valor aleatorio r entre t e 13
			int r = Random.Range( t, 13 );

			// inverte as posições t e r do novo array
			int temp = novoArray[t];
			novoArray[t] = novoArray[r];
			novoArray[r] = temp;
		}

		return novoArray;
	}

	public void CartaSelecionada(GameObject carta)
	{
		if ( !primeiraCartaSelecionada )
		{
			string linha = carta.name.Substring( 0, 1 );
			linhaCarta1 = linha;

			primeiraCartaSelecionada = true;
			carta1 = carta;
			carta1.GetComponent<Tile>().RevelaCarta();
		}
		else if ( primeiraCartaSelecionada && !segundaCartaSelecionada )
		{
			string linha = carta.name.Substring( 0, 1 );
			linhaCarta2 = linha;

			segundaCartaSelecionada = true;
			carta2 = carta;
			carta2.GetComponent<Tile>().RevelaCarta();

			VerificaCartas();
		}
	}

	public void VerificaCartas()
	{
		DisparaTimer();
		UpdateTentativas();
	}

	public void DisparaTimer()
	{
		timerPausado = false;
		timerAcionado = true;
	}

	void UpdateTentativas()
	{
		numTentativas++;
		GameObject.Find( "numTentativas" ).GetComponent<Text>().text = "Tentativas = " + numTentativas;
	}
}
