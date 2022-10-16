using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public Transform SpawnCenter; 
    [SerializeField] public List<GameObject> EnemyTypes; 
    public float SpawnRadius = 100.0f;
    public float SpawnCooldown = 1.0f;
    public Vector3 SpawnPosOffset = new Vector3(0.0f, 3.0f, 0.0f);
    
    private Vector3 m_AuxVector = new Vector3(1.0f, 0.0f, 0.0f);
    private float m_Timeout;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Timeout = SpawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Timeout > 0)
        {
            m_Timeout -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            m_Timeout = SpawnCooldown;
        }

    }
    
    private Vector3 GetCirclePoint()
    {
        return Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.up) * new Vector3(SpawnRadius, 0.0f, 0.0f);
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyTypes[0], GetCirclePoint() + SpawnPosOffset, Quaternion.identity);
    }
}
