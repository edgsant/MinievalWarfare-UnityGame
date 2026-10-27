using TMPro;
using Unity.VisualScripting; // ¡Necesario para controlar el foco de la UI!
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Necesario para componentes Button, Image, etc.
// using UnityEngine.UIElements; // Este using no es de Unity UI estándar, puedes quitarlo

public class SelectionController : MonoBehaviour
{

    [SerializeField]
    private GameObject playerSpawnerGO;

    private ISelectableUnit playerSpawner;

    [SerializeField]
    private GameObject[] buttonList;
    [SerializeField] 
    private RectTransform highlight;

    private int lastSelectedIndex = 0;

    [SerializeField]
    private Unit[] unitList;

    public TextMeshProUGUI unitName;
    public TextMeshProUGUI unitDesc;


    void Start()
    {
        playerSpawner = playerSpawnerGO.GetComponent<ISelectableUnit>();
        int i = 0;
        if (playerSpawner != null)
        {
            // ¡SUSCRIPCIÓN!
            playerSpawner.OnUnitSelected += UpdateUnitSelectionUI;

            // Llama a la selección inicial para mostrar el estado inicial
            playerSpawner.selectUnit(0);
        }
        foreach (var button in buttonList)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = unitList[i].cost.ToString();
            i++;
        }
    }

    private void UpdateUnitSelectionUI(int selectedIndex)
    {
        highlight.gameObject.SetActive(true);
        RectTransform rt = highlight.GetComponent<RectTransform>();

        // Mover al botón seleccionado
        rt.SetParent(buttonList[selectedIndex].transform, false);

        // Asegurar que queda encima
        rt.SetSiblingIndex(1);


        // Centrado seguro sin alterar tamaño
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = Vector2.zero;

        // Importante: NO tocar offsetMin/offsetMax
        // Importante: NO usar rt.sizeDelta = Vector2.zero
        unitName.text = unitList[selectedIndex].unitData.unitName;
        unitDesc.text = unitList[selectedIndex].unitData.unitDescription;

    }







    // Este método es llamado por el OnClick() de los botones en el Inspector
    public void selectUnit(int unitIndex)
    {
        // Llama al Spawner, el Spawner actualizará su estado y disparará el evento.
        // El evento llamará a UpdateUnitSelectionUI para actualizar el foco UI.
        playerSpawner.selectUnit(unitIndex);
    }

    private void OnDestroy()
    {
        if (playerSpawner != null)
        {
            playerSpawner.OnUnitSelected -= UpdateUnitSelectionUI;
        }
    }
}
