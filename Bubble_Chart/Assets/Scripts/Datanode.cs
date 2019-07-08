using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Datanode : MonoBehaviour
    {
        // sphere prefab
        [SerializeField]
        private GameObject obj;

        [SerializeField]
        private GameObject SpawnBox;

        private float sizeOfObj = 1f;
        public List<Vector3> objPositions = new List<Vector3>();
        public List<float> objScales = new List<float>();
        private Color[] colors;

        void Awake()
        {
            colors = new Color[15];
            colors[0] = new Color(0.5f, 0.5f, 0, 1); // blue
            colors[1] = new Color(1, 0, 1, 1); // green
            colors[2] = new Color(1, 1, 0, 1); // red
            colors[3] = new Color(0.5f, 1, 0.5f, 1); // purple
            colors[4] = new Color(0.25f, 0, 0.5f, 1); // yellow
            colors[5] = new Color(1, 0.5f, 0.5f, 1); // maroon
            colors[6] = new Color(1, 0.25f, 0, 1); // aqua
            colors[7] = new Color(0, 0.5f, 1, 1); // pink
            colors[8] = new Color(1, 1, 0.25f, 1); // teal
            colors[9] = new Color(.75f, .25f, 1, 1); // gold
            colors[10] = new Color(0.5f, .25f, 0.5f, 1); // baby pink
            colors[10] = new Color(0.5f, .25f, 0.5f, 1); // baby pink
            colors[11] = new Color(0, 0.25f, 0, 1); // dark blue
            colors[12] = new Color(0.5f, 0, 0.5f, 1); // orange
            colors[13] = new Color(0, 0, 0.5f, 1); // silver
            colors[14] = new Color(1f, 1f, 1f, 1); // white
        }

        void Start()
        {
            sizeOfObj = obj.transform.localScale.x;
            dataset.makedata();
            Generate();

        }

        public void Generate()
        {
            // user can read different file and based on (key,value) pairs numbers of bubble charts are instantiated.
            var keyValPairs = dataset.data;
            int count = 0;
            foreach (var pair in keyValPairs)
            {
                var currVal = pair.Value;
                // scaling the dataNode based on respective entries in the dataset that belonged to that type
                float normalizedScale = GetNormalizedScale(currVal);
                // INSTANTIATING DATANODES
                GameObject gameObj = Instantiate(obj, SetBoxBoundaries(normalizedScale), Quaternion.identity) as GameObject;
                gameObj.GetComponent<DatanodeProperties>().CountInfo = pair.Value;
                gameObj.GetComponent<DatanodeProperties>().TypeInfo = pair.Key;
                gameObj.transform.localScale = new Vector3(normalizedScale, normalizedScale, normalizedScale);
                int index = count % colors.Length;
                gameObj.GetComponent<MeshRenderer>().material.color = colors[index];
                count++;
            }
            transform.position = new Vector3(0f, 0f, -1f * keyValPairs.Count);

        }
        private Vector3 SetBoxBoundaries(float normalizedScale)
        {
            // we dont want the bubbles (data nodes) to collide with each other and also not placed on each other when spawned
            Vector3 LocalPosition;
            BoxCollider Boundaries = SpawnBox.GetComponent<BoxCollider>();
            float random = Random.value;
            LocalPosition.x = Mathf.Lerp(Boundaries.center.x + SpawnBox.transform.position.x - (Boundaries.size.x * (SpawnBox.transform.localScale.x / 2))
                + (normalizedScale / 2),
            Boundaries.center.x + SpawnBox.transform.position.x + (Boundaries.size.x * (SpawnBox.transform.localScale.x / 2)) - (normalizedScale / 2), random);

            random = Random.value;
            LocalPosition.y = Mathf.Lerp(Boundaries.center.y + SpawnBox.transform.position.y - (Boundaries.size.y * (SpawnBox.transform.localScale.y / 2))
                 + (normalizedScale / 2),
            Boundaries.center.y + SpawnBox.transform.position.y + (Boundaries.size.y * (SpawnBox.transform.localScale.y / 2)) - (normalizedScale / 2), random);
            LocalPosition.z = 0;
            sizeOfObj = normalizedScale;
            if (isAvailable(LocalPosition))
            {
                objPositions.Add(LocalPosition);
                objScales.Add(sizeOfObj);
                return LocalPosition;
            }
            else
                return SetBoxBoundaries(normalizedScale);
        }

        private bool isAvailable(Vector3 pos)
        {
            // making sure before spawning the object that it wont collide with any other object
            for (int i = 0; i < objPositions.Count; i++)
            {
                if (Vector3.Distance(pos, objPositions[i]) < ((sizeOfObj / 2.0f) + (objScales[i] / 2.0f)))
                    return false;
            }
            return true;
        }

        private float GetNormalizedScale(int currVal)
        {
            var maxInArray = dataset.MaxInArray();
            var minInArray = dataset.MinInArray();
            var maxNormalVal = dataset.MaxNormalvalue;
            var minNormalVal = dataset.MinNormalValue;
            float factor = (float)(currVal - minInArray) / (maxInArray - minInArray);
            float value = ((maxNormalVal - minNormalVal) * (factor)) + 1.0f;
            return value;
        }

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // raycasting mouse hover, if we hover cursor on a bubble its color is randomly changed;
                GameObject gameObj = hit.transform.gameObject;
                int random = Random.Range(0, 15);
                gameObj.GetComponent<MeshRenderer>().material.color = colors[random];
            }
        }
    }
}