using UnityEngine;

public class InputManager {


	/// <summary>
	/// Every frame, send out an event with the current position of the mouse.
	/// </summary>
	public void Tick(){
		Services.Events.Fire(new MousePosEvent(Input.mousePosition));
	}
}