using System.Collections.Generic;
using UnityEngine;

public class PersonManager {

	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////
	
	
	//the list of people
	List<PersonSandbox> people = new List<PersonSandbox>();
	private const string PERSON_TAG = "Person";
	private const string VILLAIN_TAG = "Villain";
	

	//the main character
	private const string MAIN_CHARACTER_OBJ = "Main Character";
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////


	/// <summary>
	/// Build a list of all people, and then set everyone up.
	/// </summary>
	public void Setup(){
		GameObject[] persons = GameObject.FindGameObjectsWithTag(PERSON_TAG);
		foreach (GameObject person in persons) people.Add(person.GetComponent<PersonSandbox>());
		GameObject[] villains = GameObject.FindGameObjectsWithTag(VILLAIN_TAG);
		foreach (GameObject villain in villains) people.Add(villain.GetComponent<PersonSandbox>());
		Debug.Assert(people.Count != 0, "Found no people.");
		
		foreach (PersonSandbox person in people) person.Setup();
	}


	/// <summary>
	/// Tell each person to do whatever they do each frame.
	/// </summary>
	public void Tick(){
		foreach (PersonSandbox person in people) person.Tick();
	}
}
