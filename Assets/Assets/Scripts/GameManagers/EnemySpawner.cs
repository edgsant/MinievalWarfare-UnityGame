using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemySpawner : MonoBehaviour, ISpawner
{

    public Transform[] spawnPoints;
    public Unit[] unitsList;

    public float decisionCooldown = 0.7f; // Tiempo entre invocaciones
    private float timer;

    public int money = 0;
    private int selectedPoint = 0;
    private int selectedUnit = 0;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating("spawnUnit",2,3f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= decisionCooldown)
        {
            MakeDecision();
            timer = 0;
        }
    }

    int DangerPlaceCalculation()
    {
        int mejorCarril = Random.Range(0, 5); // Por si acaso
        int maxDanger = -1;

        for (int i = 0; i < 5; i++)
        {
            // Esta función debe contar tus tropas en ese carril específico
            int danger = RowDangerCalculation(i);

            if (danger > maxDanger)
            {
                maxDanger = danger;
                mejorCarril = i;
            }
        }

        if (maxDanger == 0)
        {
            mejorCarril = Random.Range(0, 5);
        }

        return mejorCarril;
    }

    public void spawnUnit()
    {
        if (canCost())
        {
            Unit enemyUnit = Instantiate(unitsList[selectedUnit], spawnPoints[selectedPoint].position, spawnPoints[selectedPoint].rotation);
            enemyUnit.setTeam(1);
            addMoney(-unitsList[selectedUnit].cost);

        }
    }



    public void addMoney(int generatedMoney)
    {
        money += generatedMoney;
    }

    void MakeDecision()
    {
        selectedPoint = DangerPlaceCalculation();
        
        int i = 0;
        do
        {
            i++;
            selectedUnit = Random.Range(0, 11);
        } while (!canCost() && i<4);
        
        //selectedUnit = Random.Range(0, 11);
        spawnUnit();
    }

    bool canCost()
    {
        if (unitsList[selectedUnit].cost <= money)
        {
            return true;
        }
        return false;
    }

    int RowDangerCalculation(int selectedRow)
    {
        Vector2 areaDetectionCenter = new Vector2(0f, spawnPoints[selectedRow].position.y);

        Vector2 areaDetectionSize = new Vector2(60f, 3f);

        Collider2D[] detectedUnits = Physics2D.OverlapBoxAll(areaDetectionCenter, areaDetectionSize, 0f);

        int dangerCounter = 0;

        foreach (Collider2D col in detectedUnits)
        {
            // Buscamos tu componente Unit
            Unit playerUnit = col.GetComponent<Unit>();

            // Si existe y no es de mi equipo, anado peligrosidad
            if (playerUnit != null && playerUnit.team != 1)
            {
                dangerCounter += playerUnit.dangerScore;
            }
            // Si existe y es de mi equipo, resto peligrosidad ya que esta protegido
            else if (playerUnit != null && playerUnit.team == 1)
            {
                dangerCounter -= playerUnit.dangerScore+2;
            }
        }

        return dangerCounter;
    }
}
