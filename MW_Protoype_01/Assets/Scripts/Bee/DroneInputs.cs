using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace ConaLuk
{

    [RequireComponent(typeof(PlayerInput))]
    public class DroneInputs : MonoBehaviour
    {

        #region Variables

        private Vector2 cyclic;
        private float pedals;
        private float throtle;
        private float boost;

        public Vector2 Cyclic { get => cyclic;  }
        public float Pedals { get => pedals; }
        public float Throtle { get => throtle; }
        public float Boost { get => boost; set => boost = value; }

        #endregion

        #region Main Methods

        private void Update()
        {
            
        }

        #endregion

        #region Input Methods

        private void OnCyclic(InputValue inputValue)
        {
            cyclic = inputValue.Get<Vector2>();
        }

        private void OnPedals(InputValue inputValue)
        {
            pedals = inputValue.Get<float>();
        }

        private void OnThrotle(InputValue inputValue)
        {
            throtle = inputValue.Get<float>();
        }

        private void OnBoost(InputValue inputValue)
        {
            boost = inputValue.Get<float>();
        }
        #endregion

    }
}