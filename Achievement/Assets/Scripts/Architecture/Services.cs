using UnityEngine;

public static class Services {

	private static CustomEventManager events;
	public static CustomEventManager Events {
		get {
			Debug.Assert(events != null, "No event manager. Are services being created out of order?");
			return events;
		}
		set { events = value; }
	}


	private static PersonManager people;
	public static PersonManager People {
		get {
			Debug.Assert(people != null, "No people manager. Are services being created out of order?");
			return people;
		}
		set { people = value; }
	}


	private static InputManager inputs;
	public static InputManager Inputs {
		get {
			Debug.Assert(inputs != null, "No input manager. Are services being created out of order?");
			return inputs;
		}
		set { inputs = value; }
	}


	private static TaskManager tasks;
	public static TaskManager Tasks {
		get {
			Debug.Assert(tasks != null, "No task manager. Are services being created out of order?");
			return tasks;
		}
		set { tasks = value; }
	}
}

