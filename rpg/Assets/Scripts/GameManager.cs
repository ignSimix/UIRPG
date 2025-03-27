using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Character character;
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText;
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = player.CharName;
        enemyNameText.text = enemy.name;
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = enemy.health.ToString();
    }

    public void DoRound()
    {
        int playerDamage = player.Attack();
        enemy.GetHit(playerDamage);
        int enemyDamage = enemy.Attack();
        player.GetHit(enemyDamage);
        playerHealthText.text = player.health.ToString();
        enemyHealthText.text = enemy.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
