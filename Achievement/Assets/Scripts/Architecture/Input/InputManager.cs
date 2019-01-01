using UnityEngine;

public abstract class InputManager {


	public virtual void Setup(){
		//some InputManagers need to be set up; others don't
	}
	
	
	/// <summary>
	/// Each type of InputManager sends out a different kind of event.
	/// </summary>
	public abstract void Tick();
}