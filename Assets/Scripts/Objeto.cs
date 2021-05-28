using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objeto : MonoBehaviour {

	public enum Categoria {
		Vinagre, Tomate, Café, Chuva, ÁguaDoce, ÁguaMar, Sabonete, LeiteMagnésia, Amônia,
		VermelhoMetila, AzulBromotinol, Fenolftaleína, RepolhoRoxo
	};
	public Categoria categoria;
	int pH = 0;
	Color corEtiqueta = Color.white;

	// Use this for initialization
	void Start () {
		string nomeEtiqueta = "";

		switch(categoria.ToString()){
			//Reagentes
			case "Vinagre":
				nomeEtiqueta = categoria.ToString();
				pH = 3;
				break;
			case "Tomate":
				nomeEtiqueta = categoria.ToString();
				pH = 4;
				break;
			case "Café":
				nomeEtiqueta = categoria.ToString();
				pH = 5;
				break;
			case "Chuva":
				nomeEtiqueta = categoria.ToString();
				pH = 6;
				break;
			case "ÁguaDoce":
				nomeEtiqueta = "Água Doce";
				pH = 7;
				break;
			case "ÁguaMar":
				nomeEtiqueta = "Água do Mar";
				pH = 8;
				break;
			case "Sabonete":
				nomeEtiqueta = categoria.ToString();
				pH = 9;
				break;
			case "LeiteMagnésia":
				nomeEtiqueta = "Leite de Magnésia";
				pH = 10;
				break;
			case "Amônia":
				nomeEtiqueta = categoria.ToString();
				pH = 11;
				break;
			//Indicadores
			case "VermelhoMetila":
				nomeEtiqueta = "Vermelho de Metila";
				corEtiqueta = Color.red;
				break;
			case "AzulBromotinol":
				nomeEtiqueta = "Azul de Bromotinol";
				corEtiqueta = Color.blue;
				break;
			case "Fenolftaleína":
				nomeEtiqueta = "Fenolftaleína";
				corEtiqueta = Color.magenta;
				break;
			case "RepolhoRoxo":
				nomeEtiqueta = "Extrato de Repolho Roxo";
				corEtiqueta = new Color(0.5f, 0, 0.5f);
				break;
		}

		if(corEtiqueta!=Color.white){
			//Define a cor da etiqueta do indicador
			transform.Find("Object008").GetComponent<Renderer>().material.color = corEtiqueta;
		} else{
			//Corrige a transparência do líquido no frasco
			transform.Find("Liquido").GetComponent<Renderer>().material.renderQueue++;
		}
		GetComponentInChildren<Text>().text = nomeEtiqueta;
	}

	public object GetAtributo(){
		if(corEtiqueta!=Color.white) return corEtiqueta;
		else return pH;
	}
	
}
