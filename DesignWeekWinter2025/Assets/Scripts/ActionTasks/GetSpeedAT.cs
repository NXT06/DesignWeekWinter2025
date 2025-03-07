using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine; 


namespace NodeCanvas.Tasks.Actions {

	public class GetSpeedAT : ActionTask {

		public float startingSpeed; 
		public float scrollInput;
		private float currentSpeed;
		public float scrollMultiplier;
		public BBParameter<float> maxSpeed; 
		Blackboard BoatBlackboard; 
		
		

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			BoatBlackboard = agent.GetComponent<Blackboard>(); 
			currentSpeed = startingSpeed; 
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {

            scrollInput = Input.mouseScrollDelta.y;

            currentSpeed += scrollInput * Time.deltaTime * scrollMultiplier;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed.value);

            BoatBlackboard.SetVariableValue("currentSpeed", currentSpeed);
        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}