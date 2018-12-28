using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Set_Color_Deflault : MonoBehaviour {

	public Material Need_Change_Material;
	public Color End_Color;
	public float Needtime = 0;

	void OnTriggerEnter (Collider other)
	{
		Need_Change_Material.DOColor (End_Color, Needtime);
	}
}
