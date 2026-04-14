using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // ESTA LÍNEA ES CLAVE



public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;
    private ARInteractionsManager interactionsManager;
    // Estos son los campos que APARECERÁN en el Inspector ahora
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private RawImage itemRawImage;

    public string ItemName { set => itemName = value; }
    public string ItemDescription { set => itemDescription = value; }
    public Sprite ItemImage { set => itemImage = value; }
    public GameObject Item3DModel { set => item3DModel = value; }

    void Start()
    {
        if (nameText != null) nameText.text = itemName;
        if (descriptionText != null) descriptionText.text = itemDescription;
        if (itemRawImage != null && itemImage != null) itemRawImage.texture = itemImage.texture;

        var button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(GameManager.instance.ARPosition);
            button.onClick.AddListener(Create3DModel);

          interactionsManager = FindObjectOfType<ARInteractionsManager>();
        }
    }


private void Create3DModel()
    {
        if (item3DModel != null) Instantiate(item3DModel);
    }

}