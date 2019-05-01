#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif

namespace BitStack {

    /**
     * Contains useful extension methods for the long Value datatype.
     * long is a signed 64 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/long
     *
     * NOTICE ABOUT PERFORMANCE
     * 
     * UNITY_EDITOR or DEBUG flags ensure that common errors are caught. These
     * flags are removed in production mode so don't rely on try/catch methods.
     * If performing benchmarks, ensure that the flags are not taken into account.
     * The flags ensure that common problems are caught in code and taken care of.
     *
     * CRITICAL CHANGES
     * 20/12/2018 - for .NET 4.6 targets, all functions are hinted to use AggressiveInlining
     */
    public static sealed class ValueLongExtensions {

        /**
         * Simple method to get a simple true/false value from data
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static bool Bool(this long data) {
            return data > 0;
        }

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 63]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int BitAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.BitAt(int) - position must be between 0 and 63 but was " + pos);
            }
#endif
            return (int) ((data >> pos) & 1);
        }

        /**
         * Return the inverted state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 63]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int BitInvAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.BitInvAt(int) - position must be between 0 and 63 but was " + pos);
            }
#endif
            return 1 - (int) ((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 63]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long SetBitAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.SetBitAt(int) - position must be between 0 and 63 but was " + pos);
            }
#endif
            return (data | 1L << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 63]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long UnsetBitAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.UnsetBitAt(int) - position must be between 0 and 63 but was " + pos);
            }
#endif
            return (data & ~(1L << pos));
        }

        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 63].
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long ToggleBitAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.ToggleBitAt(int) - position must be between 0 and 63 but was " + pos);
            }
#endif
            return data ^ (1L << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 or ON/1 at provided
         * position. position value must be between [0, 63]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long SetBit(this long data, int pos, long bit) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 63) {
                BitDebug.Exception("long.SetBit(int, int) - position must be between 0 and 63 but was " + pos);
            }

            if (bit != 0 && bit != 1) {
                BitDebug.Exception("long.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
            }
#endif
            long mask = 1L << pos;
            long m1 = (bit << pos) & mask;
            long m2 = data & ~mask;

            return (m2 | m1);
        }

        /**
         * Count the number of set bits in the provided long value (64 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static int PopCount(this long value) {
            return ((ulong) value).PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static bool IsPowerOfTwo(this long value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the byte (8 bits) at provided position index
         * Position value must be between [0, 7]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static byte ByteAt(this long data, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 7) {
                BitDebug.Exception("long.ByteAt(int) - position must be between 0 and 7 but was " + pos);
            }
#endif
            return (byte) (data >>(56 - (pos * 8)));
        }

        /**
         * Sets and returns the byte (8 bits) at provided position index
         * Position value must be between [0, 3]
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long SetByteAt(this long data, byte newData, int pos) {
#if BITSTACK_DEBUG
            if (pos < 0 || pos > 7) {
                BitDebug.Exception("long.SetByteAt(int) - position must be between 0 and 7 but was " + pos);
            }
#endif
            int shift = 56 - (pos * 8);
            long mask = (long) 0xFF << shift;
            long m1 = ((long) newData << shift) & mask;
            long m2 = data & ~mask;

            return (m2 | m1);
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * Long. The String will contain 64 characters of 1 or 0 for each bit position
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string BitString(this long value) {
            return ((ulong) value).BitString();
        }

        /**
         * Given a string in binary form ie (10110101) convert into
         * a byte and return. Will only look at the first 8 characters
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long LongFromBitString(this string data, int readIndex) {
            return (long) data.ULongFromBitString(readIndex);
        }

        /**
         * Given a string in binary form ie (10110101) convert into
         * a byte and return. Will only look at the first 8 characters
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static long LongFromBitString(this string data) {
            return data.LongFromBitString(0);
        }

        /**
         * Returns the Hex Value as a String.
         */
#if BITSTACK_METHOD_INLINE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        public static string HexString(this long value) {
            return value.ToString("X");
        }
    }
}