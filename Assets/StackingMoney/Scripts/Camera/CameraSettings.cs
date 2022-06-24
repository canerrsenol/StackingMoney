using UnityEngine;

namespace StackingMoney.PlayerCamera
{
    [CreateAssetMenu(menuName = "StackingMoney/PlayerCamera/Player Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [SerializeField] private float zOffset = 12f;
        [SerializeField] private float lerpSpeed = 2f;

        public float ZoffSet { get { return zOffset; } }
        public float LerpSpeed { get { return lerpSpeed; } }
    }
}