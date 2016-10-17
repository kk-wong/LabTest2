using UnityEngine;
using System.Collections;

public class mySphereScript : MonoBehaviour {

	public float rotateSpeed = 1.0f;
	public Vector3 spinSpeed = Vector3.zero;
	Vector3 spinAxis = new Vector3(0, 1, 0);
	public Vector3 rotateAxis = Vector3.up;
	public Material material4;
	// Use this for initialization
	void Start () {
		spinSpeed = new Vector3(Random.value, Random.value, Random.value);
		spinAxis = Vector3.up;
		spinAxis.x = (Random.value - Random.value)*0.1f;
	}


	//void OnMouseDown() {
		//change color on click
		//this.GetComponent<Renderer> ().material = material4;
	//}
		//changes size on click
		//this.transform.localScale = new Vector3 (1, 1, 1);
	
	//void OnMouseUp () {
			//Destroy(GameObject);


	//}

	//void OnMouseUp () {
		// changes sizes when mouse not on click
		//this.transform.localScale = new Vector3 (1, 1, 1);
	//}
	//use this" because its inside the script already. 
	//this.rotateSpeed = 1.0f;
	// this is also a part of a vector. 
	//this.spinSpeed = Vector3.one;
	//this.spinAxis = Vector3.one;

	//public void setSize(float size)
	//{
	//	this.transform.localScale = new Vector3(size, size, size);
	//}

	// Update is called once per frame- change it to what we have changed. That is why they all have diff speeds.
	//void Update () {
	//this.transform.Rotate(spinSpeed);
	// You give it a variable that you can change around- 
	//this.transform.RotateAround(Vector3.zero, rotateAxis, rotateSpeed);

	//}

	// click on one thing and it stops rotating. 
}