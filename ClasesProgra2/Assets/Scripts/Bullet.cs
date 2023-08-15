using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        public event Action onHit;


        public void Init(Transform p_initTransform)
        {
            transform.position = p_initTransform.position;
            transform.rotation = p_initTransform.rotation;
            BulletsManager.Instance.AddBullet(this);
        }
        
        private void Update()
        {
            transform.Translate(Vector3.forward * 10
                                                * Time.deltaTime);

            if (transform.position.z > 100)
            {
                onHit?.Invoke();
            }
        }
    }
}