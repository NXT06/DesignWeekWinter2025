using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine; 


namespace NodeCanvas.Tasks.Actions {

	public class BoatMovementAT : ActionTask {

		public float moveSpeed;
		public BBParameter<float> speedInput;
		public BBParameter<float> maxSpeed; 
        float currentSpeed; 
		public Rigidbody rb;

        public BBParameter<float> turn;
        public BBParameter<float> rotationSpeed = 1;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            var targetRotation = agent.transform.rotation * Quaternion.Euler(Vector3.up * turn.value * 10);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, targetRotation, rotationSpeed.value * Time.deltaTime);

			currentSpeed = speedInput.value * moveSpeed;

			//Debug.Log(currentSpeed); 

			rb.AddRelativeForce(0, 0, currentSpeed);

			rb.maxLinearVelocity = maxSpeed.value;

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}