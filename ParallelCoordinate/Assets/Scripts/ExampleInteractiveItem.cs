using UnityEngine;
using DataStarter;

namespace DataStarter
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        public Canvas upperCanvas;
        public Canvas midCanvas;
        public Canvas lowerCanvas;

        private bool generated = false;


        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
            m_InteractiveItem.OnA += HandleOnA;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
            m_InteractiveItem.OnA -= HandleOnA;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");//this changes the color of material on the next line.
            if (generated == false)
            {
                m_Renderer.material = m_OverMaterial;
            }
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            if (generated == false)
            {
                m_Renderer.material = m_NormalMaterial;
            }
        }


        //Handle the Click event
        private void HandleClick()
        {
            if (generated == false)
            {
                string tag = gameObject.tag;
                Debug.Log("Show click state: " + tag);
                m_Renderer.material = m_ClickedMaterial;
                GameObject[] temp = GameObject.FindGameObjectsWithTag(tag);
                //Debug.Log("Length: " + temp.Length);
                if (ParallelCoordinates.hLines < 3) { 
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].GetComponent<LineRenderer>() != null) {
                            temp[i].GetComponent<LineRenderer>().startColor = new Color(255, 100, 0, 1);
                            temp[i].GetComponent<LineRenderer>().endColor = new Color(255, 100, 0, 1);
                            ParallelCoordinates.hLines++;
                        }
                    }
                }
                if (midCanvas.GetComponent<ChemicalGraph>().generated == false)
                {
                    midCanvas.transform.position = transform.position;
                    midCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else if (upperCanvas.GetComponent<ChemicalGraph>().generated == false && !tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    upperCanvas.transform.position = transform.position;
                    upperCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else if (lowerCanvas.GetComponent<ChemicalGraph>().generated == false && !tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text) && !tag.Equals(upperCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    lowerCanvas.transform.position = transform.position;
                    lowerCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else
                {
                    Debug.Log("No open graphs to draw to!");
                }
            }
            else
            {
                if (midCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    midCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                else if (upperCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(upperCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    upperCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                else if (lowerCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(lowerCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    lowerCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                m_Renderer.material = m_OverMaterial;

                GameObject[] temp = GameObject.FindGameObjectsWithTag(tag);
                //Debug.Log("Length: " + temp.Length);
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].GetComponent<LineRenderer>() != null)
                    {
                        temp[i].GetComponent<LineRenderer>().startColor = new Color(0, 255, 255, .5f);
                        temp[i].GetComponent<LineRenderer>().endColor = new Color(0, 255, 255, .5f);
                        ParallelCoordinates.hLines--;
                    }
                }
            }
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }

        private void HandleOnA()
        {
            if (generated == false && OVRInput.GetUp(OVRInput.Button.One))
            {
                string tag = gameObject.tag;
                Debug.Log("AAAAA. Show click state: " + tag);
                m_Renderer.material = m_ClickedMaterial;
                if (midCanvas.GetComponent<ChemicalGraph>().generated == false)
                {
                    midCanvas.transform.position = transform.position;
                    midCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else if (upperCanvas.GetComponent<ChemicalGraph>().generated == false && !tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    upperCanvas.transform.position = transform.position;
                    upperCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else if (lowerCanvas.GetComponent<ChemicalGraph>().generated == false && !tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text) && !tag.Equals(upperCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    lowerCanvas.transform.position = transform.position;
                    lowerCanvas.GetComponent<ChemicalGraph>().genGraph(tag);
                    generated = true;
                }
                else
                {
                    Debug.Log("No open graphs to draw to!");
                }
            }
            else
            {
                if (midCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(midCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    midCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                else if (upperCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(upperCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    upperCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                else if (lowerCanvas.GetComponent<ChemicalGraph>().generated == true && tag.Equals(lowerCanvas.GetComponent<ChemicalGraph>().stateTitle.text))
                {
                    lowerCanvas.GetComponent<ChemicalGraph>().Clear();
                    generated = false;
                }
                m_Renderer.material = m_OverMaterial;
            }
        }
    }

}