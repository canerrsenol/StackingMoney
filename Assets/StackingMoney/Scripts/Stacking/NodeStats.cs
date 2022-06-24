using UnityEngine;

namespace StackingMoney.Stacking
{
    [CreateAssetMenu(menuName = "StackingMoney/Stacking/Node Stats")]
    public class NodeStats : ScriptableObject
    {
        [SerializeField] private float lerpSpeed = 7f;
        [SerializeField] private float zOffsetConnectedNode = 0.3f;

        public float LerpSpeed { get { return lerpSpeed; } }
        public float ZOffsetConnectedNode { get { return zOffsetConnectedNode; } }
    }
}

