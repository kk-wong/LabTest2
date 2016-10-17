using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
	public GameObject myPrefab;
	public Material material1;  
	public Material material2; 
	public Material material3; 
	public Material material4;
	public GameObject cube;


	//Variables for dataset
	private string treeID;
	private string location;
	private string ecologicalvalue;
	private string historicalsignificance;
	private string whenReadingRecorded;
	private float x;
	private float y;
	private float z;
	public string jsonResponse;
	public string _WebsiteURL = "http://kwon709.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";

	void Start () {

		jsonResponse = Request.GET(_WebsiteURL);

		//Just in case something went wrong with the request we check the reponse and exit if there is no response.

		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}

		//We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
		// convert the table into an array (this is shown in deserialise) 
		TreeSurvey[] treesurveys = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);


		foreach (TreeSurvey treesurvey in treesurveys)
		{

			Debug.Log("X is " + treesurvey.X + ", Y is " + treesurvey.Y + ", Z is " + treesurvey.Z + "" ) ;
			treeID = treesurvey.TreeID;
			location = treesurvey.Location;
			ecologicalvalue = treesurvey.EcologicalValue;
			historicalsignificance = treesurvey.HistoricalSignificance;
			whenReadingRecorded = treesurvey.WhenReadingRecorded;
			x = float.Parse(treesurvey.X);
			y = float.Parse(treesurvey.Y);
			z = float.Parse(treesurvey.Z);

			GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
			newCube.name = treesurvey.TreeID;			
			//adds label based on axis- can change this to the safety category or other
			newCube.GetComponentInChildren<TextMesh> ().text= "(Location: " + treesurvey.Location + ")";
			//changes color
			if (treesurvey.Location == "Albert Park") {
				newCube.GetComponent<Renderer> ().material = material1;

			} else if (treesurvey.Location == "Myers Park") {
				newCube.GetComponent<Renderer> ().material = material2;

			} else {

				newCube.GetComponent<Renderer> ().material = material3;

			}

		}


	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit= new RaycastHit();
			//whereever your mouse is you get that position
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			//if you hit the object (or with mouse)
			if (Physics.Raycast (ray, out hit, 100)) {

				//hit your - you get spehre and you can do what you want with it- i.e. change its colour
				hit.collider.gameObject.GetComponent<Renderer> ().material = material4;
				Debug.Log (hit.collider.name);

				//
				int index = int.Parse(hit.collider.gameObject.name);

				TreeSurvey[] treesurveys = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

				//creating a cube where you hit the raycast
				//ReadingID is 1- so you add -1 otherwise you will get index out of bound
				GameObject newCube = (GameObject)Instantiate(cube, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
				newCube.GetComponentInChildren<TextMesh> ().text= "(Location:" + treesurveys[index-1].Location + "Ecological Value: " + treesurveys[index-1].EcologicalValue + ", Historical Significance: " + treesurveys[index-1].HistoricalSignificance + ", When Reading Recorded" + treesurveys[index-1].WhenReadingRecorded + ")";
			}

		}
	}

}

//Update is called once per frame    


//if (waterpollutionreading.X) {
// float y = where it is on the y axis- where is it rotating on the y axis- You have three different levels and this is changed by float y
//float y = 0.55f;
//float z = 16.0f;
// Create a new cube for every object in that table
//GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
// <shows what you can put in- refer to unity>().field it is
// changes cube size based on script in mycubescript- you can change this value directly
//setsize(method) vs setsize = field
//newCube.GetComponent<mySphereScript>().setSize(0.3f);
//newCube.GetComponent<mySphereScript>().rotateSpeed = perc;