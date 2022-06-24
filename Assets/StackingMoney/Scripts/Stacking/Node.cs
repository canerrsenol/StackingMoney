using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackingMoney.Stacking
{
    public class Node : MonoBehaviour
    {
        public Transform connectedNode;
        public float lerpSpeed = 5f;

        public float LerpSpeed { get { return lerpSpeed; } }

        private void Start()
        {
            transform.position = connectedNode.position + Vector3.forward / 5;
        }

        void Update()
        {
            float lerpedValue = Mathf.Lerp(transform.position.x, connectedNode.position.x, lerpSpeed * Time.deltaTime);
            transform.position = new Vector3(lerpedValue, transform.position.y, connectedNode.position.z + 0.3f);
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

