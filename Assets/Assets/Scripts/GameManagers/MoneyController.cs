using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyController : MonoBehaviour
{

    public int moneyStart = 125;
    public int moneyGenerationStart = 25;
    public int moneyIncreased = 10;
    public int moneyGenerationCurrent = 0;

    public float timeGeneration = 5f;
    public float timeIncrease = 20f;
    public float timeIncreaseIncreased = 40f;


    public GameObject player1SpawnerGO;
    public GameObject player2SpawnerGO;

    private ISpawner player1Spawner;
    private ISpawner player2Spawner;

    public AudioClip moneySound;


    private void Awake()
    {
        if (player1SpawnerGO != null && player2SpawnerGO != null)
        {
            player1Spawner = player1SpawnerGO.GetComponent<ISpawner>();
            player2Spawner = player2SpawnerGO.GetComponent<ISpawner>();
        }
    }

    private void Start()
    {
        addPlayersMoney(moneyStart);
        moneyGenerationCurrent = moneyGenerationStart;

        StartCoroutine(moneyGeneration());
        StartCoroutine(moneyIncrease());
        StartCoroutine(moneyIncreaseIncreased());
    }

    //Cada timeGeneration tiempo, anade dinero a los jugadores
    IEnumerator moneyGeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeGeneration);
            addPlayersMoney(moneyGenerationCurrent);
        }
    }

    //Cada timeIncrease tiempo, aumenta el dinero que reciben los jugadores
    IEnumerator moneyIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeIncrease);
            moneyGenerationCurrent += moneyIncreased;
        }
    }


    //Cada timeIncreaseIncreased tiempo, aumenta el dinero que aumenta lo que reciben los jugadores cada cierto tiempo
    IEnumerator moneyIncreaseIncreased()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeIncreaseIncreased);
            moneyIncreased += 5;
        }
    }

    void addPlayersMoney(int money)
    {
        player1Spawner.addMoney(money);
        player2Spawner.addMoney(money);
        AudioManager.Instance.PlaySFX(moneySound, 1f);
    }
}
