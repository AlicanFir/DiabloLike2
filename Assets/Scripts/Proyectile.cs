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
    }
}