using UnityEngine;
using System.Collections;
namespace Scoz.Func {
    public static class UIPosition {
        public static void UIToWorldPos(RectTransform _canvasRect, Camera _camera, Transform _targetTrans, RectTransform _selfTrans, float _diffPosX, float _diffPosY) {
            Vector2 ViewportPosition = _camera.WorldToViewportPoint(_targetTrans.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * _canvasRect.sizeDelta.x) - (_canvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * _canvasRect.sizeDelta.y) - (_canvasRect.sizeDelta.y * 0.5f)));
            Vector2 diffPos = new Vector2(_diffPosX, _diffPosY);
            _selfTrans.anchoredPosition = WorldObject_ScreenPosition + diffPos;
        }
        public static Vector3 WorldToUISpace(Canvas _canvas, Vector3 _worldPos) {
            //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
            Vector3 screenPos = Camera.main.WorldToScreenPoint(_worldPos);
            Vector2 movePos;

            //Convert the screenpoint to ui rectangle local point
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, screenPos, _canvas.worldCamera, out movePos);
            //Convert the local point to world point
            return _canvas.transform.TransformPoint(movePos);
        }
        public static Vector3 GetMouseWorldPointOnYZero(float _y) {
            Ray ray = GameObject.FindGameObjectWithTag("SceneCam").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Plane yZeroPlane = new Plane(Vector3.up, _y); // 創建一個Y軸為_y的平面
            if (yZeroPlane.Raycast(ray, out float enter)) {
                return ray.GetPoint(enter); // 返回交點
            }
            return Vector3.zero; // 如果沒有交叉點，返回(0,0,0)
        }
        public static Vector2 GetMouseWorldPointVector2OnYZeroTo(float _y) {
            Ray ray = GameObject.FindGameObjectWithTag("SceneCam").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Plane yZeroPlane = new Plane(Vector3.up, _y); // 創建一個Y軸為_y的平面
            if (yZeroPlane.Raycast(ray, out float enter)) {
                var pos = ray.GetPoint(enter);// 取得交點
                return new Vector2(pos.x, pos.z); //將交點(x,y,z)轉(x,z)
            }
            return Vector2.zero; // 如果沒有交叉點，返回(0,0,0)
        }
        public static void SetUIToMouthPos(Transform _trans, Canvas _canvas, Vector2 _offset) {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, Input.mousePosition, _canvas.worldCamera, out pos);
            _trans.position = _canvas.transform.TransformPoint(pos);
            _trans.localPosition = new Vector3(_trans.localPosition.x + _offset.x, _trans.localPosition.y + _offset.y, 0);
        }
        public static Vector3 GetUIMousePos(Canvas _canvas) {
            Vector3 uiPos = WorldToUISpace(_canvas, Input.mousePosition);
            return uiPos;
        }
        public static void SetAnchor(this RectTransform _rect, Anchor _anchor) {
            switch (_anchor) {
                case Anchor.TopLeft:
                    _rect.anchorMin = new Vector2(0, 1);
                    _rect.anchorMax = new Vector2(0, 1);
                    break;
                case Anchor.TopCenter:
                    _rect.anchorMin = new Vector2(0.5f, 1);
                    _rect.anchorMax = new Vector2(0.5f, 1);
                    break;
                case Anchor.TopRight:
                    _rect.anchorMin = new Vector2(1, 1);
                    _rect.anchorMax = new Vector2(1, 1);
                    break;
                case Anchor.MiddleLeft:
                    _rect.anchorMin = new Vector2(0, 0.5f);
                    _rect.anchorMax = new Vector2(0, 0.5f);
                    break;
                case Anchor.MiddleCenter:
                    _rect.anchorMin = new Vector2(0.5f, 0.5f);
                    _rect.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
                case Anchor.MiddleRight:
                    _rect.anchorMin = new Vector2(1, 0.5f);
                    _rect.anchorMax = new Vector2(1, 0.5f);
                    break;
                case Anchor.BottomLeft:
                    _rect.anchorMin = new Vector2(0, 0);
                    _rect.anchorMax = new Vector2(0, 0);
                    break;
                case Anchor.BottomCenter:
                    _rect.anchorMin = new Vector2(0.5f, 0);
                    _rect.anchorMax = new Vector2(0.5f, 0);
                    break;
                case Anchor.BottomRight:
                    _rect.anchorMin = new Vector2(1, 0);
                    _rect.anchorMax = new Vector2(1, 0);
                    break;
            }
        }
    }
}
