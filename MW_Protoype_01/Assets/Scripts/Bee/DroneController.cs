using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ConaLuk
{
    [RequireComponent(typeof(DroneInputs))]
    public class DroneController : BaseRigidbody
    {
        #region Variables
        [Header("Engine Propeties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;
        [SerializeField] private float lerpSpeed = 2f;

        private DroneInputs droneInputs;

        private List<Engine> engines = new List<Engine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw;
        private float finalYaw;

        #endregion

        #region Main Methods
        void Start()
        {
            droneInputs = GetComponent<DroneInputs>();
            engines = GetComponentsInChildren<Engine>().ToList<Engine>();
        }

        #endregion

        #region Custom Methods

        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();

        }

        protected virtual void HandleEngines()
        {
            //baseRB.AddForce(Vector3.up * (baseRB.mass * Physics.gravity.magnitude));

            foreach(Engine engine in engines)
            {
                engine.UpdateEngine(baseRB, droneInputs);
            }
        }

        protected virtual void HandleControls()
        {
            float pitch = droneInputs.Cyclic.y * minMaxPitch;
            float roll = - droneInputs.Cyclic.x * minMaxRoll;
            // float yaw = droneInputs.Pedals * yawPower;
            yaw += droneInputs.Pedals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime *lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime*lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime *lerpSpeed);

            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);

            baseRB.MoveRotation(rot);
        }

        #endregion

    }
}