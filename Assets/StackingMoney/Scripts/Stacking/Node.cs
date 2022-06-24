using UnityEngine;

namespace StackingMoney.Stacking
{
    public class Node : MonoBehaviour
    {
        public NodeStats nodeStats;
        public Transform connectedNode;

        private void Start()
        {
            transform.position = connectedNode.position + Vector3.forward / 3;
        }

        void Update()
        {
            float lerpedValue = Mathf.Lerp(transform.position.x, connectedNode.position.x, nodeStats.LerpSpeed * Time.deltaTime);
            transform.position = new Vector3(lerpedValue, transform.position.y, connectedNode.position.z + nodeStats.ZOffsetConnectedNode);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                other.tag = "Untagged";
                StackManager.stackManager.AddMoneyGameobject(other.gameObject);
            }
            if (other.CompareTag("add"))
            {
                StackManager.stackManager.AddMoney(other.gameObject);
            }
            else if (other.CompareTag("sub"))
            {
                StackManager.stackManager.SubtractMoney(other.gameObject);
            }
        }
    }
}

