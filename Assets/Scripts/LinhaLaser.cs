using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinhaLaser : MonoBehaviour {

	LineRenderer linha;
	RaycastHit hit;
	public Transform pontoOrigem;
	Vector3 pontoAlvo;

	// Use this for initialization
	void Start () {
		linha = GetComponent<LineRenderer>();
		pontoAlvo = linha.GetPosition(1);
	}
	
	// Update is called once per frame
	void Update () {
		linha.SetPosition(0, pontoOrigem.position);
		
		if(Physics.Raycast(pontoOrigem.position, pontoOrigem.forward, out hit)){
			linha.SetPosition(1, hit.point - transform.position);
		} else{
			linha.SetPosition(1, pontoAlvo);
		}
	}
	
}
