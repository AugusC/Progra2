using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    private static BulletsManager m_instance;

    public List<Bullet> m_bullets = new List<Bullet>();
   
    public static BulletsManager Instance
    {
        get
        {
            return m_instance;
        }
    }
    
    private void Awake()
    {
        m_instance = this;
    }
    
    
    public void AddBullet(Bullet p_bullet)
    {
        m_bullets.Add(p_bullet);
        
        p_bullet.onHit += () =>
        {
            m_bullets.Remove(p_bullet);
            Destroy(p_bullet.gameObject);
        };
    }
}
