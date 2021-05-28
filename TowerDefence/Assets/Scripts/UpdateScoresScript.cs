using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateScoresScript : MonoBehaviour
{
    void Update()
    {

        EnemySpanerScript spawner = GameObject.Find("StartBlock(Clone)").GetComponent<EnemySpanerScript>();
        PlayerScript player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Your Score is " + player.PlayerScore.ToString();
         transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Money: " + player.PlayerMoney.ToString() + "$";

        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Enemies Left: " + spawner.EnemyRemaining.ToString();
         transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Lifes Left: " + player.PlayerHealth.ToString();

    }
}
