using DG.Tweening;
using Loxodon.Framework.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM {
    public class DOTweenController : UIView {
        private DOTweenAnimation[] tweens = null;
        public bool IncludeChildren = false;
        public bool Skip = false;
        public bool PlayToggle = false;
        private bool lastPlayToggle = false;

        public void Update() {
            if (lastPlayToggle != PlayToggle) {
                lastPlayToggle = PlayToggle;
                if (lastPlayToggle)
                    Play();
                else
                    Pause();
            }
        }

        private void Play() {
            GetDOTweenAnimations();

            foreach (var tween in tweens) {
                tween.DOPlay();
                if (Skip) tween.DOComplete();
            }
        }

        private void Pause() {
            GetDOTweenAnimations();

            foreach (var tween in tweens) {
                tween.DOPause();
            }
        }

        private void GetDOTweenAnimations() {
            if (tweens == null) {
                if (IncludeChildren) tweens = GetComponentsInChildren<DOTweenAnimation>();
                else tweens = GetComponents<DOTweenAnimation>();
            }
        }
    }
}
