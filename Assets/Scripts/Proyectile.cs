using System;
using Unity.Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class Proyectile : MonoBehaviour
    {
        [SerializeField] private float proyectileSpeed;
        
        private void Start()
        {
            GetComponent<Rigidbody>().linearVelocity = proyectileSpeed * transform.forward;
        }

        private void Update()
        {
            float timer = 0f;
            if (timer >= 20)
            {
                Destroy(this.gameObject);
            }
            timer += Time.deltaTime;
        }
    }
}