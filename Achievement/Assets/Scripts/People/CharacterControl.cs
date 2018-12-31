namespace Main_Character{

	using UnityEngine;

	public class CharacterControl : PersonSandbox
	{


		////////////////////////////////////////////////
		/// Fields
		////////////////////////////////////////////////


		//used to calculate movement
		private Vector3 screenMoveDir;

		private float moveMagnitude;
		private Vector3 totalScreenMove;
		private float speed = 0.05f;
		private Vector3 characterScreenPos;


		//used to rotate the player
		private Vector3 screenMousePos;


		////////////////////////////////////////////////
		/// Functions
		////////////////////////////////////////////////


		//register for input events
		public override void Setup(){
			Services.Events.Register<MousePosEvent>(Move);

			base.Setup();
		}


		/// <summary>
		/// The main character isn't subject to moving around as bystanders are.
		/// </summary>
		public override void Tick()
		{
			//intentionally blank
		}


		/// <summary>
		/// Move the main character toward the cursor. The character moves faster when the cursor is farther away.
		/// </summary>
		/// <param name="e">A MousePosEvent with the mouse's current screen position.</param>
		private void Move(global::Event e)
		{
			Debug.Assert(e.GetType() == typeof(MousePosEvent), "Non-MousePosEvent in Move()");

			MousePosEvent posEvent = e as MousePosEvent;

			//calculate movement in terms of the screen
			screenMoveDir =
				(posEvent.mousePos - Camera.main.WorldToScreenPoint(transform.position))
				.normalized; //direction toward the cursor
			moveMagnitude =
				Vector3.Distance(posEvent.mousePos,
					Camera.main.WorldToScreenPoint(transform.position)); //higher when cursor is farther away
			totalScreenMove = screenMoveDir * moveMagnitude * speed; //overall movement, in terms of the screen
			characterScreenPos =
				Camera.main.WorldToScreenPoint(transform
					.position); //the main character's position, in terms of the screen


			//perfectly follow the cursor
			//rb2D.MovePosition(Camera.main.ScreenToWorldPoint(posEvent.mousePos));

			//move toward the cursor, translating screen values into world values
			rb2D.MovePosition(Camera.main.ScreenToWorldPoint(characterScreenPos + totalScreenMove));
		}
	}
}