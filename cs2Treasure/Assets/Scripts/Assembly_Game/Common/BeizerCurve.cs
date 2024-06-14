using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BeizerCurve {
    /// <summary>
    /// 階層 1x1x2x3x4x5x6，目前設定為6階
    /// </summary>
    private static readonly float[] Factorial = new float[] {
        1.0f,
        1.0f,
        2.0f,
        6.0f,
        24.0f,
        120.0f,
        720.0f,
    };

    /// <summary>
    /// 計算前面的多項式數字，n! / i! X (n - i)!
    /// </summary>
    /// <param name="n">總共n階</param>
    /// <param name="i">現在i階</param>
    /// <returns>多項式數字</returns>
    private static float Binomial(int n, int i) {
        float a1 = Factorial[n];
        float a2 = Factorial[i];
        float a3 = Factorial[n - i];
        return a1 / (a2 * a3);
    }

    /// <summary>
    /// 計算每項的數字
    /// </summary>
    /// <param name="n">總共n階</param>
    /// <param name="i">現在i階</param>
    /// <param name="t">進度</param>
    /// <returns>該項數值</returns>
    private static float Bernstein(int n, int i, float t) {
        return Binomial(n, i) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i);
    }

    public static Vector3 GetPosition(IList<Vector3> positions, float t) {
        int index = 0;
        Vector3 resultPos = Vector3.zero;
        for (int i = 0; i < positions.Count; i++) {
            resultPos += Bernstein(positions.Count - 1, i, t) * positions[i];
            index++;
        }
        return resultPos;
    }
}
