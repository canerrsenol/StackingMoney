using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackingMoney.PlayerCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] CameraSettings _cameraSettings;

        private void Update()
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(_targetTransform.position.x, transform.position.y,
                _targetTransform.position.z - _cameraSettings.ZoffSet), _cameraSettings.LerpSpeed * Time.deltaTime);
        }
    }
}

