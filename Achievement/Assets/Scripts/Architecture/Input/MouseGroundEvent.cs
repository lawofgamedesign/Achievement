using UnityEngine;

public class MouseGroundEvent : CustomEvent{

	
	////////////////////////////////////////////////
	/// Fields
	////////////////////////////////////////////////
	
	
	//the point on the ground the player is pointing at
	public readonly Vector3 groundPos;
	
	
	////////////////////////////////////////////////
	/// Functions
	////////////////////////////////////////////////
	
	
	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="pos">The intercept between the mouse and the ground.</param>
	public MouseGroundEvent(Vector3 pos){
		groundPos = pos;
	}
}
