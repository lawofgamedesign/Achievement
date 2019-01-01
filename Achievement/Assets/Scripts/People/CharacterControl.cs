namespace Main_Character {

	using UnityEngine;

	public class CharacterControl : PersonSandbox {


		////////////////////////////////////////////////
		/// Fields
		////////////////////////////////////////////////


		//used to calculate movement when following mouse on screen
		private Vector3 screenMoveDir;

		private float moveMagnitude;
		private Vector3 totalScreenMove;
		private float speed = 0.05f;
		private Vector3 characterScreenPos;
		
		
		//used to calcuate movement when pursuing point on ground
		private Vector3 playerGroundLoc = new Vector3(0.0f, 0.0f, 0.0f);
		private Vector3 groundMoveDir;
		private Vector3 totalGroundMove;


		//used to rotate the player
		private Vector3 screenMousePos;


		////////////////////////////////////////////////
		/// Functions
		////////////////////////////////////////////////


		//register for input events
		public override void Setup(){
			//Services.Events.Register<MousePosEvent>(Move); //for moving to mouse position on screen
			Services.Events.Register<MouseGroundEvent>(Move); //for moving to mouse position on ground

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
		/// Move the main character so that they are hovering over a point on the ground the player is pointing at
		/// with the mouse.
		/// </summary>
		/// <param name="e">A MouseGroundEvent with the point on the ground where the player is pointing.</param>
		private void Move(CustomEvent e){
			Debug.Assert(e.GetType() == typeof(MouseGroundEvent), "Non-MouseGroundEvent in Move()");
			
			MouseGroundEvent groundEvent = e as MouseGroundEvent;

			playerGroundLoc.x = transform.position.x;
			playerGroundLoc.z = transform.position.z;
			Debug.DrawLine(transform.position, playerGroundLoc, Color.red, 3.0f);
			
			groundMoveDir = (groundEvent.groundPos - playerGroundLoc).normalized;
			moveMagnitude = Vector3.Distance(groundEvent.groundPos, playerGroundLoc);
			totalGroundMove = groundMoveDir * moveMagnitude * speed;
			
			rb.MovePosition(transform.position + totalGroundMove);
		}


		/// <summary>
		/// Move the main character toward the cursor. The character moves faster when the cursor is farther away.
		/// </summary>
		/// <param name="e">A MousePosEvent with the mouse's current screen position.</param>
		/*private void Move(global::Event e) {
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
		}*/
	}
}