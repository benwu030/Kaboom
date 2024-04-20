using UnityEngine;
using System.Collections;
using TMPro;
public class Playsound : MonoBehaviour 

{
	public void Clicky (){
		GetComponent<AudioSource>().Play();
	}


}
