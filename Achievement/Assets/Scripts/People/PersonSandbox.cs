using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class PersonSandbox : MonoBehaviour {

	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////


	//the person's rigidbody
	protected Rigidbody rb;
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////


	//initialize variables
	public virtual void Setup(){
		rb = GetComponent<Rigidbody>();
	}


	/// <summary>
	/// Defined for each type of person.
	/// </summary>
	public abstract void Tick();
}
