using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConaLuk
{

    public interface Engine 
    {
        void InitialseEngine();

        void UpdateEngine(Rigidbody rb, DroneInputs inputs);

    }
}