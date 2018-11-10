using System;

namespace BitStack {

	/**
	 * Represents Extension methods for signed int value type for working
	 * with Tuples.
	 */
	public static class ValueTupleIntExtensions {

		/**
		 * Combine a 4 value unsigned byte (8 bits per) into a set of signed int (32 bits x 1)
		 */
		public static int CombineToInt(this ValueTuple<byte, byte, byte, byte> tuple) {
			return (int)tuple.CombineToUInt();
		}

		/**
		 * Combine a 4 value signed byte (8 bits per) into a set of signed int (32 bits x 1)
		 */
		public static int CombineToInt(this ValueTuple<sbyte, sbyte, sbyte, sbyte> tuple) {
			return (int)tuple.CombineToUInt();
		}

		/**
		 * Combine a 2 value signed short (16 bits per) into a set of signed int (32 bits x 1)
		 */
		public static int CombineToInt(this ValueTuple<short, short> tuple) {
			return (int)tuple.CombineToUInt();
		}

		/**
		 * Combine a 2 value unsigned short (16 bits per) into a set of signed int (32 bits x 1)
		 */
		public static int CombineToInt(this ValueTuple<ushort, ushort> tuple) {
			return (int)tuple.CombineToUInt();
		}

		/**
		 * Split a single signed int value (32 bit x 1) into an 4 value byte tuple
		 */
		public static ValueTuple<byte, byte, byte, byte> SplitIntoByte(this int value) {
			return ((uint)value).SplitIntoByte();
		}

		/**
		 * Split a single signed int value (32 bit x 1) into an 4 value sbyte tuple
		 */
		public static ValueTuple<sbyte, sbyte, sbyte, sbyte> SplitIntoSByte(this int value) {
			return ((uint)value).SplitIntoSByte();
		}

		/**
		 * Split a single signed int value (32 bit x 1) into an 2 value short tuple
		 */
		public static ValueTuple<short, short> SplitIntoShort(this int value) {
			return ((uint)value).SplitIntoShort();
		}

		/**
		 * Split a single signed int value (32 bit x 1) into an 2 value ushort tuple
		 */
		public static ValueTuple<ushort, ushort> SplitIntoUShort(this int value) {
			return ((uint)value).SplitIntoUShort();
		}
	}
}
