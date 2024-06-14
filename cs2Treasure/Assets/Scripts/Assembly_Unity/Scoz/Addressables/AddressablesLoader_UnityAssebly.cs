
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

namespace Scoz.Func {
    public sealed class AddressablesLoader_UnityAssebly {
        public static void GetAssetRef<T>(AssetReference _ref, Action<T> _cb) {
            Addressables.LoadAssetAsync<T>(_ref).Completed += handle => {

                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
            };
        }
        public static void GetScriptableObjectByRef(AssetReference _ref, Action<ScriptableObject, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<ScriptableObject>(_ref).Completed += handle => {
                _cb?.Invoke(handle.Result, handle);
            };
        }
        public static void GetSpriteByRef(AssetReference _ref, Action<Sprite, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<Sprite>(_ref).Completed += handle => {
                _cb?.Invoke(handle.Result, handle);
            };
        }
        public static void GetAudioClipByRef(AssetReference _ref, Action<AudioClip, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<AudioClip>(_ref).Completed += handle => {
                _cb?.Invoke(handle.Result, handle);
                //Addressables.Release(handle);
            };
        }
        public static void GetTextureByRef(AssetReference _ref, Action<Texture, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<Texture>(_ref).Completed += handle => {
                _cb?.Invoke(handle.Result, handle);
            };
        }
        public static void GetPrefabByRef(AssetReference _ref, Action<GameObject, AsyncOperationHandle> _cb, Action _notExistCB = null) {
            if (!_ref.RuntimeKeyIsValid()) {
#if UNITY_EDITOR
                WriteLog_UnityAssembly.LogError("不合法的Prefab AssetReference:" + _ref.editorAsset.name);
#endif
                return;
            }
            Addressables.LoadResourceLocationsAsync(_ref).Completed += check => {
                if (check.Status == AsyncOperationStatus.Succeeded) {
                    if (check.Result.Count > 0) {
                        Addressables.LoadAssetAsync<GameObject>(_ref).Completed += handle => {
                            switch (handle.Status) {
                                case AsyncOperationStatus.Succeeded:
                                    _cb?.Invoke(handle.Result, handle);
                                    break;
                                default:
                                    WriteLog_UnityAssembly.LogErrorFormat("載入失敗: " + _ref);
                                    _notExistCB?.Invoke();
                                    break;
                            }
                        };
                    } else {
                        WriteLog_UnityAssembly.LogErrorFormat("找不到Prefab: " + _ref);
                        _notExistCB?.Invoke();
                    }
                } else {
                    WriteLog_UnityAssembly.LogErrorFormat("找不到Prefab:" + _ref);
                    _notExistCB?.Invoke();
                }
            };
        }
        public static void GetMaterialByRef(AssetReference _ref, Action<Material, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<Material>(_ref).Completed += handle => {
                _cb?.Invoke(handle.Result, handle);
            };
        }
        public static void GetResourceByFullPath<T>(string _fullPpath, Action<T, AsyncOperationHandle> _cb) {
            Addressables.LoadAssetAsync<T>(_fullPpath).Completed += handle => {
                if (_fullPpath == "") {
                    _cb?.Invoke(default(T), handle);
                    return;
                }
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result, handle);
                        break;
                    default:
                        //WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
                //Addressables.Release(handle);
            };
        }
        public static async UniTask<Tuple<T, AsyncOperationHandle>> GetResourceByFullPath_Async<T>(string _fullPath) {
            var handle = Addressables.LoadAssetAsync<T>(_fullPath);
            await handle.ToUniTask();

            if (_fullPath == "") {
                return new Tuple<T, AsyncOperationHandle>(default(T), handle);
            }

            switch (handle.Status) {
                case AsyncOperationStatus.Succeeded:
                    return new Tuple<T, AsyncOperationHandle>(handle.Result, handle);
                default:
                    // WriteLog.LogError("讀取資源失敗:" + _path);
                    return new Tuple<T, AsyncOperationHandle>(default(T), handle);
            }
        }


        public static void GetPrefabResourceByPath<T>(string _path, Action<T, AsyncOperationHandle> _cb) {
            _path = string.Format("Assets/AddressableAssets/Prefabs/{0}", _path);
            Addressables.LoadAssetAsync<T>(_path).Completed += handle => {
                if (_path == "") {
                    _cb?.Invoke(default(T), handle);
                    return;
                }
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result, handle);
                        break;
                    default:
                        //WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
                //Addressables.Release(handle);
            };
        }
        static Dictionary<string, SpriteAtlas> SpriteAtlasDic = new Dictionary<string, SpriteAtlas>();
        public static void PreloadSpriteAtlas(string _path) {
            if (_path == "")
                return;

            _path = string.Format("Assets/AddressableAssets/Atlas/{0}.spriteatlasv2", _path);
            if (SpriteAtlasDic.ContainsKey(_path))
                return;
            else {
                Addressables.LoadAssetAsync<SpriteAtlas>(_path).Completed += handle => {
                    switch (handle.Status) {
                        case AsyncOperationStatus.Succeeded:
                            if (!SpriteAtlasDic.ContainsKey(_path)) {
                                SpriteAtlasDic.Add(_path, handle.Result);
                            }
                            break;
                        default:
                            // WriteLog.LogError("讀取資源失敗:" + _path);
                            break;
                    }
                    //Addressables.Release(handle);
                };
            }
        }


        public static void GetSpriteAtlas(string _path, Action<SpriteAtlas> _cb) {
            if (_path == "") {
                _cb?.Invoke(null);
                return;
            }
            _path = string.Format("Assets/AddressableAssets/Atlas/{0}.spriteatlasv2", _path);

            if (SpriteAtlasDic.ContainsKey(_path)) {
                _cb?.Invoke(SpriteAtlasDic[_path]);
            } else {
                Addressables.LoadAssetAsync<SpriteAtlas>(_path).Completed += handle => {
                    switch (handle.Status) {
                        case AsyncOperationStatus.Succeeded:
                            _cb?.Invoke(handle.Result);
                            //WriteLog.Log("讀取Atlas成功:"+_path);
                            break;
                        default:
                            // WriteLog.LogError("讀取資源失敗:" + _path);
                            break;
                    }
                    //Addressables.Release(handle);
                };
            }
        }
        public static void GetSprite(string _path, Action<Sprite, AsyncOperationHandle> _cb) {
            if (_path == "") {
                return;
            }

            _path = string.Format("Assets/AddressableAssets/Images/{0}.png", _path);
            Addressables.LoadAssetAsync<Sprite>(_path).Completed += handle => {
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result, handle);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
            };
        }
        public static void GetMultipleSprites(string _path, Action<Sprite[], AsyncOperationHandle> _cb) {
            if (_path == "") {
                return;
            }

            _path = string.Format("Assets/AddressableAssets/Images/{0}.png", _path);
            Addressables.LoadAssetAsync<Sprite[]>(_path).Completed += handle => {
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result, handle);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
            };
        }
        public static void GetParticle(string _path, Action<GameObject, AsyncOperationHandle> _cb) {
            if (_path == "") {
                return;
            }

            _path = string.Format("Assets/AddressableAssets/Particles/{0}.prefab", _path);

            Addressables.LoadAssetAsync<GameObject>(_path).Completed += handle => {
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result, handle);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
            };
        }
        public static void GetTexture(string _path, Action<Texture, AsyncOperationHandle> _cb, Action _notExistCB = null) {
            if (_path == "") {
                return;
            }
            _path = string.Format("Assets/AddressableAssets/Textures/{0}.png", _path);

            Addressables.LoadResourceLocationsAsync(_path).Completed += check => {
                if (check.Status == AsyncOperationStatus.Succeeded) {
                    if (check.Result.Count > 0) {
                        Addressables.LoadAssetAsync<Texture>(_path).Completed += handle => {
                            switch (handle.Status) {
                                case AsyncOperationStatus.Succeeded:
                                    _cb?.Invoke(handle.Result, handle);
                                    break;
                            }
                        };
                    } else {
                        WriteLog_UnityAssembly.LogErrorFormat("找不到Texture: " + _path);
                        _notExistCB?.Invoke();
                    }
                } else {
                    WriteLog_UnityAssembly.LogErrorFormat("找不到Texture:" + _path);
                    _notExistCB?.Invoke();
                }
            };

        }
        public static void GetTextureWithIndex(string _path, int _index, Action<Texture, AsyncOperationHandle, int> _cb, Action _notExistCB = null) {
            if (_path == "")
                return;

            _path = string.Format("Assets/AddressableAssets/Textures/{0}.png", _path);



            Addressables.LoadResourceLocationsAsync(_path).Completed += check => {
                if (check.Status == AsyncOperationStatus.Succeeded) {
                    if (check.Result.Count > 0) {
                        Addressables.LoadAssetAsync<Texture>(_path).Completed += handle => {
                            switch (handle.Status) {
                                case AsyncOperationStatus.Succeeded:
                                    _cb?.Invoke(handle.Result, handle, _index);
                                    break;
                            }
                        };
                    } else {
                        WriteLog_UnityAssembly.LogErrorFormat("找不到Texture: " + _path);
                        _notExistCB?.Invoke();
                    }
                } else {
                    WriteLog_UnityAssembly.LogErrorFormat("找不到Texture:" + _path);
                    _notExistCB?.Invoke();
                }
            };

        }


        public static void GetPrefab(string _path, Action<GameObject, AsyncOperationHandle> _cb, Action _notExistCB = null) {
            if (_path == "") {
                return;
            }
            _path = string.Format("Assets/AddressableAssets/Prefabs/{0}.prefab", _path);

            Addressables.LoadResourceLocationsAsync(_path).Completed += check => {
                if (check.Status == AsyncOperationStatus.Succeeded) {
                    if (check.Result.Count > 0) {
                        Addressables.LoadAssetAsync<GameObject>(_path).Completed += handle => {
                            switch (handle.Status) {
                                case AsyncOperationStatus.Succeeded:
                                    _cb?.Invoke(handle.Result, handle);
                                    break;
                            }
                        };
                    } else {
                        WriteLog_UnityAssembly.LogErrorFormat("找不到Prefab: " + _path);
                        _notExistCB?.Invoke();
                    }
                } else {
                    WriteLog_UnityAssembly.LogErrorFormat("找不到Prefab:" + _path);
                    _notExistCB?.Invoke();
                }
            };
        }

        public static void GetAudio(MyAudioType _type, string _name, Action<AudioClip> _cb) {
            if (_name == "") {
                _cb?.Invoke(null);
                return;
            }
            string fileExtension = "mp3";//統一用mp3

            string path = string.Format("Assets/AddressableAssets/Audios/{0}/{1}.{2}", _type.ToString(), _name, fileExtension);
            Addressables.LoadAssetAsync<AudioClip>(path).Completed += handle => {
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
                //Addressables.Release(handle);
            };
        }
        public enum ControllerFileExtention {
            controller,
            overrideController
        }
        public static void GetController(string _path, ControllerFileExtention _fileExtension, Action<RuntimeAnimatorController> _cb) {
            if (_path == "") {
                _cb?.Invoke(null);
                return;
            }
            _path = string.Format("Assets/AddressableAssets/Animations/{0}.{1}", _path, _fileExtension);
            Addressables.LoadAssetAsync<RuntimeAnimatorController>(_path).Completed += handle => {
                switch (handle.Status) {
                    case AsyncOperationStatus.Succeeded:
                        _cb?.Invoke(handle.Result);
                        break;
                    default:
                        // WriteLog.LogError("讀取資源失敗:" + _path);
                        break;
                }
                //Addressables.Release(handle);
            };

        }
    }
}
