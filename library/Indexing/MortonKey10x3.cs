#region preprocessor defines
#if DEBUG
#define BITSTACK_DEBUG
#endif

#if BITSTACK_DEBUG
using CoreGDX.BitStack.Debug;
#endif

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif
#endregion

#region imports
using System;
#endregion

namespace CoreGDX.BitStack.Indexing {
    
    /**
     * Provides a Morton Key Indexing Structure that holds 10 bits
     * of data for 3 internal components. Each component cannot be
     * greater than 2^10 = 1024.
     *
     * Morton Keys can be used for Spatial Hashing or Indexing
     * operations that provides good data locality.
     *
     * NOTE ABOUT PERFORMANCE
     *
     * When using DEBUG mode enabled, arguments will be checked for
     * range validity however in Production Mode those checks will
     * be stripped from binaries. Do NOT reply on try/catch methods
     * to exit higher level code.
     */
    public readonly struct MortonKey10x3 :  ISpatialKey<uint>, 
                                            IEquatable<ISpatialKey<ulong>>,
                                            IEquatable<ISpatialKey<uint>>,
                                            IEquatable<ISpatialKey<ushort>>,
                                            IEquatable<ISpatialKey<byte>>,
                                            IEquatable<MortonKey10x3>, 
                                            IEquatable<ulong>, 
                                            IEquatable<uint>, 
                                            IEquatable<ushort>, 
                                            IEquatable<byte> {
        #region debug private constants
#if BITSTACK_DEBUG
        private const String ClassName = "MortonKey10x3";
        private const int MaxComponentValue = 1 >> 10;
        private const int MinComponentValue = 0;
        private const int MaxKeyValue = MaxComponentValue * MaxComponentValue * MaxComponentValue;
#endif
        #endregion

        #region runtime private constants
        private const uint XMask = 0x9249249;
        private const uint YMask = 0x12492492;
        private const uint ZMask = 0x24924924;

        private const uint XYMask = XMask | YMask;
        private const uint XZMask = XMask | ZMask;
        private const uint YZMask = YMask | ZMask;
        #endregion

        private readonly uint key;

        #region constructors
        public MortonKey10x3(uint key) {
#if BITSTACK_DEBUG
            if (key > MaxKeyValue) {
                BitDebug.Exit(ClassName + "(uint) - argument (key) cannot be greater than " + MaxKeyValue + " but was " + key);
            }
#endif
            this.key = key;
        }

        public MortonKey10x3(int key) {
#if BITSTACK_DEBUG
            if (key < MinComponentValue) {
                BitDebug.Exit(ClassName + "(int) - argument (key) cannot be less than " + MinComponentValue + " but was " + key);
            }

            if (key > MaxKeyValue) {
                BitDebug.Exit(ClassName + "(int) - argument (key) cannot be greater than " + MaxKeyValue + " but was " + key);
            }
#endif
            this.key = (uint) key;
        }

        public MortonKey10x3(uint x, uint y, uint z) {
#if BITSTACK_DEBUG
            if (x > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(uint, uint, uint) - argument (x) cannot be greater than " + MaxComponentValue + " but was " + x);
            }

            if (y > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(uint, uint, uint) - argument (y) cannot be greater than " + MaxComponentValue + " but was " + y);
            }

            if (z > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(uint, uint, uint) - argument (z) cannot be greater than " + MaxComponentValue + " but was " + z);
            }
#endif
            uint cx = MortonPartEncode(x);
            uint cy = MortonPartEncode(y);
            uint cz = MortonPartEncode(z);

            this.key = (cz << 2) + (cy << 1) + cx;
        }

        public MortonKey10x3(int x, int y, int z) {
#if BITSTACK_DEBUG
            if (x > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (x) cannot be greater than " + MaxComponentValue + " but was " + x);
            }

            if (x < MinComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (x) cannot be less than " + MinComponentValue + " but was " + x);
            }

            if (y > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (y) cannot be greater than " + MaxComponentValue + " but was " + y);
            }

            if (y < MinComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (y) cannot be less than " + MinComponentValue + " but was " + y);
            }

            if (z > MaxComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (z) cannot be greater than " + MaxComponentValue + " but was " + z);
            }

            if (z < MinComponentValue) {
                BitDebug.Exit(ClassName + "(int, int, int) - argument (z) cannot be less than " + MinComponentValue + " but was " + z);
            }
#endif
            uint cx = MortonPartEncode((uint) x);
            uint cy = MortonPartEncode((uint) y);
            uint cz = MortonPartEncode((uint) z);

            this.key = (cz << 2) + (cy << 1) + cx;
        }

        #endregion

        #region static private methods

#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static uint MortonPartEncode(uint n) {
            uint n0 = n & 0x000003ff;

            uint n1 = (n0 ^ (n0 << 16)) & 0xff0000ff;
            uint n2 = (n1 ^ (n1 << 8)) & 0x0300f00f;
            uint n3 = (n2 ^ (n2 << 4)) & 0x030c30c3;
            uint n4 = (n3 ^ (n3 << 2)) & 0x09249249;

            return n4;
        }

#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static uint MortonPartDecode(uint n) {
            uint n0 = n & 0x09249249;

            uint n1 = (n0 ^ (n0 >> 2)) & 0x030c30c3;
            uint n2 = (n1 ^ (n1 >> 4)) & 0x0300f00f;
            uint n3 = (n2 ^ (n2 >> 8)) & 0xff0000ff;
            uint n4 = (n3 ^ (n3 >> 16)) & 0x000003ff;

            return n4;
        }

        #endregion

        /**
         * Grab the internal 32 bit unsigned key used to represent
         * the current Morton Index.
         */
        public uint Key {
            get {
                return key;
            }
        }

        /**
         * Compute and return the X component of the Morton Key.
         * NOTE: This is a computation, store and reuse the variable
         * if used in multiple places.
         *
         * This component is 10 bits wide and mapped in range [0, 1024]
         */
        public uint X {
            get {
                return MortonPartDecode(key);
            }
        }

        /**
         * Compute and return the Y component of the Morton Key.
         * NOTE: This is a computation, store and reuse the variable
         * if used in multiple places.
         *
         * This component is 10 bits wide and mapped in range [0, 1024]
         */
        public uint Y {
            get {
                return MortonPartDecode(key >> 1);
            }
        }

        /**
         * Compute and return the Z component of the Morton Key.
         * NOTE: This is a computation, store and reuse the variable
         * if used in multiple places.
         *
         * This component is 10 bits wide and mapped in range [0, 1024]
         */
        public uint Z {
            get {
                return MortonPartDecode(key >> 2);
            }
        }

        #region implicit operator overloads

        public static implicit operator ulong(MortonKey10x3 key) {
            return key.key;
        }

        public static implicit operator long(MortonKey10x3 key) {
            return key.key;
        }

        public static implicit operator uint(MortonKey10x3 key) {
            return key.key;
        }

        public static implicit operator int(MortonKey10x3 key) {
            return (int) key.key;
        }

        public static implicit operator ushort(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.key > ushort.MaxValue) {
                BitDebug.Exit(ClassName + " implicit cast to ushort - cannot assign value as key (" + key.key + ") is larger than ushort value of (" + ushort.MaxValue + ")");
            }
#endif
            return (ushort) key.key;
        }

        public static implicit operator short(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.key > short.MaxValue) {
                BitDebug.Exit(ClassName + " implicit cast to short - cannot assign value as key (" + key.key + ") is larger than short value of (" + short.MaxValue + ")");
            }
#endif
            return (short) key.key;
        }

        public static implicit operator byte(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.key > byte.MaxValue) {
                BitDebug.Exit(ClassName + " implicit cast to byte - cannot assign value as key " + key.key + " is larger than byte value of (" + byte.MaxValue + ")");
            }
#endif
            return (byte) key.key;
        }

        public static implicit operator sbyte(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.key > sbyte.MaxValue) {
                BitDebug.Exit(ClassName + " implicit cast to sbyte - cannot assign value as key (" + key.key + ") is larger than sbyte value of (" + sbyte.MaxValue + ")");
            }
#endif
            return (sbyte) key.key;
        }

        public static implicit operator ValueTuple<uint, uint, uint>(MortonKey10x3 key) {
            return new ValueTuple<uint, uint, uint>(key.X, key.Y, key.Z);
        }

        public static implicit operator ValueTuple<int, int, int>(MortonKey10x3 key) {
            return new ValueTuple<int, int, int>((int) key.X, (int) key.Y, (int) key.Z);
        }

        public static implicit operator MortonKey10x3(uint key) {
            return new MortonKey10x3(key);
        }

        public static implicit operator MortonKey10x3(ValueTuple<uint, uint, uint> coords) {
            return new MortonKey10x3(coords.Item1, coords.Item2, coords.Item3);
        }

        public static implicit operator MortonKey10x3(int key) {
            return new MortonKey10x3(key);
        }

        public static implicit operator MortonKey10x3(ValueTuple<int, int, int> coords) {
            return new MortonKey10x3(coords.Item1, coords.Item2, coords.Item3);
        }

        #endregion

        #region operator overloads

        /**
         * Overrides : MortonKey(1,2,3) + MortonKey(4,5,6) = MortonKey(5,7,9)
         *
         * Efficiently adds two morton indices to compute the final index. Range
         * rules still apply.
         */
        public static MortonKey10x3 operator +(MortonKey10x3 x, MortonKey10x3 y) {
            uint xKey = x.key;
            uint yKey = y.key;

            uint sumX = (xKey | YZMask) + (yKey & XMask);
            uint sumY = (xKey | XZMask) + (yKey & YMask);
            uint sumZ = (xKey | XYMask) + (yKey & ZMask);

            return new MortonKey10x3((sumX & XMask) | (sumY & YMask) | (sumZ & ZMask));
        }

        /**
         * Overrides : MortonKey(4,5,6) - MortonKey(1,2,3) = MortonKey(3,3,3)
         *
         * Efficiently subtracts two morton indices to compute the final index. Range
         * rules still apply.
         */
        public static MortonKey10x3 operator -(MortonKey10x3 x, MortonKey10x3 y) {
            uint xKey = x.key;
            uint yKey = y.key;

            uint diffX = (xKey & XMask) - (yKey & XMask);
            uint diffY = (xKey & YMask) - (yKey & YMask);
            uint diffZ = (xKey & ZMask) - (yKey & ZMask);

            return new MortonKey10x3((diffX & XMask) | (diffY & YMask) | (diffZ & ZMask));
        }
        #endregion

        #region equality implementation

        public bool Equals(ISpatialKey<ulong> other) {
            return key == other.Key;
        }

        public bool Equals(ISpatialKey<uint> other) {
            return key == other.Key;
        }

        public bool Equals(ISpatialKey<ushort> other) {
            return key == other.Key;
        }

        public bool Equals(ISpatialKey<byte> other) {
            return key == other.Key;
        }

        public bool Equals(MortonKey10x3 other) {
            return key == other.key;
        }

        public bool Equals(ulong other) {
            return key == (uint) other;
        }

        public bool Equals(uint other) {
            return key == other;
        }

        public bool Equals(ushort other) {
            return key == other;
        }

        public bool Equals(byte other) {
            return key == other;
        }

        #endregion
    }
}