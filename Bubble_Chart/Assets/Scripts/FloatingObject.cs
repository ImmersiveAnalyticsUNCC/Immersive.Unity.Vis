using UnityEngine;

namespace Assets.Scripts {
    public class FloatingObject : MonoBehaviour {           // this script is attached to each bubble (data node prefab)
        public float degreesPerSecond = 15.0f;
        public float amplitude = 0.5f;
        public float frequency = 1f;
        private float timeDelay;
        private float timeAtStart;
        Vector3 posOffset = new Vector3();
        Vector3 tempPos = new Vector3();
        void Awake() {
            timeDelay = Random.Range(0.5f, 2);
            timeAtStart = Time.time;
        }
        void Start() {
            // Store the starting position & rotation of the object
            posOffset = transform.position;                 
            amplitude = Random.Range(0.05f, 0.3f);
        }
        void Update() {
            // Spin object around Y-Axis
            // Float up/down with a Sin()
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;      // changing y attribute of position of each data node and then updating it.
            transform.position = tempPos;
        }
    }
}
