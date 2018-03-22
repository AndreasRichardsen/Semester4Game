using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Spawner : MonoBehaviour
    {
        public GameObject myPrefab;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var newObj = Instantiate(myPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            }
        }
    }
}
