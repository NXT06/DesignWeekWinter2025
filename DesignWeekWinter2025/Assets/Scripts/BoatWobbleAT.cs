using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BoatWobbleAT : ActionTask {


		Blackboard BoatBackboard;
		public float rotateAngle;
		public float rotateDirection;
		public float rotateSpeed; 
		
		public GameObject boatBody;

        public float wobbleAmplitude = 0.1f; 

        public float wobbleFrequency = 2f;
        
		
		//Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			BoatBackboard = agent.GetComponent<Blackboard>(); 

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			

			rotateDirection = BoatBackboard.GetVariableValue<float>("Horizontal");


			rotateAngle += rotateDirection * rotateSpeed;

			rotateAngle -= rotateAngle / 2;

			
		
				float wobbleValue = Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude;

				boatBody.transform.localRotation = Quaternion.Euler(0, 0, wobbleValue + (rotateAngle));


			
			
			

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}