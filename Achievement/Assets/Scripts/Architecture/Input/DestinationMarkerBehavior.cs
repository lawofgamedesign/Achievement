using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestinationMarkerBehavior : MonoBehaviour{


	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////
	
	
	//the marker's rigidbody
	private Rigidbody rb;
	
	
	//the marker's location
	private Vector3 loc = new Vector3(0.0f, 0.0f, 0.0f);
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////
	
	
	/// <summary>
	/// Initialize variables.
	/// </summary>
	public void Setup(){
		rb = GetComponent<Rigidbody>();
		loc.y = transform.position.y;
		Services.Events.Register<MouseGroundEvent>(Move);
	}


	/// <summary>
	/// Move the marker so that it highlights the place where the mouse points to the ground.
	/// </summary>
	/// <param name="e">A MouseGroundEvent</param>
	private void Move(CustomEvent e){
		Debug.Assert(e.GetType() == typeof(MouseGroundEvent), "Non-MouseGroundEvent in Move()");
		
		MouseGroundEvent groundEvent = e as MouseGroundEvent;

		loc.x = groundEvent.groundPos.x;
		loc.z = groundEvent.groundPos.z;
		
		rb.MovePosition(loc);
	}
}
