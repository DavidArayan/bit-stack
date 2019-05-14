#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;

namespace BitStack {

    /**
     * Represents Extension methods for unsigned long value type for working
     * with Tuples.
     */
    public static class ValueTupleLongExtensions {

        /**
         * Combine a 2 value signed int (32 bits per) into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<int, int> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Combine a 2 value unsigned int (32 bits per) into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<uint, uint> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Combine a 4 value signed short (16 bits per) into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<short, short, short, short> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Combine a 4 value unsigned short (16 bits per) into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<ushort, ushort, ushort, ushort> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Combine an 8 value byte tuple into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Combine an 8 value sbyte tuple into a set of signed long (64 bits x 1)
         */
        public static long CombineToLong(this ValueTuple<ValueTuple<sbyte, sbyte, sbyte, sbyte>, ValueTuple<sbyte, sbyte, sbyte, sbyte>> tuple) {
            return (long) tuple.CombineToULong();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 8 value byte tuple
         */
        public static ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> SplitIntoByte(this long value) {
            return ((ulong) value).SplitIntoByte();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 8 value sbyte tuple
         */
        public static ValueTuple<ValueTuple<sbyte, sbyte, sbyte, sbyte>, ValueTuple<sbyte, sbyte, sbyte, sbyte>> SplitIntoSByte(this long value) {
            return ((ulong) value).SplitIntoSByte();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 4 value short tuple
         */
        public static ValueTuple<short, short, short, short> SplitIntoShort(this long value) {
            return ((ulong) value).SplitIntoShort();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 4 value ushort tuple
         */
        public static ValueTuple<ushort, ushort, ushort, ushort> SplitIntoUShort(this long value) {
            return ((ulong) value).SplitIntoUShort();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 2 value int tuple
         */
        public static ValueTuple<int, int> SplitIntoInt(this long value) {
            return ((ulong) value).SplitIntoInt();
        }

        /**
         * Split a single signed long value (64 bit x 1) into an 2 value uint tuple
         */
        public static ValueTuple<uint, uint> SplitIntoUInt(this long value) {
            return ((ulong) value).SplitIntoUInt();
        }
    }
}