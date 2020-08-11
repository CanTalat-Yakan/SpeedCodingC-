using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[DefaultExecutionOrder(50)]
public class GameManager : MonoBehaviour
{
    List<Enemy> m_enemyList = new List<Enemy>();

    void Awake()
    {
        Enemy[] m_enemyArray = FindObjectsOfType<Enemy>();// GetComponents<Enemy>();
        m_enemyList = m_enemyArray.ToList();
        //AccessController.Instance.GetComponent<AccessController>().enabled = false;
    }

    void Update()
    {
        //CheckHp();
    }

    void CheckHp()
    {
        
        Application.LogCallback();
        foreach (Enemy enemy in m_enemyList)
        {
            Debug.Log(enemy.CurrentHP);
            if (enemy.CurrentHP == 0)
            {
                //enemy.CancelInvoke();
                Destroy(enemy.gameObject);
            }
        }
    }

}
