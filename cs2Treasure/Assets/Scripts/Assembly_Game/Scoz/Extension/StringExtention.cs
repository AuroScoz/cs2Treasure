using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Unity.Collections;

namespace Scoz.Func {
    public static class StringExtention {
        public static string ReplaceFirstOccuranceOfSubStrInStr(this string _str, string _subStr, string _replaceStr) {
            Regex regReplace = new Regex(_subStr);
            string res = regReplace.Replace(_str, _replaceStr, 1);
            return res;
        }

        /// <summary>
        /// 從yyyy-MM-dd-HH:mm:ss的字串格式轉為TimeDate
        /// </summary>
        public static DateTime GetTimeDateFromScozTimeStr(this string _timeStr) {
            return DateTime.ParseExact(_timeStr, "yyyy-MM-dd-HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static string ToMD5(this string _str) {
            return MD5.GetMD5(_str);
        }
        /// <summary>
        /// 等於其中之一就返回true
        /// </summary>
        public static bool EqualToAny(this string _str, params string[] _strs) {
            for (int i = 0; i < _strs.Length; i++) {
                if (_str == _strs[i])
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 不等於傳入的任何字串就返回true
        /// </summary>
        public static bool NotEqualToAll(this string _str, params string[] _strs) {
            for (int i = 0; i < _strs.Length; i++) {
                if (_str == _strs[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Json如果開頭結尾包含了雙引號, 可以用此方法去除
        /// 例如 "{\"Error\": null}" 會改為  {"Error": null}
        /// </summary>
        public static string UnwrapQuotedJson(this string _json) {
            if (_json.StartsWith("\"") && _json.EndsWith("\"")) {
                _json = _json.Substring(1, _json.Length - 2);
                _json = _json.Replace("\\\"", "\"");
            }
            return _json;
        }
        /// <summary>
        /// 將string轉為NativeArray
        /// </summary>
        public static NativeArray<char> ToNativeCharArray(this string _str) {
            if (string.IsNullOrEmpty(_str)) return new NativeArray<char>();
            NativeArray<char> nativeArray = new NativeArray<char>(_str.Length, Allocator.Temp);
            for (int i = 0; i < _str.Length; i++) {
                nativeArray[i] = _str[i];
            }
            return nativeArray;
        }



}
}
