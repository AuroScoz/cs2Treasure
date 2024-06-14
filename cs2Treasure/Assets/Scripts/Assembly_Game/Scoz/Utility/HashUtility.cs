using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
namespace Scoz.Func {
    public static class HashUtility {

        [BurstCompile]
        public static uint GenerateHash(string _str) {
            var nativeArray = StrToNativeArray(_str);
            return GenerateHash(nativeArray);
        }
        [BurstCompile]
        public static uint GenerateHash(NativeArray<char> nativeArray) {
            // 初始化種子值
            uint seed = 0;

            // 輸入轉換為位元組
            byte[] data = new byte[nativeArray.Length * sizeof(char)];
            for (int i = 0; i < nativeArray.Length; i++) {
                ushort charValue = (ushort)nativeArray[i];
                data[i * 2] = (byte)(charValue & 0xFF);
                data[i * 2 + 1] = (byte)(charValue >> 8);
            }
            nativeArray.Dispose();
            // 計算 MurmurHash
            return MurmurHash3.Hash(data, seed);
        }

        [BurstCompile]
        public static NativeArray<char> StrToNativeArray(string _str) {
            NativeArray<char> nativeStr = new NativeArray<char>(_str.Length, Allocator.Temp);
            for (int i = 0; i < _str.Length; i++) {
                nativeStr[i] = _str[i];
            }
            return nativeStr;
        }

        private static class MurmurHash3 {
            public static uint Hash(byte[] data, uint seed) {
                const uint c1 = 0xcc9e2d51;
                const uint c2 = 0x1b873593;
                const int r1 = 15;
                const int r2 = 13;
                const uint m = 5;
                const uint n = 0xe6546b64;

                int length = data.Length;
                int blocks = length / 4;

                uint h1 = seed;

                for (int i = 0; i < blocks; i++) {
                    uint k1 = BitConverter.ToUInt32(data, i * 4);

                    k1 *= c1;
                    k1 = RotateLeft(k1, r1);
                    k1 *= c2;

                    h1 ^= k1;
                    h1 = RotateLeft(h1, r2);
                    h1 = h1 * m + n;
                }

                int tail = blocks * 4;
                uint remainingBytes = (uint)(length - tail);
                uint k2 = 0;

                switch (remainingBytes) {
                    case 3:
                        k2 ^= (uint)(data[tail + 2] << 16);
                        goto case 2;
                    case 2:
                        k2 ^= (uint)(data[tail + 1] << 8);
                        goto case 1;
                    case 1:
                        k2 ^= data[tail];
                        k2 *= c1;
                        k2 = RotateLeft(k2, r1);
                        k2 *= c2;
                        h1 ^= k2;
                        break;
                }

                h1 ^= (uint)length;
                h1 = FinalizeHash(h1);

                return h1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static uint RotateLeft(uint x, int count) {
                return (x << count) | (x >> (32 - count));
            }

            private static uint FinalizeHash(uint h) {
                h ^= h >> 16;
                h *= 0x85ebca6b;
                h ^= h >> 13;
                h *= 0xc2b2ae35;
                h ^= h >> 16;
                return h;
            }
        }
    }
}