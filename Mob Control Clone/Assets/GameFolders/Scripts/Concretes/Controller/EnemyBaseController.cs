using PlayerMove.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public int count;

    EnemySpawnController _enemySpawnController;

    private void Start()
    {
        _enemySpawnController= GetComponent<EnemySpawnController>();
        StartCoroutine(SpawnEnemyGroup());
    }
    // Update is called once per frame
    void Update()
    {
        if (count != 0)
        {
            text.text = "" + count;
        }
        if(count==0) 
        {
            GameManager.Instance.GameWinning();
        }   
    }
    private IEnumerator SpawnEnemyGroup()
    {
        yield return new WaitForSeconds(UnityEngine.Random.RandomRange(2, 5));
        _enemySpawnController.SpawnEnemies(UnityEngine.Random.RandomRange(2, 5));
    }
}
