using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
     [SerializeField] private Transform _left;
     [SerializeField] private Transform _right;
     [SerializeField] private float _speed;
    
     private float _currentTime;
     private bool _isMovingRight;
     private float _wayTime;
    
     private void Start()
     {
         _wayTime = Vector3.Distance(_left.position, _right.position) / _speed;
     }
     
     private void LateUpdate()
     {
         if (Input.GetKey(KeyCode.Space))
         {
             _isMovingRight = !_isMovingRight;
         }
    
         _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;
         var progress = Mathf.PingPong(_currentTime, _wayTime) / _wayTime;
         transform.position = Vector3.Lerp(_left.position, _right.position, progress);
     }
}
