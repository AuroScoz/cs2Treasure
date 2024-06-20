using UnityEngine;
using UnityEditor;
using Scoz.Func;

namespace Gladiators.Main {
    [CustomPropertyDrawer(typeof(PostProcessingManager.BloomSettingDicClass))]
    [CustomPropertyDrawer(typeof(ResourcePreSetter.MaterialDicClass))]
    [CustomPropertyDrawer(typeof(GameManager.SceneUIAssetDicClass))]

    public class CustomInfoSerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
}