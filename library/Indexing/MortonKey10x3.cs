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
    
    /// <summary>
    /// Provides a 32 bit Morton Key Indexing Structure that holds 
    /// 10 bits of data for 3 (x, y, z) internal components. Each 
    /// component must be between range [0, 1023]
    ///
    /// NOTE ABOUT PERFORMANCE
    ///
    /// When using DEBUG mode enabled, arguments will be checked for
    /// range validity, however in RELEASE mode those checks will
    /// be stripped from binaries. Do NOT reply on try/catch methods
    /// to exit higher level code.
    /// </summary>
    /// <remarks>
    /// Morton Keys can be used for Spatial Hashing or Indexing
    /// operations that provides good data locality.
    /// </remarks>
    /// <example>
    /// <code>
    /// var key = new MortonKey10x3(10, 20, 30);
    /// Console.WriteLine(key.X); // prints 10
    /// Console.WriteLine(key.Y); // prints 20
    /// Console.WriteLine(key.Z); // prints 30
    /// </code>
    /// </example>
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
        private const int MaxComponentValue = (1 << 10) - 1;
        private const int MinComponentValue = 0;
        private const int MaxKeyValue = MaxComponentValue * MaxComponentValue * MaxComponentValue;
        private const int MinKeyValue = 0;
#endif
        #endregion

        #region runtime private constants
        private const uint XMask = 0b00001001001001001001001001001001;
        private const uint YMask = 0b00010010010010010010010010010010;
        private const uint ZMask = 0b00100100100100100100100100100100;

        private const uint XYMask = XMask | YMask;
        private const uint XZMask = XMask | ZMask;
        private const uint YZMask = YMask | ZMask;
        #endregion

        public uint Key { get; }

        #region constructors
        public MortonKey10x3(uint key) {
#if BITSTACK_DEBUG
            if (key > MaxKeyValue) {
                BitDebug.Exit($"{ClassName}(uint) - argument (key) cannot be greater than {MaxKeyValue} but was {key}");
            }
#endif

            unchecked {
                Key = key;
            }
        }

        public MortonKey10x3(int key) {
#if BITSTACK_DEBUG
            if (key < MinKeyValue) {
                BitDebug.Exit($"{ClassName}(int) - argument (key) cannot be less than {MinKeyValue} but was {key}");
            }

            if (key > MaxKeyValue) {
                BitDebug.Exit($"{ClassName}(int) - argument (key) cannot be greater than {MaxKeyValue} but was {key}");
            }
#endif
            unchecked {
                Key = (uint) key;
            }
        }

        public MortonKey10x3(uint x, uint y, uint z) {
#if BITSTACK_DEBUG
            if (x > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(uint, uint, uint) - argument (x) cannot be greater than {MaxComponentValue} but was {x}");
            }

            if (y > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(uint, uint, uint) - argument (y) cannot be greater than {MaxComponentValue} but was {y}");
            }

            if (z > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(uint, uint, uint) - argument (z) cannot be greater than {MaxComponentValue} but was {z}");
            }
#endif
            uint cx = EncodeValue(x);
            uint cy = EncodeValue(y);
            uint cz = EncodeValue(z);

            unchecked {
                Key = (cz << 2) + (cy << 1) + cx;
            }
        }

        public MortonKey10x3(int x, int y, int z) {
#if BITSTACK_DEBUG
            if (x > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (x) cannot be greater than {MaxComponentValue} but was {x}");
            }

            if (x < MinComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (x) cannot be less than {MinComponentValue} but was {x}");
            }

            if (y > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (y) cannot be greater than {MaxComponentValue} but was {y}");
            }

            if (y < MinComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (y) cannot be less than {MinComponentValue} but was {y}");
            }

            if (z > MaxComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (z) cannot be greater than {MaxComponentValue} but was {z}");
            }

            if (z < MinComponentValue) {
                BitDebug.Exit($"{ClassName}(int, int, int) - argument (z) cannot be less than {MinComponentValue} but was {z}");
            }
#endif
            uint cx = EncodeValue((uint) x);
            uint cy = EncodeValue((uint) y);
            uint cz = EncodeValue((uint) z);

            unchecked {
                Key = (cz << 2) + (cy << 1) + cx;
            }
        }

        #endregion

        #region static private methods

#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static uint EncodeValue(uint n) {
            unchecked {
                // mask the maximum value
                uint n0 = n & 0b00000000000000000000001111111111;

                uint n1 = (n0 ^ (n0 << 16)) & 0b00111111000000000000000011111111;
                uint n2 = (n1 ^ (n1 << 8))  & 0b00001111000000001111000000001111;
                uint n3 = (n2 ^ (n2 << 4))  & 0b00000011000011000011000011000011;
                uint n4 = (n3 ^ (n3 << 2))  & 0b00001001001001001001001001001001;

                return n4;
            }
        }

#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static uint DecodeValue(uint n) {
            unchecked {
                uint n0 = n & 0b00001001001001001001001001001001;

                uint n1 = (n0 ^ (n0 >> 2))  & 0b00000011000011000011000011000011;
                uint n2 = (n1 ^ (n1 >> 4))  & 0b00001111000000001111000000001111;
                uint n3 = (n2 ^ (n2 >> 8))  & 0b00111111000000000000000011111111;
                uint n4 = (n3 ^ (n3 >> 16)) & 0b00000000000000000000001111111111;

                return n4;
            }
        }

        #endregion

        /**
         * Compute and return the X component of the Morton Key.
         * NOTE: This is a computation, store and reuse the variable
         * if used in multiple places.
         *
         * This component is 10 bits wide and mapped in range [0, 1024]
         */
        public uint X {
            get {
                return DecodeValue(Key);
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
                return DecodeValue(Key >> 1);
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
                return DecodeValue(Key >> 2);
            }
        }

        #region implicit operator overloads

        public static implicit operator ulong(MortonKey10x3 key) {
            return key.Key;
        }

        public static implicit operator long(MortonKey10x3 key) {
            return key.Key;
        }

        public static implicit operator uint(MortonKey10x3 key) {
            return key.Key;
        }

        public static implicit operator int(MortonKey10x3 key) {
            return (int) key.Key;
        }

        public static implicit operator ushort(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.Key > ushort.MaxValue) {
                BitDebug.Exit($"(ushort){ClassName} implicit cast to ushort - cannot assign value as key ({key.Key}) is larger than ushort max value of ({ushort.MaxValue})");
            }
#endif
            return (ushort) key.Key;
        }

        public static implicit operator short(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.Key > short.MaxValue) {
                BitDebug.Exit($"(short){ClassName} implicit cast to short - cannot assign value as key ({key.Key}) is larger than short max value of ({short.MaxValue})");
            }
#endif
            return (short) key.Key;
        }

        public static implicit operator byte(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.Key > byte.MaxValue) {
                BitDebug.Exit($"(byte){ClassName} implicit cast to byte - cannot assign value as key ({key.Key}) is larger than byte max value of ({byte.MaxValue})");
            }
#endif
            return (byte) key.Key;
        }

        public static implicit operator sbyte(MortonKey10x3 key) {
#if BITSTACK_DEBUG
            if (key.Key > sbyte.MaxValue) {
                BitDebug.Exit($"(sbyte){ClassName} implicit cast to sbyte - cannot assign value as key ({key.Key}) is larger than sbyte max value of ({sbyte.MaxValue})");
            }
#endif
            return (sbyte) key.Key;
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
            uint xKey = x.Key;
            uint yKey = y.Key;

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
            uint xKey = x.Key;
            uint yKey = y.Key;

            uint diffX = (xKey & XMask) - (yKey & XMask);
            uint diffY = (xKey & YMask) - (yKey & YMask);
            uint diffZ = (xKey & ZMask) - (yKey & ZMask);

            return new MortonKey10x3((diffX & XMask) | (diffY & YMask) | (diffZ & ZMask));
        }
        #endregion

        #region equality implementation

        public bool Equals(ISpatialKey<ulong> other) {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public bool Equals(ISpatialKey<uint> other) {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public bool Equals(ISpatialKey<ushort> other) {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public bool Equals(ISpatialKey<byte> other) {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public bool Equals(MortonKey10x3 other) {
            return Key == other.Key;
        }

        public bool Equals(ulong other) {
            return Key == other;
        }

        public bool Equals(uint other) {
            return Key == other;
        }

        public bool Equals(ushort other) {
            return Key == other;
        }

        public bool Equals(byte other) {
            return Key == other;
        }

        #endregion

        public override int GetHashCode() {
            return (int)Key;
        }
    }
}