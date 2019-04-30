#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;

namespace BitStack {

	/**
	 * Represents Extension methods for unsigned int value type for working
	 * with Tuples.
	 */
	public static sealed class ValueTupleUIntExtensions {

		/**
		 * Combine a 4 value unsigned byte (8 bits per) into a set of unsigned int (32 bits x 1)
		 */
		public static uint CombineToUInt(this ValueTuple<byte, byte, byte, byte> tuple) {
			uint l0 = tuple.Item1;
			uint l1 = tuple.Item2;
			uint l2 = tuple.Item3;
			uint l3 = tuple.Item4;

			return l0 << 24 | l1 << 16 | l2 << 8 | l3;
		}

		/**
		 * Combine a 4 value signed byte (8 bits per) into a set of unsigned int (32 bits x 1)
		 */
		public static uint CombineToUInt(this ValueTuple<sbyte, sbyte, sbyte, sbyte> tuple) {
			uint l0 = (byte)tuple.Item1;
			uint l1 = (byte)tuple.Item2;
			uint l2 = (byte)tuple.Item3;
			uint l3 = (byte)tuple.Item4;

			return l0 << 24 | l1 << 16 | l2 << 8 | l3;
		}

		/**
		 * Combine a 2 value signed short (16 bits per) into a set of unsigned int (32 bits x 1)
		 */
		public static uint CombineToUInt(this ValueTuple<short, short> tuple) {
			uint u0 = (ushort)tuple.Item1;
			uint u1 = (ushort)tuple.Item2;

			return u0 << 16 | u1;
		}

		/**
		 * Combine a 2 value unsigned short (16 bits per) into a set of unsigned int (32 bits x 1)
		 */
		public static uint CombineToUInt(this ValueTuple<ushort, ushort> tuple) {
			uint u0 = tuple.Item1;
			uint u1 = tuple.Item2;

			return u0 << 16 | u1;
		}

		/**
		 * Split a single unsigned int value (32 bit x 1) into an 4 value byte tuple
		 */
		public static ValueTuple<byte, byte, byte, byte> SplitIntoByte(this uint value) {
			var i0 = (byte)(value >> 24);
			var i1 = (byte)(value >> 16);
			var i2 = (byte)(value >> 8);
			var i3 = (byte)(value);

			return new ValueTuple<byte, byte, byte, byte>(i0, i1, i2, i3);
		}

		/**
		 * Split a single unsigned int value (32 bit x 1) into an 4 value sbyte tuple
		 */
		public static ValueTuple<sbyte, sbyte, sbyte, sbyte> SplitIntoSByte(this uint value) {
			var i0 = (sbyte)(value >> 24);
			var i1 = (sbyte)(value >> 16);
			var i2 = (sbyte)(value >> 8);
			var i3 = (sbyte)(value);

			return new ValueTuple<sbyte, sbyte, sbyte, sbyte>(i0, i1, i2, i3);
		}

		/**
		 * Split a single unsigned int value (32 bit x 1) into an 2 value short tuple
		 */
		public static ValueTuple<short, short> SplitIntoShort(this uint value) {
			var i0 = (short)(value >> 16);
			var i1 = (short)(value);

			return new ValueTuple<short, short>(i0, i1);
		}

		/**
		 * Split a single unsigned int value (32 bit x 1) into an 2 value ushort tuple
		 */
		public static ValueTuple<ushort, ushort> SplitIntoUShort(this uint value) {
			var i0 = (ushort)(value >> 16);
			var i1 = (ushort)(value);

			return new ValueTuple<ushort, ushort>(i0, i1);
		}
	}
}
