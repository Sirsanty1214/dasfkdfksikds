using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// Solo dejamos esta clase aquí. La de DataManager ya vive en su propio archivo DataManager.cs
public class ARInteractionsManager : MonoBehaviour
{
    [SerializeField] private Camera aRCamera;
    private ARRaycastManager aRRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject aRPointer;
    private GameObject item3DModel;
    private bool isInitialPosition;

    public GameObject Item3DModel
    {
        set
        {
            item3DModel = value;
            item3DModel.transform.position = aRPointer.transform.position;
            item3DModel.transform.parent = aRPointer.transform;
            isInitialPosition = true;
        }
    }

    void Start()
    {
        // Corregido: .gameObject (g minúscula)
        aRPointer = transform.GetChild(0).gameObject;
        
        // Corregido: FindObjectOfType (singular) y ARRaycastManager (A mayúscula)
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        
        // Suscripción al evento para fijar el objeto
        GameManager.instance.OnMainMenu += SetItemPosition;
    }

    void Update()
    {
        if (isInitialPosition)
        {
            // Corregido: Vector2 (V mayúscula)
            Vector2 middlePointScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);
            
            if (aRRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes))
            {
                // Posicionamos el puntero en el plano detectado
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;
                
                if (!aRPointer.activeInHierarchy)
                    aRPointer.SetActive(true);
            }
        }
    }

    private void SetItemPosition()
    {
        if (item3DModel != null)
        {
            item3DModel.transform.parent = null;
            aRPointer.SetActive(false);
            item3DModel = null;
            isInitialPosition = false;
        }
    }

 private void Create3DModel()
    {
        if (item3DModel != null) Instantiate(item3DModel);
    }
    public void DeleteItem()
{
    Destroy(item3DModel);
    aRPointer.SetActive(false);
    GameManager.instance.MainMenu();
}
}