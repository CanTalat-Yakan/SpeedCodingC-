using UnityEngine;

[DefaultExecutionOrder(-50)]
public class AccessController : MonoBehaviour
{
    public const int MAX_ACCESS_PER_FRAME = 3;
    public static AccessController Instance { get; private set; }

    public int FrameAccess
    {
        get
        {
            return m_frameAccess;
        }
    }

    private int m_frameAccess;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Update()
    {
        m_frameAccess = 0;
    }

    public void AddAccess()
    {
        m_frameAccess++;
    }

    public bool CanAccess()
    {
        return m_frameAccess <= MAX_ACCESS_PER_FRAME;
    }
}
