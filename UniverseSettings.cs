using System;
using UnityEngine;

namespace Unity_NBodySimulation
{
    /// <summary>
    /// Singleton that controls core behaviours of the simulation, exactly one of these should exist in the unity scene.
    /// </summary>
    public class UniverseSettings : MonoBehaviour
    {
        /// <summary>
        /// Controls how powerful the pull of gravity is, bigger numbers attract more
        /// </summary>
        public static float gravityConstant {
            get => UniverseSettings.instance._gravityConstant;
            set => UniverseSettings.instance._gravityConstant = value;
        }
        
        private static UniverseSettings instance;

        /// <summary>
        /// Gravitational constant used to calculate attraction forces, also known as "Big G"
        /// </summary>
        [SerializeField] private float _gravityConstant = 0.05f;

        private void Start() {
            if (UniverseSettings.instance) {
                Debug.LogError("Two instances on Universe exist, only one can be used by the NBody simulator.");
                return;
            }
            
            UniverseSettings.instance = this;
        }
    }
}