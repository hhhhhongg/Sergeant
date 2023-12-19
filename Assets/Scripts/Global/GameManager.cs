using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player { get; private set; }
    [SerializeField] private string playerTag = "Player";

    private HealthSystem playerHealthSystem;

    //[SerializeField] private TextMeshProUGUI waveText;
    //[SerializeField] private Slider hpGaugeSlider;
    //[SerializeField] private GameObject gameOverUI;
    [SerializeField] private CharacterStats defaultStats;
    [SerializeField] private CharacterStats rangedStats;

    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnposCount = 0;

    public float spawnInterval = 0.5f;
    public List<GameObject> enemyPrefebs = new List<GameObject>();

    //[SerializeField] private Transform spawnPositionsRoot;
    private List<Transform> spawnPostions = new List<Transform>();

    public List<GameObject> rewards = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
        playerHealthSystem = player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDamage += UpdateHealthUI;
        playerHealthSystem.OnHeal += UpdateHealthUI;
        playerHealthSystem.OnDeath += GameOver;

        //gameOverUI.SetActive(false);
        /*
        for(int i = 0; i < spawnPositionsRoot.childCount; i++)
        {
            spawnPostions.Add(spawnPositionsRoot.GetChild(i));
        }
        */
        
    }

    private void Start()
    {
        UpgradeStatInit();
        StartCoroutine("StartNextWave");        
    }

    IEnumerator StartNextWave()
    {
        while(true)
        {
            if(currentSpawnCount == 0)
            {
                UpdateWaveUI();
                yield return new WaitForSeconds(2f); //ĳ���� ����
                if (currentWaveIndex % 20 == 0)
                {
                    RandomUpgrade();
                }

                if (currentWaveIndex % 10 == 0)
                {
                    waveSpawnposCount = waveSpawnposCount + 1 > spawnPostions.Count ? waveSpawnposCount : waveSpawnposCount + 1;
                    waveSpawnCount = 0;
                }

                if(currentWaveIndex % 5 == 0)
                {
                    CreateReward();
                }

                if(currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                }

                for(int i = 0; i < waveSpawnposCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPostions.Count);
                    for (int j = 0; j < waveSpawnCount; j++) 
                    { 
                        int prefabIdx = Random.Range(0, enemyPrefebs.Count);
                        GameObject enemy = Instantiate(enemyPrefebs[prefabIdx], spawnPostions[prefabIdx].position, Quaternion.identity);
                        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
                        enemy.GetComponent<CharacterStatsHandler>().AddStatModifier(defaultStats);
                        enemy.GetComponent<CharacterStatsHandler>().AddStatModifier(rangedStats);
                        currentSpawnCount++;
                        yield return new WaitForSeconds(spawnInterval);

                    }
                }
                currentWaveIndex++;
            }
            yield return null;
        }
    }
    void CreateReward()
    {
        /*
        int idx = Random.Range(0, rewards.Count);
        int posIdx = Random.Range(0, spawnPostions.Count);

        GameObject obj = rewards[idx];
        Instantiate(obj, spawnPostions[posIdx].position, Quaternion.identity);
        */
    }
    void UpgradeStatInit()
    {
        defaultStats.statsChangeType = StatsChangeType.Add;
        defaultStats.attackSO = Instantiate(defaultStats.attackSO);

        rangedStats.statsChangeType = StatsChangeType.Add;
        rangedStats.attackSO = Instantiate(rangedStats.attackSO);
    }

    void RandomUpgrade()
    {
        switch (Random.Range(0, 6))
        {
            case 0:
                defaultStats.maxHealth += 2;
                break;

            case 1:
                defaultStats.attackSO.power += 1;
                break;

            case 2:
                defaultStats.speed += 0.1f;
                break;

            case 3:
                defaultStats.attackSO.isOnKnockback = true;
                defaultStats.attackSO.knockbackPower += 1;
                defaultStats.attackSO.knockbackTime = 0.1f;
                break;

            case 4:
                defaultStats.attackSO.delay -= 0.05f;
                break;

            case 5:
                RangedAttackData rangedAttackData = rangedStats.attackSO as RangedAttackData;
                rangedAttackData.numberofProjectilesPerShot += 1;
                break;

            default:
                break;
        }
    }
    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }

    private void UpdateHealthUI()
    {
        //hpGaugeSlider.value = playerHealthSystem.CurrentHealth / playerHealthSystem.MaxHealth;
    }

    private void GameOver()
    {
        //gameOverUI.SetActive(true);
        StopAllCoroutines();
    }

    private void UpdateWaveUI()
    {
        //waveText.text = (currentWaveIndex + 1).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}