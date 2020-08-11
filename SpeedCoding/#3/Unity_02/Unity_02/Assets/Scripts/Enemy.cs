using UnityEngine;

[DefaultExecutionOrder(-100)]
[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    public float CurrentHP
    {
        get
        {
            AccessController.Instance.AddAccess();
            if (!AccessController.Instance.CanAccess())
                return -1;
            return m_currentHP;
        }
        private set
        {
            m_currentHP = Mathf.Max(0, value);
        }
    }

    private float m_currentHP;
    private int m_depletionRate;

    private void Awake()
    {
        m_currentHP = 100;
        m_depletionRate = Random.Range(3, 10);
    }

    private void Update()
    {
        m_currentHP -= m_depletionRate * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (m_currentHP <= 0)
        {
            Debug.LogError("Die HP des Gegners waren 0, er wurde aber nicht zerstört!", this);
        }
    }

    private void OnDestroy()
    {
        if (m_currentHP > 0)
        {
            Debug.LogError($"Die HP des Gegners waren nicht 0, als er zerstört wurde!", this);
        }
    }
}