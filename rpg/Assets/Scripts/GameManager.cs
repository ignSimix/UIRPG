using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private Player player;
    [SerializeField] private Enemy currentEnemy;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text playerHealthText;
    [SerializeField] private TMP_Text enemyNameText;
    [SerializeField] private TMP_Text enemyHealthText;
    [SerializeField] private TMP_Text shieldStatusText;
    [SerializeField] private TMP_Text gameMessageText;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemyPrefabs;

    private bool isPlayerTurn = true;

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        playerNameText.text = player.PlayerName;
        UpdatePlayerUI();
        SpawnNewEnemy();
    }

    private void SpawnNewEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyObj = Instantiate(enemyPrefabs[randomIndex]);
        currentEnemy = enemyObj.GetComponent<Enemy>();

        UpdateEnemyUI();
        gameMessageText.text = $"A wild {currentEnemy.name} appears!";
    }

    public void PlayerAttack()
    {
        if (!isPlayerTurn || player.IsDead || currentEnemy.IsDead) return;

        int damage = player.Attack();
        currentEnemy.TakeDamage(damage);
        gameMessageText.text = $"{player.PlayerName} attacks for {damage} damage!";

        if (currentEnemy.IsDead)
        {
            gameMessageText.text = $"{currentEnemy.name} was defeated!";
            Invoke("SpawnNewEnemy", 2f);
        }
        else
        {
            isPlayerTurn = false;
            Invoke("EnemyTurn", 1f);
        }

        UpdateEnemyUI();
    }

    public void PlayerSpecialAttack()
    {
        if (!isPlayerTurn || player.IsDead) return;

        int damage = player.SpecialAttack();
        if (damage > 0)
        {
            currentEnemy.TakeDamage(damage);
            gameMessageText.text = $"{player.PlayerName} uses special attack for {damage} damage!";

            if (currentEnemy.IsDead)
            {
                gameMessageText.text = $"{currentEnemy.name} was defeated!";
                Invoke("SpawnNewEnemy", 2f);
            }
            else
            {
                isPlayerTurn = false;
                Invoke("EnemyTurn", 1f);
            }

            UpdatePlayerUI();
            UpdateEnemyUI();
        }
        else
        {
            gameMessageText.text = "Not enough health for special attack!";
        }
    }

    public void ToggleShield()
    {
        player.ToggleShield(!player.IsShieldActive);
        shieldStatusText.text = player.IsShieldActive ? "Shield: Active" : "Shield: Inactive";
    }

    private void EnemyTurn()
    {
        if (currentEnemy.IsDead || player.IsDead) return;

        int damage = currentEnemy.Attack();
        player.TakeDamage(damage);
        gameMessageText.text = $"{currentEnemy.name} attacks for {damage} damage!";

        // Enemy special ability chance
        if (Random.value > 0.7f)
        {
            currentEnemy.SpecialAbility();
        }

        if (player.IsDead)
        {
            gameMessageText.text = "Game Over!";
        }
        else
        {
            isPlayerTurn = true;
        }

        UpdatePlayerUI();
    }

    private void UpdatePlayerUI()
    {
        playerHealthText.text = $"Health: {player.CurrentHealth}";
        shieldStatusText.text = player.IsShieldActive ? "Shield: Active" : "Shield: Inactive";
    }

    private void UpdateEnemyUI()
    {
        enemyNameText.text = currentEnemy.name;
        enemyHealthText.text = $"Health: {currentEnemy.CurrentHealth}";
    }
}