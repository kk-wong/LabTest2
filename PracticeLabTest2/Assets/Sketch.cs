using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
	public GameObject myPrefab;
	public Material material1;  
	public Material material2; 
	public Material material3; 




	public string _WebsiteURL = "http://kwon709.azurewebsites.net/tables/WaterPollutionReading?zumo-api-version=2.0.0";

	void Start () {

		string jsonResponse = Request.GET(_WebsiteURL);

		//Just in case something went wrong with the request we check the reponse and exit if there is no response.

		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}

		//We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		// convert the table into an array (this is shown in deserialise) 
		WaterPollutionReading[] waterpollutionreadings = JsonReader.Deserialize<WaterPollutionReading[]>(jsonResponse);

		int totalCubes = waterpollutionreadings.Length;
		int totalDistance = 5;
		int i = 0;
		foreach (WaterPollutionReading waterpollutionreading in waterpollutionreadings)
		{
			Debug.Log("This person passed away at the age of: " + waterpollutionreading.SafetyCategory);
			float perc = i / (float)totalCubes;
			i++;
			float x = 0.0f;

			if (waterpollutionreading.SafetyCategory == "High") {
				// float y = where it is on the y axis- where is it rotating on the y axis- You have three different levels and this is changed by float y
				float y = 0.25f;
				float z = 16.0f;
				// Create a new cube for every object in that table
				GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
				// <shows what you can put in- refer to unity>().field it is
				// changes cube size based on script in mycubescript- you can change this value directly
				//setsize(method) vs setsize = field
				//newCube.GetComponent<mySphereScript>().setSize(0.3f);
				//newCube.GetComponent<mySphereScript>().rotateSpeed = perc;
				newCube.GetComponentInChildren<TextMesh> ().text= waterpollutionreading.SafetyCategory;

				//Colors attribute that you can make 
				newCube.GetComponent<Renderer> ().material = material1;

			} 

			else if (waterpollutionreading.SafetyCategory == "Medium") {
				float y = 0.25f;
				float z = 17.0f;
				GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
				//newCube.GetComponent<mySphereScript>().setSize(0.5f);
				//newCube.GetComponent<mySphereScript>().rotateSpeed = perc;
				newCube.GetComponentInChildren<TextMesh> ().text = waterpollutionreading.SafetyCategory;
			//	newCube.GetComponent<mySphereScript>().rotateAxis = Vector3.down;
				newCube.GetComponent<Renderer> ().material = material2;

			} 
			else {
				float y = 0.25f;
				float z = 17.0f;
				GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
			//	newCube.GetComponent<mySphereScript>().setSize(0.7f);
			//	newCube.GetComponent<mySphereScript>().rotateSpeed = perc;
				newCube.GetComponentInChildren<TextMesh> ().text = waterpollutionreading.SafetyCategory;
				newCube.GetComponent<Renderer> ().material = material3 ;
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}