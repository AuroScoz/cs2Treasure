using DG.Tweening;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using System;
using System.Linq;
using UnityEngine.Events;


namespace MVVM {
    public class DOTweenView : UIView {
        // public
        public bool ControlChild = true;
        public ObservableProperty<bool> Toggle = new ObservableProperty<bool>();
        public UnityAction OnComplete;
        [NonSerialized]
        public bool IgnoreAnimeOnFirstTime = false;
        [NonSerialized]
        public bool Restart = false;
        // private
        private DOTweenAnimation[] tweens = null;

        public void SetToggle(bool toggle) {
            Toggle.Value = toggle;
        }

        void AddLastComplete(DOTweenAnimation[] tweenArray) {
            if (tweenArray == null || tweenArray.Length == 0)
                return;
            if (OnComplete != null) {
                var lastTween = tweenArray.OrderBy(tween => tween.duration + tween.delay).Last();
                if (lastTween != null) lastTween.onComplete?.AddListener(OnComplete);
            }
        }

        void RemoveLastComplete(DOTweenAnimation[] tweenArray) {
            if (tweenArray == null || tweenArray.Length == 0)
                return;
            var lastTween = tweenArray.OrderBy(tween => tween.duration + tween.delay).Last();
            if (lastTween != null) lastTween.onComplete?.RemoveAllListeners();
        }

        public void PlayForward(DOTweenAnimation[] tweenArray) {
            if (tweenArray == null)
                return;

            for (int i = 0; i < tweenArray.Length; ++i) {
                if (Restart) {
                    tweenArray[i].DORestart();
                } else {
                    tweenArray[i].DOPlayForward();
                }

                if (IgnoreAnimeOnFirstTime) {
                    tweenArray[i].DOComplete();
                }
            }

            IgnoreAnimeOnFirstTime = false;
        }

        public void PlayBackwards(DOTweenAnimation[] tweenArray) {
            if (tweenArray == null)
                return;

            for (int i = 0; i < tweenArray.Length; ++i) {
                tweenArray[i].DOPlayBackwards();
                if (IgnoreAnimeOnFirstTime) {
                    tweenArray[i].DORewind();
                }
            }

            IgnoreAnimeOnFirstTime = false;
        }

        protected override void Start() {
            tweens = ControlChild ? GetComponentsInChildren<DOTweenAnimation>() : GetComponents<DOTweenAnimation>();
            AddLastComplete(tweens);
            Toggle.ValueChanged += OnToggleChanged;
            if (Toggle.Value) PlayForward(tweens);
        }

        protected override void OnDestroy() {
            Toggle.ValueChanged -= OnToggleChanged;
            RemoveLastComplete(tweens);
            tweens = null;
        }

        private void OnToggleChanged(object sender, EventArgs e) {
            if (Toggle)
                PlayForward(tweens);
            else
                PlayBackwards(tweens);
        }
    }
}