using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scoz.Func {
    public class ResourcePreSetter : MonoBehaviour {
        [Serializable] public class MaterialDicClass : SerializableDictionary<string, Material> { }

        [HeaderAttribute("==============直接引用的資源==============")]

        [SerializeField] MaterialDicClass MyMaterialDic;//材質字典

        //[HeaderAttribute("==============AssetReference引用的資源==============")]

        public static ResourcePreSetter Instance;

        public void Init() {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static Material GetMaterial(string _str) {
            if (Instance == null || Instance.MyMaterialDic == null) return null;
            return Instance.MyMaterialDic.ContainsKey(_str) ? Instance.MyMaterialDic[_str] : null;
        }


    }
}