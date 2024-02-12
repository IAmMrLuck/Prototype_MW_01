using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace ConaLuk
{

    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, Engine
    {
        #region Variables
        [Header("Engine Properties")]

        [SerializeField] private DroneInputs droneInputs;


        [SerializeField] private float maxPower = 10f;
        [SerializeField] private float maxSpeed = 5f;
        [SerializeField] private float hoverFactor = 1f;
        private bool changingAltitude = false;
        #endregion

        #region Interface Methods


        public void InitialseEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, DroneInputs inputs)
        {
            // Debug.Log(droneInputs.Throtle);
            // Debug.Log(changingAltitude);
            // Debug.Log("Running Engine " + gameObject.name);            

            if (changingAltitude == false)
            {
                rb.constraints = RigidbodyConstraints.FreezePositionY;
            }
            else rb.constraints = RigidbodyConstraints.None;

            if (droneInputs.Throtle == 0)
            {
                changingAltitude = false;
            }
            else changingAltitude = true;

            Vector3 upVec = transform.up; 
            upVec.x = 0f;
            upVec.z = 0f;
            float difference = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * difference;
            Vector3 engineForce = Vector3.zero;
            Vector3 downwardMomentum = new Vector3(transform.position.x, y: -1, transform.position.z);

            if (inputs.Throtle <= - 0.01)
            {
                engineForce = (transform.position - downwardMomentum) * ((rb.mass * -Physics.gravity.magnitude + finalDiff) + (inputs.Throtle * maxPower)) / 4f;
            }
            else engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude + finalDiff) + (inputs.Throtle * maxPower)) / 2f;

            rb.AddForce(engineForce, ForceMode.Force);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }

            if(droneInputs.Cyclic.magnitude <= 0)
            { // CHATGPT HELPED

                Vector3 velocityAlongXZ = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

                Vector3 dampingForce = -velocityAlongXZ * hoverFactor;

                rb.AddForce(dampingForce, ForceMode.Acceleration);
            }
        }
        #endregion
    }
}