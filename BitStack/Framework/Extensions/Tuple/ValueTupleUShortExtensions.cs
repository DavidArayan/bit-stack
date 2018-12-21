#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

using System;

namespace BitStack {

	/**
	 * Represents Extension methods for unsigned short value type for working
	 * with Tuples.
	 */
	public static class ValueTupleUShortExtensions {

		/**
		 * Combine a 2 value unsigned byte (8 bits per) into a set of unsigned short (16 bits x 1)
		 */
		public static ushort CombineToUShort(this ValueTuple<byte, byte> tuple) {
			ushort l0 = tuple.Item1;
			ushort l1 = tuple.Item2;

			return (ushort)(l0 << 8 | l1);
		}

		/**
		 * Combine a 2 value signed byte (8 bits per) into a set of unsigned short (16 bits x 1)
		 */
		public static ushort CombineToUShort(this ValueTuple<sbyte, sbyte> tuple) {
			ushort l0 = (byte)tuple.Item1;
			ushort l1 = (byte)tuple.Item2;

			return (ushort)(l0 << 8 | l1);
		}

		/**
		 * Split a single unsigned short value (16 bit x 1) into an 2 value byte tuple
		 */
		public static ValueTuple<byte, byte> SplitIntoByte(this ushort value) {
			var i0 = (byte)(value >> 8);
			var i1 = (byte)(value);

			return new ValueTuple<byte, byte>(i0, i1);
		}

		/**
		 * Split a single unsigned short value (16 bit x 1) into an 2 value sbyte tuple
		 */
		public static ValueTuple<sbyte, sbyte> SplitIntoSByte(this ushort value) {
			var i0 = (sbyte)(value >> 8);
			var i1 = (sbyte)(value);

			return new ValueTuple<sbyte, sbyte>(i0, i1);
		}
	}
}
