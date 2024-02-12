using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConaLuk
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigidbody : MonoBehaviour
    {
        #region Variables

        [Header("Rigidbody Properties")]

        protected Rigidbody baseRB;
        protected float startDrag;
        protected float startAngularDrag;

        #endregion

        #region Main Methods

        void Awake()
        {
            baseRB = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if(!baseRB)
                return;

            if(baseRB)
            {
                startDrag = baseRB.drag;
                startAngularDrag = baseRB.angularDrag;
            }

            HandlePhysics();

        }

        #endregion

        #region Custom Methods

        protected virtual void HandlePhysics() { }


        #endregion

    }
}