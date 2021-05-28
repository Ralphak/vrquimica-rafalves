using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	GameObject objSelecionado, tubo;
	public GameObject linha, tuboPrefab;
	RaycastHit hit;
	public Transform rightHand;
	public Transform[] posTubos = new Transform[8];
	Vector3 ultimaPosicao;

	// Use this for initialization
	void Start () {
		linha = Instantiate(linha);
		linha.GetComponent<LinhaLaser>().pontoOrigem = rightHand;
		foreach(Transform posicao in posTubos){
			tubo = Instantiate(tuboPrefab);
			ReposicionarObjeto(tubo, null, posicao.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) ) && Physics.Raycast(rightHand.position, rightHand.forward, out hit)){
			if(objSelecionado){
				if(hit.collider.tag == "Tubo" && objSelecionado.tag == "Objeto"){
					hit.collider.SendMessage("SetReagentes", objSelecionado.GetComponent<Objeto>().GetAtributo());
				}
				objSelecionado.GetComponent<Collider>().enabled = true;
				ReposicionarObjeto(objSelecionado, null, ultimaPosicao);
				objSelecionado = null;
			} 
			else if(hit.collider.tag=="Objeto" || hit.collider.tag == "Tubo"){
				objSelecionado = hit.collider.gameObject;
				objSelecionado.GetComponent<Collider>().enabled = false;
				ultimaPosicao = objSelecionado.transform.position;
				ReposicionarObjeto(objSelecionado, rightHand, Vector3.forward * 0.1f);
			} 
			else if(hit.collider.tag=="Reiniciar"){
				foreach(GameObject tuboAtivo in GameObject.FindGameObjectsWithTag("Tubo")){
					Destroy(tuboAtivo);
				}
				foreach(Transform posicao in posTubos){
					tubo = Instantiate(tuboPrefab);
					ReposicionarObjeto(tubo, null, posicao.position);
				}
			}
		}

		if(OVRInput.GetDown(OVRInput.Button.Back)){
			Application.Quit();
		}
	}

	void ReposicionarObjeto(GameObject objeto, Transform pai, Vector3 posicao = default(Vector3)){
		objeto.transform.SetParent(pai);
		objeto.transform.localPosition = posicao;
		objeto.transform.localRotation = Quaternion.identity;
	}

}
