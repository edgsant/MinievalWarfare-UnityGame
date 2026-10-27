using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour, ISpawner, ISelectableUnit
{

    public Transform[] spawnPoints;
    public Unit[] unitsList;
    private InputAction playerMovement;
    private InputAction playerInteract;
    public int playerSelectedPoint=0;
    public int playerSelectedUnit=0;

    public SpriteRenderer arrow;
    public SpriteRenderer unitSprite;

    public event System.Action<int> OnUnitSelected;

    //private float placeCooldown = 0.75f;
    //private float placeTimer = 0f;

    public float selectCooldown = 0.125f;
    private float selectTimer = 0f;

    public int money = 0;
    public TextMeshProUGUI moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = InputSystem.actions.FindAction("Move");
        playerInteract = InputSystem.actions.FindAction("Interact");
        changeSpritePosition();
        changeSpriteUnit();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement == null || playerInteract == null) return;

        selectTimer -= Time.deltaTime;

        Vector2 moveValue = playerMovement.ReadValue<Vector2>();
        if (selectTimer <= 0f) {
            if (moveValue.y > 0)
            {
                selectPreviousPosition();
                selectTimer = selectCooldown;
            }
            if (moveValue.y < 0)
            {
                selectNextPosition();
                selectTimer = selectCooldown;
            }
            if (moveValue.x > 0)
            {
                selectNextUnit();
                selectTimer = selectCooldown;
            }
            if (moveValue.x < 0)
            {
                selectPreviousUnit();
                selectTimer = selectCooldown;
            }

        }
        if (playerInteract.WasPressedThisFrame()) { spawnUnit(); }
    }

    void selectNextPosition()
    {
        playerSelectedPoint = (playerSelectedPoint + 1) % spawnPoints.Length;
        changeSpritePosition();

    }
    void selectPreviousPosition()
    {
        playerSelectedPoint = (playerSelectedPoint - 1 + spawnPoints.Length) % spawnPoints.Length;
        changeSpritePosition();

    }

    void selectNextUnit()
    {
        playerSelectedUnit = (playerSelectedUnit + 1) % unitsList.Length;
        changeSpriteUnit();
        OnUnitSelected?.Invoke(playerSelectedUnit);
    }
    void selectPreviousUnit()
    {
        playerSelectedUnit = (playerSelectedUnit - 1 + unitsList.Length) % unitsList.Length;
        changeSpriteUnit();
        OnUnitSelected?.Invoke(playerSelectedUnit);
    }

    public void selectUnit(int unitIndex)
    {
        playerSelectedUnit = unitIndex;
        changeSpriteUnit();
        OnUnitSelected?.Invoke(playerSelectedUnit);
    }

    public void spawnUnit()
    {
        if (canCost())
        {
            Unit playerUnit = Instantiate(unitsList[playerSelectedUnit], spawnPoints[playerSelectedPoint].position, spawnPoints[playerSelectedPoint].rotation);
            playerUnit.setTeam(0);
            addMoney(-unitsList[playerSelectedUnit].cost);

        }
        
    }

    void changeSpriteUnit()
    {
        unitSprite.sprite = unitsList[playerSelectedUnit].GetComponent<SpriteRenderer>().sprite;
    }

    void changeSpritePosition()
    {
        arrow.transform.position = spawnPoints[playerSelectedPoint].position + Vector3.down;
        unitSprite.transform.position = spawnPoints[playerSelectedPoint].position + Vector3.right;
    }

    public void addMoney(int generatedMoney)
    {
        money += generatedMoney;
        moneyText.text = money.ToString();
    }

    bool canCost()
    {
        if (unitsList[playerSelectedUnit].cost <= money)
        {
            return true;
        }
        return false;
    }
}
