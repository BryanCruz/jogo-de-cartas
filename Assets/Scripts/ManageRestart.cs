using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageRestart : MonoBehaviour
{
	int jogadas, recorde, antigoRecorde;
	AudioSource somNovoRecorde;

	// Start is called before the first frame update
	void Start()
	{
		jogadas = PlayerPrefs.GetInt( "Jogadas" );
		recorde = PlayerPrefs.GetInt( "Recorde", 99999 );
		antigoRecorde = PlayerPrefs.GetInt( "AntigoRecorde", 99999 );

		somNovoRecorde = GetComponent<AudioSource>();

		UpdateTentativas();
		UpdateRecorde();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void UpdateTentativas()
	{
		GameObject.Find( "numTentativas" ).GetComponent<Text>().text = "Tentativas = " + jogadas;
	}


	void UpdateRecorde()
	{
		// monta a string de recorde
		string recordeText = "Recorde = " + recorde;

		// adiciona a palavra "NOVO" caso seja um novo recorde
		if ( recorde != antigoRecorde )
			recordeText += " (NOVO)";

		// atualiza o objeto na tela com o texto de recorde
		GameObject.Find( "recorde" ).GetComponent<Text>().text = recordeText;

		// toca a musica de novo recorde caso seja um novo recorde
		if ( recorde != antigoRecorde )
			somNovoRecorde.Play();
	}
}
