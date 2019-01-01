using UnityEngine;

public class ScreenInputManager : InputManager {

	public override void Tick(){
		Services.Events.Fire(new MousePosEvent(Input.mousePosition));
	}
}
