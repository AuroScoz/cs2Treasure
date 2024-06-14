namespace Scoz.Func {
    [System.Serializable]
    public struct Int2D_UnityAssembly {
        public int X;
        public int Y;
        public Int2D_UnityAssembly(int _x, int _y) {
            X = _x;
            Y = _y;
        }
        public static bool operator ==(Int2D_UnityAssembly _a, Int2D_UnityAssembly _b) {
            if (_a.X == _b.X && _a.Y == _b.Y)
                return true;
            else
                return false;
        }
        public override bool Equals(object _obj) {
            if (_obj == null)
                return false;
            if (!(_obj is Int2D_UnityAssembly))
                return false;
            var targetInt2D = (Int2D_UnityAssembly)_obj;
            if (targetInt2D.X != X || targetInt2D.Y != Y)
                return false;
            return true;
        }
        public override int GetHashCode() {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static bool operator !=(Int2D_UnityAssembly _a, Int2D_UnityAssembly _b) {
            if (_a.X == _b.X && _a.Y == _b.Y)
                return false;
            else
                return true;
        }
        public override string ToString() {
            return X.ToString() + "," + Y.ToString();
        }
        public static Int2D_UnityAssembly GetInt2D(string _str) {
            string[] strs = _str.Split(',');
            return new Int2D_UnityAssembly(int.Parse(strs[0]), int.Parse(strs[1]));
        }
    }
}