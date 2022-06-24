using StackingMoney.PlayerMovement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StackingMoney.Stacking
{
    public class StackManager : MonoBehaviour
    {
        public static StackManager stackManager;
        [SerializeField] GameObject moneyPrefab;

        private List<GameObject> nodeList = new List<GameObject>();

        // Singleton
        private void Awake()
        {
            if(stackManager != null)
            {
                Destroy(this);
            }
            else
            {
                stackManager = this;
            }
        }

        private void Start()
        {
            nodeList.Add(transform.GetChild(0).gameObject);
        }

        public void AddMoneyGameobject(GameObject money)
        {
            money.AddComponent<Node>().connectedNode = nodeList.Last().transform;
            nodeList.Add(money.gameObject);
        }

        public void AddMoney(GameObject other)
        {
            other.gameObject.tag = "Untagged";
            int add = Int16.Parse(other.transform.GetChild(0).name);

            for(int i=0; i<add; i++)
            {
                GameObject money = Instantiate(moneyPrefab, Vector3.zero, Quaternion.identity);
                AddMoneyGameobject(money);
            }
        }

        public void SubtractMoney(GameObject other)
        {
            other.gameObject.tag = "Untagged";
            int subtract = Int16.Parse(other.transform.GetChild(0).name);

            if (subtract >= nodeList.Count)
            {
                GameOver();
            }

            for(int i=0; i<subtract; i++)
            {
                GameObject subMoney = nodeList.Last();
                nodeList.RemoveAt(nodeList.Count - 1);
                Destroy(subMoney);
            }
        }

        private void GameOver()
        {
            transform.GetComponent<MovementController>().enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Collectable"))
            {
                other.tag = "Untagged";
                AddMoneyGameobject(other.gameObject);
            }
            if(other.CompareTag("add"))
            {
                AddMoney(other.gameObject);
            }
            else if(other.CompareTag("sub"))
            {
                SubtractMoney(other.gameObject);
            }
        }

    }
}

