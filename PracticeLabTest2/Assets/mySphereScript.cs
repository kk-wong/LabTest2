using UnityEngine;
using System.Collections;

public class mySphereScript : MonoBehaviour {

	//public float rotateSpeed = 1.0f;
	//public Vector3 spinSpeed = Vector3.zero;
	//Vector3 spinAxis = new Vector3(0, 1, 0);
	//public Vector3 rotateAxis = Vector3.up;
	public Material material4;

	// Use this for initialization
	//void Start () {
	//	spinSpeed = new Vector3(Random.value, Random.value, Random.value);
	//	spinAxis = Vector3.up;
	//	spinAxis.x = (Random.value - Random.value)*0.1f;
	//}

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

	void OnMouseDown() {
		//use this" because its inside the script already. 
		//this.rotateSpeed = 0.0f;
		// this is also a part of a vector. 
		//this.spinSpeed = Vector3.zero;
		//change color on click
		this.GetComponent<Renderer>().material = material4;


	}
}
