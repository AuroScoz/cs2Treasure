using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加了這個的物件會在遊戲播放後被移除
/// </summary>
public class DestroyOnPlay : MonoBehaviour {
    private void Awake() {
        Destroy(gameObject);
    }
}
