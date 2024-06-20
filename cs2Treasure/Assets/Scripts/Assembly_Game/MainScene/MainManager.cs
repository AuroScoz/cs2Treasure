using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;
using Cinemachine;
using cs2Treasure.Socket;

namespace cs2Treasure.Main {
    public class MainManager : MonoBehaviour {
        public static MainManager Instance;
        [SerializeField] Transform[] Cases;
        [SerializeField] Vector3[] CasePos;
        [SerializeField] Vector3[] CaseRot;

        private void Start() {
            Init();
        }

        public void Init() {
            Instance = this;
            HideCases();
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                DropCase(0);
            } else if (Input.GetKeyDown(KeyCode.W)) {
            }
        }

        void HideCases() {
            foreach (var mycase in Cases) {
                mycase.gameObject.SetActive(false);
            }
        }

        public void DropCase(int _lv) {
            HideCases();
            Cases[_lv].gameObject.SetActive(true);
            Cases[_lv].transform.localPosition = CasePos[_lv];
            var rndRot = Prob.GetRandomTFromTArray(CaseRot);
            Cases[_lv].transform.rotation = Quaternion.Euler(rndRot);
        }

    }
}
