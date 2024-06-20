using UnityEngine;
using UnityEditor;
using System.IO;

public class CaptureCameraView : EditorWindow {
    Camera selectedCamera;

    [MenuItem("Scoz/Utility/Capture Selected Camera View as PNG")]
    public static void ShowWindow() {
        GetWindow<CaptureCameraView>("Capture Camera View");
    }

    void OnGUI() {
        GUILayout.Label("Capture Camera View as PNG", EditorStyles.boldLabel);

        selectedCamera = EditorGUILayout.ObjectField("Select Camera", selectedCamera, typeof(Camera), true) as Camera;

        if (GUILayout.Button("Capture and Save PNG")) {
            if (selectedCamera != null) {
                CaptureAndSave(selectedCamera);
            } else {
                Debug.LogError("No camera selected!");
            }
        }
    }

    void CaptureAndSave(Camera camera) {
        // 手動觸發Cinemachine更新
        

        RenderTexture currentRT = RenderTexture.active;

        // 確保有一個targetTexture來渲染
        if (camera.targetTexture == null) {
            camera.targetTexture = new RenderTexture(camera.pixelWidth, camera.pixelHeight, 24);
        }

        camera.Render(); // 確保渲染當前幀

        RenderTexture.active = camera.targetTexture;

        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height, TextureFormat.RGBA32, false);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        byte[] bytes = image.EncodeToPNG();
        DestroyImmediate(image); // 釋放資源

        string path = EditorUtility.SaveFilePanel("Save PNG", "", "CameraCapture.png", "png");
        if (path.Length != 0) {
            File.WriteAllBytes(path, bytes);
            Debug.Log("Saved Camera View to: " + path);
        }

        // 恢復攝影機的設置
        camera.targetTexture = null; // 重要：將攝影機的targetTexture設置回null
        RenderTexture.active = currentRT; // 恢復原始的RenderTexture
    }
}
