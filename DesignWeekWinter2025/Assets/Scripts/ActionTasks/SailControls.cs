using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SailControls : ActionTask {

		Blackboard BoatBlackboard;
		public BBParameter<float> currentSpeed;
        public BBParameter<float> MaxSpeed;
        public Transform Sails;
		public Transform Wake1;
		public Transform Wake2; 
		
		float sailPercent; 
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			
			BoatBlackboard = agent.GetComponent<Blackboard>();
			return null; 
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			sailPercent = 1; 
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			BoatBlackboard.GetVariableValue<float>("currentSpeed");

			sailPercent = currentSpeed.value / MaxSpeed.value;

			
			Sails.localScale = new Vector3(1, Mathf.Clamp(sailPercent, 0.1f, 1), 1);  
			Wake1.localScale = new Vector3(1, Mathf.Clamp(sailPercent, 0f, 1), 1);
			Wake2.localScale = new Vector3(1, Mathf.Clamp(sailPercent, 0f, 1), 1);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}