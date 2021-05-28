using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubo : MonoBehaviour {

	GameObject liquido, indicador;
	Color[,] coresReacao = new Color[4,14];
	bool misturado;
	Vector3 lastPos;
	int pH, idIndicador, contador = 0;

	// Use this for initialization
	void Start () {
		CoresReacao();
		liquido = transform.Find("Liquido").gameObject;
		indicador = transform.Find("Indicador").gameObject;
		lastPos = transform.position;

		//Corrige a transparência do líquido no tubo
		liquido.GetComponent<Renderer>().material.renderQueue ++;
		indicador.GetComponent<Renderer>().material.renderQueue += 2;
	}
	
	// Update is called once per frame
	void Update () {
		//Mistura os reagentes com a movimentação do tubo
		if(!misturado && liquido.activeSelf && indicador.activeSelf){
			float velocidade = ((transform.position - lastPos).magnitude) / Time.deltaTime;
			lastPos = transform.position;

			if(velocidade > 1){
				contador++;
				if(contador > 30){
					Color corFinal = coresReacao[idIndicador, pH-1];
					corFinal.a *= 0.8f;
					liquido.GetComponent<Renderer>().material.color = corFinal;
					indicador.GetComponent<Renderer>().material.color = corFinal;
					misturado = true;
				}
			} else if(contador>0){
				contador --;
			}
		}

	}

	public void SetReagentes(int pH){
		if(!liquido.activeSelf) {
			this.pH = pH;
			liquido.SetActive(true);
		}
	}
	public void SetReagentes(Color corIndicador){
		if(liquido.activeSelf && !indicador.activeSelf) {
			indicador.GetComponent<Renderer>().material.color = corIndicador;
			indicador.SetActive(true);

			//Definir um ID para os indicadores
			if(corIndicador==Color.red){
				idIndicador=0;	//Vermelho de Metila
			} else if(corIndicador==Color.blue){
				idIndicador=1;	//Azul de Bromotinol
			} else if(corIndicador==Color.magenta){
				idIndicador=2;	//Fenolftaleína
			} else if(corIndicador==new Color(0.5f, 0, 0.5f)){
				idIndicador=3;	//Extrato de Repolho Roxo
			}
		}
	}

	//Registra uma lista de reações possíveis e a cor do produto final.
	void CoresReacao(){
		//Vermelho de Metila
		for (int i = 0; i <= 2; i++){
			coresReacao[0,i] = Color.red;
		}
		coresReacao[0,3] = new Color(1, 0.25f, 0, 1);
		coresReacao[0,4] = new Color(1, 0.5f, 0, 1);
		coresReacao[0,5] = new Color(1, 0.75f, 0, 1);
		for (int i = 6; i <= 13; i++){
			coresReacao[0,i] = Color.yellow;
		}
		//Azul de Bromotinol
		for (int i = 0; i <= 4; i++){
			coresReacao[1,i] = Color.yellow;
		}
		coresReacao[1,5] = new Color(0.5f, 0.75f, 0, 1);
		coresReacao[1,6] = new Color(0, 0.5f, 0, 1);
		coresReacao[1,7] = new Color(0, 0.25f, 0.5f, 1);
		for (int i = 8; i <= 13; i++){
			coresReacao[1,i] = Color.blue;
		}
		//Fenolftaleína
		for (int i = 0; i <= 6; i++){
			coresReacao[2,i] = Color.white;
		}
		coresReacao[2,7] = new Color(1, 0.75f, 1, 1);
		coresReacao[2,8] = new Color(1, 0.5f, 1, 1);
		coresReacao[2,9] = new Color(1, 0.25f, 1, 1);
		for (int i = 10; i <= 13; i++){
			coresReacao[2,i] = Color.magenta;
		}
		//Extrato de Repolho Roxo
		coresReacao[3,0] = Color.red;
		coresReacao[3,1] = new Color(1, 0, 0.25f, 1);
		coresReacao[3,2] = new Color(1, 0, 0.5f, 1);
		coresReacao[3,3] = new Color(1, 0, 0.75f, 1);
		coresReacao[3,4] = Color.magenta;
		coresReacao[3,5] = new Color(0.66f, 0, 1, 1);
		coresReacao[3,6] = new Color(0.33f, 0, 1, 1);
		coresReacao[3,7] = Color.blue;
		coresReacao[3,8] = new Color(0, 0.33f, 0.66f, 1);
		coresReacao[3,9] = new Color(0, 0.66f, 0.33f, 1);
		coresReacao[3,10] = Color.green;
		coresReacao[3,11] = new Color(0.5f, 1, 0, 1);
		coresReacao[3,12] = Color.yellow;
		coresReacao[3,13] = Color.yellow;
	}
	
}
