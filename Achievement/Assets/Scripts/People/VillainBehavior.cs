using UnityEngine;

public class VillainBehavior : PersonSandbox {

	
	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////


	//the main character
	private Transform mainCharacter;
	private const string MAIN_CHARACTER_OBJ = "Main Character";
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////


	//initialize variables
	public override void Setup(){
		mainCharacter = GameObject.Find(MAIN_CHARACTER_OBJ).transform;
		base.Setup();
	}
	
	
	/// <summary>
	/// Each frame, work to pursue the main character.
	/// </summary>
	public override void Tick(){
		rb.AddForce(FindMainCharacter() * 1.0f, ForceMode.Force);
	}


	/// <summary>
	/// Get a vector toward the main character.
	/// </summary>
	/// <returns>A normalized vector2 pointing toward the main character.</returns>
	private Vector2 FindMainCharacter(){
		return (mainCharacter.position - transform.position).normalized;
	}
}
