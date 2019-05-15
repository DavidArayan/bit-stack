#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;
using UnityEngine;

namespace BitStack {
    
    /**
     * NOTICE ABOUT PERFORMANCE
     * 
     * UNITY_EDITOR or DEBUG flags ensure that common errors are caught. These
     * flags are removed in production mode so don't rely on try/catch methods.
     * If performing benchmarks, ensure that the flags are not taken into account.
     * The flags ensure that common problems are caught in code and taken care of.
     */
    public struct LinearKey3 : IKeyIndex<LinearKey3>, IEquatable<LinearKey3>, IEquatable<uint>, IEquatable<Vector3>, IEquatable<IKeyIndex<LinearKey3>> {
        const uint KEY_MASK = 0x3FF;

        readonly uint linearKey;

        public LinearKey3(uint linearKey) {
            this.linearKey = linearKey;
        }

        public LinearKey3(int linearKey) {
#if BITSTACK_DEBUG
            if (linearKey < 0) {
                BitDebug.Exception("LinearKey3(int) - linear key must be positive");
            }
#endif

            this.linearKey = (uint)linearKey;
        }

        public LinearKey3(uint x, uint y, uint z) {
#if BITSTACK_DEBUG
            if (x > 1024 || x < 0) {
                BitDebug.Exception("LinearKey3(uint, uint, uint) - linear key x component must be between 0-1023 (10 bits), was " + x);
            }

            if (y > 1024 || y < 0) {
                BitDebug.Exception("LinearKey3(uint, uint, uint) - linear key y component must be between 0-1023 (10 bits), was " + y);
            }

            if (z > 1024 || z < 0) {
                BitDebug.Exception("LinearKey3(uint, uint, uint) - linear key z component must be between 0-1023 (10 bits), was " + z);
            }
#endif
            this.linearKey = EncodeLinearKey(x, y, z);
        }

        public LinearKey3(int x, int y, int z) {
#if BITSTACK_DEBUG
            if (x > 1024 || x < 0) {
                BitDebug.Exception("LinearKey3(int, int, int) - linear key x component must be between 0-1023 (10 bits), was " + x);
            }

            if (y > 1024 || y < 0) {
                BitDebug.Exception("LinearKey3(int, int, int) - linear key y component must be between 0-1023 (10 bits), was " + y);
            }

            if (z > 1024 || z < 0) {
                BitDebug.Exception("LinearKey3(int, int, int) - linear key z component must be between 0-1023 (10 bits), was " + z);
            }
#endif
            uint _x = (uint)x;
            uint _y = (uint)y;
            uint _z = (uint)z;

            this.linearKey = EncodeLinearKey(_x, _y, _z);
        }

        public LinearKey3(Vector3 value) {
            uint _x = (uint)value.x;
            uint _y = (uint)value.y;
            uint _z = (uint)value.z;

            this.linearKey = EncodeLinearKey(_x, _y, _z);
        }

        private static uint EncodeLinearKey(uint x, uint y, uint z) {
            return (x << 20 | y << 10 | z);
        }

        public uint key {
            get {
                return linearKey;
            }
        }

        public uint x {
            get {
                return (linearKey >> 20) & KEY_MASK;
            }
        }

        public uint y {
            get {
                return (linearKey >> 10) & KEY_MASK;
            }
        }

        public uint z {
            get {
                return linearKey & KEY_MASK;
            }
        }

        public Vector3 Value {
            get {
                return new Vector3(x, y, z);
            }
        }

        public ValueTuple<uint, uint, uint> RawValue {
            get {
                return new ValueTuple<uint, uint, uint>(x, y, z);
            }
        }

        public LinearKey3 IncX() {
            return new LinearKey3(x + 1, y, z);
        }

        public LinearKey3 IncY() {
            return new LinearKey3(x, y + 1, z);
        }

        public LinearKey3 IncZ() {
            return new LinearKey3(x, y, z + 1);
        }

        public LinearKey3 IncXY() {
            return new LinearKey3(x + 1, y + 1, z);
        }

        public LinearKey3 IncXZ() {
            return new LinearKey3(x + 1, y, z + 1);
        }

        public LinearKey3 IncYZ() {
            return new LinearKey3(x, y + 1, z + 1);
        }

        public LinearKey3 IncXYZ() {
            return new LinearKey3(x + 1, y + 1, z + 1);
        }

        public LinearKey3 DecX() {
            return new LinearKey3(x - 1, y, z);
        }

        public LinearKey3 DecY() {
            return new LinearKey3(x, y - 1, z);
        }

        public LinearKey3 DecZ() {
            return new LinearKey3(x, y, z - 1);
        }

        public LinearKey3 DecXY() {
            return new LinearKey3(x - 1, y - 1, z);
        }

        public LinearKey3 DecXZ() {
            return new LinearKey3(x - 1, y, z - 1);
        }

        public LinearKey3 DecYZ() {
            return new LinearKey3(x, y - 1, z - 1);
        }

        public LinearKey3 DecXYZ() {
            return new LinearKey3(x - 1, y - 1, z - 1);
        }

        public uint Mod(uint modulo) {
            return linearKey % modulo;
        }

        public uint Mask(uint mask) {
            return linearKey & mask;
        }

        public bool Equals(LinearKey3 other) {
            return linearKey == other.key;
        }

        public bool Equals(uint other) {
            return linearKey == other;
        }

        public bool Equals(Vector3 other) {
            return linearKey == EncodeLinearKey((uint)other.x, (uint)other.y, (uint)other.z);
        }

        public bool Equals(IKeyIndex<LinearKey3> other) {
            return linearKey == other.key;
        }

        public LinearKey3 Copy() {
            return new LinearKey3(key);
        }
    }
}