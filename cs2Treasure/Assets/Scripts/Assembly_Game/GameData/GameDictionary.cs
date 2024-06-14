using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

namespace Scoz.Func {
    public partial class GameDictionary : MonoBehaviour {

        [SerializeField]
        List<Font> SysFonts = null;
        [SerializeField]
        List<TMPro.TMP_FontAsset> SysFontAssets = null;


        public static GameDictionary Instance;

        public static bool IsInit { get; private set; }



        public static Font GetUsingLanguageFont() {
            if (Instance == null)
                return Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            else {
                int index = (int)MyPlayer.Instance.UsingLanguage;
                if (index < Instance.SysFonts.Count && Instance.SysFonts[index] != null)
                    return Instance.SysFonts[index];
            }
            return Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        }
        public static TMPro.TMP_FontAsset GetUsingLanguageFontAsset() {
            if (Instance != null) {
                int index = (int)MyPlayer.Instance.UsingLanguage;
                if (index < Instance.SysFonts.Count && Instance.SysFonts[index] != null)
                    return Instance.SysFontAssets[index];
            }
            return null;
        }

        /// <summary>
        /// 設定字典
        /// </summary>
        public void InitDic() {
            if (IsInit)
                return;
            Instance = this;
            IsInit = true;
            LoadLocalJson();//初始化後先載一份本機string跟GameSetting
            DontDestroyOnLoad(gameObject);
        }
        /// <summary>
        /// 讀取本機的String表
        /// </summary>
        void LoadLocalJson() {
            StringDic = JsonString.SetStringDic();
            StrKeyJsonDic["GameSetting"] = JsonBase.SetDataStringKey<JsonGameSetting>();
        }
    }
}
