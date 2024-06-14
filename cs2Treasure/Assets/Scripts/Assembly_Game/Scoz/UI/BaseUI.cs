using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scoz.Func;
using UnityEngine.UI;
using System;

namespace Scoz.Func {
    public abstract class BaseUI : MonoBehaviour {
        protected bool IsInit = false;
        public static Dictionary<string, BaseUI> UIDic = new Dictionary<string, BaseUI>();
        public static bool operator true(BaseUI baseUI) { return baseUI != null; }
        public static bool operator false(BaseUI baseUI) { return baseUI == null; }


        public static T GetInstance<T>() where T : BaseUI {
            string name = typeof(T).FullName;
            if (!UIDic.ContainsKey(name))
                return null;
            return (T)UIDic[name];
        }
        public virtual void Init() {
            if (IsInit)
                return;

            List<string> keys = new List<string>(UIDic.Keys);
            foreach (var key in keys) {
                if (UIDic[key] == null || UIDic[key].gameObject == null) {
                    UIDic.Remove(key);
                }
            }
            UIDic[this.GetType().FullName] = this;

            IsInit = true;
            MyText.AddRefreshFunc(RefreshText);
        }
        protected virtual void OnEnable() {

        }
        protected virtual void OnDisable() {

        }
        protected virtual void OnDestroy() {
            MyText.RemoveRefreshFunc(RefreshText);
            UIDic[this.GetType().FullName] = null;
            Destroy(gameObject);
        }
        /// <summary>
        /// 把在地化文字加到這裡會隨著切換語系時自動切換
        /// </summary>
        public abstract void RefreshText();

        /// <summary>
        /// 開關介面用這個
        /// </summary>
        public virtual void SetActive(bool _bool) {
            gameObject.SetActive(_bool);
        }
    }
}
