using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class PersonSandbox : MonoBehaviour {

	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////


	//the person's rigidbody
	protected Rigidbody2D rb2D;
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////


	//initialize variables
	public virtual void Setup(){
		rb2D = GetComponent<Rigidbody2D>();
	}


	/// <summary>
	/// Defined for each type of person.
	/// </summary>
	public abstract void Tick();
}
