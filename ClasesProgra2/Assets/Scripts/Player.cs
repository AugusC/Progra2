using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] 
    Bullet m_bulletPrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var l_bullet = Instantiate(m_bulletPrefab);
            l_bullet.Init(transform);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left  * 10 * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right  * 10 * Time.deltaTime);
        }
    }
}
