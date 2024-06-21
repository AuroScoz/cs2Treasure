using Scoz.Func;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Cysharp.Threading.Tasks;
using Cinemachine;
using cs2Treasure.Socket;
using Gladiators.Main;

namespace cs2Treasure.Main {
    public class MainManager : MonoBehaviour {
        public static MainManager Instance;
        [SerializeField] Transform[] Cases;
        [SerializeField] Vector3[] CasePos;
        [SerializeField] Vector3[] CaseRot;
        [SerializeField] ParticleSystem Particle_Flash;

        private void Start() {
            Init();
        }

        public void Init() {
            Instance = this;
            ResetGame();
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {
                DropCase(0);
            } else if (Input.GetKeyDown(KeyCode.W)) {
            }
        }
        void ResetGame() {
            Particle_Flash.gameObject.SetActive(false);
            HideCases();
        }

        void HideCases() {
            foreach (var mycase in Cases) {
                mycase.gameObject.SetActive(false);
            }
        }

        public void DropCase(int _lv) {
            ResetGame();
            PlayDrop(_lv).Forget();
        }
        async UniTask PlayDrop(int _lv) {
            Cases[_lv].gameObject.SetActive(true);
            Cases[_lv].transform.localPosition = CasePos[_lv];
            var rndRot = Prob.GetRandomTFromTArray(CaseRot);
            Cases[_lv].transform.rotation = Quaternion.Euler(rndRot);
            await UniTask.Delay(1500);
            Particle_Flash.gameObject.SetActive(true);
            var refSymbols = new string[8] { "", "AK47", "AWP", "DesertEagle", "M4A1", "NOVA", "P250", "AK47" };
            var odds = new float[8] { 0, 0.5f, 1, 2, 3, 4, 5, 6 };
            var weights = new int[8] { 39800, 27000, 13500, 6800, 4500, 3400, 2700, 2300 };
            WeaponItemData[] datas = new WeaponItemData[refSymbols.Length];
            List<MathModel.Item> items = new List<MathModel.Item>();
            for (int i = 0; i < datas.Length; i++) {
                MathModel.Item item = new MathModel.Item(i, odds[i], weights[i]);
                items.Add(item);
                datas[i] = new WeaponItemData(refSymbols[i], odds[i]);
            }
            MathModel.SetItems(items);
            var resultItem = MathModel.GetResult();
            await UniTask.Delay(200);
            WeaponScroller.GetInstance<WeaponScroller>()?.Play(datas, resultItem.Idx);
            MainUI.GetInstance<MainUI>().SetResult(resultItem.Odds);

        }

    }
}
