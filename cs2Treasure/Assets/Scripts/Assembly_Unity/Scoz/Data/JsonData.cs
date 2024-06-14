using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using System.Linq;
using UnityEngine.AddressableAssets;
using Gladiators.Main;

namespace Scoz.Func {
    /// <summary>
    /// 這是Excel輸出的Json資料父類別，繼承自這個類的都是Excel表輸出的資料
    /// </summary>
    public abstract partial class MyJsonData_UnityAssembly {

        /// <summary>
        /// 重置靜態資料，當Addressable重載json資料時需要先呼叫這個方法來重置靜態資料
        /// </summary>
        protected abstract void ResetStaticData();

    }
}
