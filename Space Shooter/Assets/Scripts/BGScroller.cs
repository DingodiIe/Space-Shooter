using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
	public float speed;
	public float acceleration;
	   public float scrollSpeed;
	public float tileSizeZ;
	private int winSpeed;

	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		   winSpeed = GameController.winSpeed;
		if(winSpeed ==80){
			scrollSpeed = -20;
			
		}
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}




}



//	if(speed == 3){
//		scrollSpeed = -4;//		
//yield return new WaitForSeconds( 2.0f );
//		print("hey1");}

////		if(speed == 5){
//		scrollSpeed = -8;
//		yield return new WaitForSeconds( 2.0f );
//print("hey2");}
//		if(speed == 7){
//		scrollSpeed = -12;
//		yield return new WaitForSeconds( 2.0f );
//print("hey3");}
	//	if(speed == 9){
	//	scrollSpeed = -16;
	//	yield return new WaitForSeconds( 2.0f );
//print("hey4");}
//		if(speed == 11){
//			yield return new WaitForSeconds( 2.0f );
//		scrollSpeed = -20;
//print("hey5");}