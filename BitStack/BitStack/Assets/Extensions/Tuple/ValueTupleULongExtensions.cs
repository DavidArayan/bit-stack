using UnityEngine;
using System.Collections;
using System;

namespace BitStack {

    /**
     * Represents Extension methods for unsigned long value type for working
     * with Tuples.
     */
	public static class ValueTupleULongExtensions {

		/**
         * Combine an 8 value byte tuple into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> tuple) {
			var upper = tuple.Item1;
			var lower = tuple.Item2;

			ulong u0 = upper.Item1;
			ulong u1 = upper.Item2;
			ulong u2 = upper.Item3;
			ulong u3 = upper.Item4;

			ulong l0 = lower.Item1;
			ulong l1 = lower.Item2;
			ulong l2 = lower.Item3;
			ulong l3 = lower.Item4;

			return u0 << 56 | u1 << 48 | u2 << 40 | u3 << 32 | l0 << 24 | l1 << 16 | l2 << 8 | l3;
        }

		/**
         * Combine an 8 value sbyte tuple into a set of unsigned long (64 bits x 1)
         */
        public static ulong CombineToULong(this ValueTuple<ValueTuple<sbyte, sbyte, sbyte, sbyte>, ValueTuple<sbyte, sbyte, sbyte, sbyte>> tuple) {
            var upper = tuple.Item1;
            var lower = tuple.Item2;

            ulong u0 = (byte)upper.Item1;
            ulong u1 = (byte)upper.Item2;
            ulong u2 = (byte)upper.Item3;
            ulong u3 = (byte)upper.Item4;

            ulong l0 = (byte)lower.Item1;
            ulong l1 = (byte)lower.Item2;
            ulong l2 = (byte)lower.Item3;
            ulong l3 = (byte)lower.Item4;

            return u0 << 56 | u1 << 48 | u2 << 40 | u3 << 32 | l0 << 24 | l1 << 16 | l2 << 8 | l3;
        }
        
        /**
         * Split a single unsigned long value (64 bit x 1) into an 8 value byte tuple
         */
		public static ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>> SplitIntoByte(this ulong value) {
			byte i0 = (byte)(value >> 56);
			byte i1 = (byte)(value >> 48);
			byte i2 = (byte)(value >> 40);
			byte i3 = (byte)(value >> 32);

			byte i4 = (byte)(value >> 24);
			byte i5 = (byte)(value >> 16);
			byte i6 = (byte)(value >> 8);
			byte i7 = (byte)(value);

			var upper = new ValueTuple<byte, byte, byte, byte>(i0, i1, i2, i3);
			var lower = new ValueTuple<byte, byte, byte, byte>(i4, i5, i6, i7);

			return new ValueTuple<ValueTuple<byte, byte, byte, byte>, ValueTuple<byte, byte, byte, byte>>(upper, lower);
		}

		/**
         * Split a single unsigned long value (64 bit x 1) into an 8 value sbyte tuple
         */
        public static ValueTuple<ValueTuple<sbyte, sbyte, sbyte, sbyte>, ValueTuple<sbyte, sbyte, sbyte, sbyte>> SplitIntoSByte(this ulong value) {
            sbyte i0 = (sbyte)(value >> 56);
            sbyte i1 = (sbyte)(value >> 48);
            sbyte i2 = (sbyte)(value >> 40);
            sbyte i3 = (sbyte)(value >> 32);

            sbyte i4 = (sbyte)(value >> 24);
            sbyte i5 = (sbyte)(value >> 16);
            sbyte i6 = (sbyte)(value >> 8);
            sbyte i7 = (sbyte)(value);

            var upper = new ValueTuple<sbyte, sbyte, sbyte, sbyte>(i0, i1, i2, i3);
            var lower = new ValueTuple<sbyte, sbyte, sbyte, sbyte>(i4, i5, i6, i7);

            return new ValueTuple<ValueTuple<sbyte, sbyte, sbyte, sbyte>, ValueTuple<sbyte, sbyte, sbyte, sbyte>>(upper, lower);
        }
    }
}
