using UnityEngine;

public class GameManager : MonoBehaviour {

	
	/// <summary>
	/// This is the only Start() or Awake() in the scene. Everything else gets set up through this method.
	/// </summary>
	private void Start(){
		Services.Events = new CustomEventManager();
		Services.People = new PersonManager();
		Services.People.Setup();
		Services.Inputs = new InputManager();
		Services.Tasks = new TaskManager();
	}

	
	/// <summary>
	/// Like Start() above, this is the only Update() in the scene. Everything that needs to happen each
	/// frame is controlled here.
	/// </summary>
	private void Update(){
		Services.Inputs.Tick();
		Services.People.Tick();
		Services.Tasks.Tick();
	}
}
