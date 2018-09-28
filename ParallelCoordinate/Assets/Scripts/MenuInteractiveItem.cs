using UnityEngine;
using DataStarter;

namespace DataStarter
{

    public class MenuInteractiveItem : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        
        private bool generated = false;

        private void Awake()
        {
            m_Renderer.material = m_NormalMaterial;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");//this changes the color of material on the next line.
            if (!generated)
            {
                m_Renderer.material = m_OverMaterial;
            }
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            if (!generated)
            {
                m_Renderer.material = m_NormalMaterial;
            }
        }


        //Handle the Click event
        private void HandleClick()
        {
            
            if (gameObject.CompareTag("Clean")) {
                StatePercents.type = 0;
            }else if (gameObject.CompareTag("Carc"))
            {
                StatePercents.type = 1;
            }
            else if (gameObject.CompareTag("Metals"))
            {
                StatePercents.type = 2;
            }
            else if (gameObject.CompareTag("Fed"))
            {
                StatePercents.type = 3;
            }
            if (!generated)
            {
                m_Renderer.material = m_ClickedMaterial;
                generated = true;
            }
            else
            {
                m_Renderer.material = m_NormalMaterial;
                generated = false;
            }

        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}