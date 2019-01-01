using UnityEngine;

public class GroundInputManager : InputManager {


	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////
	
	
	//used to generate and parent the marker
	private const string MARKER_OBJ = "Destination marker";
	private const string SCENE_ORGANIZER_OBJ = "Scene";
	
	
	//a layermask so that the raycast only detects the ground
	private LayerMask groundLayerMask = 1 << 8;


	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////
	
	
	/// <summary>
	/// Create the destination marker and set it up to listen for events it needs to find the mouse's position.
	/// </summary>
	public override void Setup(){
		GameObject destinationMarker = MonoBehaviour.Instantiate(Resources.Load<GameObject>(MARKER_OBJ),
																 GameObject.Find(SCENE_ORGANIZER_OBJ).transform);
		destinationMarker.GetComponent<DestinationMarkerBehavior>().Setup();
	}
	
	
	/// <summary>
	/// Every frame, send out a ray to the ground; send out an event with the contact point.
	/// </summary>
	public override void Tick(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask)){
			Services.Events.Fire(new MouseGroundEvent(hit.point));
		}
	}
}
