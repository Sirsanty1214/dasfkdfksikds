using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject itemsMenuCanvas; // Corregido: minúscula inicial por convención
    [SerializeField] private GameObject arPositionCanvas; // Cambiado nombre para evitar conflicto con métodos

    // IMPORTANTE: En Unity, el método debe ser "Start" con S mayúscula
    void Start() 
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnMainMenu += ActivateMainMenu;
            GameManager.instance.OnItemsMenu += ActivateItemsMenu;
            
            // Verifica que en GameManager 'OnARPosition' sea un evento (Action)
            // Si el error persiste, asegúrate de que no estás llamando al método en lugar del evento
            GameManager.instance.OnARPosition += ActivateARPosition; 
        }
    }

    private void ActivateMainMenu()
    {
        mainMenuCanvas.transform.GetChild(0).DOScale(new Vector3(1, 1, 1), 0.3f);
        mainMenuCanvas.transform.GetChild(1).DOScale(new Vector3(1, 1, 1), 0.3f);

        itemsMenuCanvas.transform.GetChild(0).DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsMenuCanvas.transform.GetChild(1).DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsMenuCanvas.transform.GetChild(1).DOMoveY(180f, 0.3f);

        arPositionCanvas.transform.GetChild(0).DOScale(new Vector3(0, 0, 0), 0.3f);
        arPositionCanvas.transform.GetChild(1).DOScale(new Vector3(0, 0, 0), 0.3f);
    }

    private void ActivateItemsMenu()
    {
        mainMenuCanvas.transform.GetChild(0).DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).DOScale(new Vector3(0, 0, 0), 0.3f);
        

        itemsMenuCanvas.transform.GetChild(0).DOScale(new Vector3(1, 1, 1), 0.5f);
        itemsMenuCanvas.transform.GetChild(1).DOScale(new Vector3(1, 1, 1), 0.3f);
        itemsMenuCanvas.transform.GetChild(1).DOMoveY(300f, 0.3f);
    }

    private void ActivateARPosition()
    {
        mainMenuCanvas.transform.GetChild(0).DOScale(new Vector3(0, 0, 0), 0.3f);
        mainMenuCanvas.transform.GetChild(1).DOScale(new Vector3(0, 0, 0), 0.3f);

        itemsMenuCanvas.transform.GetChild(0).DOScale(new Vector3(0, 0, 0), 0.5f);
        itemsMenuCanvas.transform.GetChild(1).DOScale(new Vector3(0, 0, 0), 0.3f);
        itemsMenuCanvas.transform.GetChild(1).DOMoveY(180f, 0.3f);

        arPositionCanvas.transform.GetChild(0).DOScale(new Vector3(1, 1, 1), 0.3f);
        arPositionCanvas.transform.GetChild(1).DOScale(new Vector3(1, 1, 1), 0.3f);
    }
}
