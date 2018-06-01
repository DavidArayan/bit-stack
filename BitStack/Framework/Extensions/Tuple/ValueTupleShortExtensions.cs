using System;

namespace BitStack {

	/**
     * Represents Extension methods for signed short value type for working
     * with Tuples.
     */
	public static class ValueTupleShortExtensions {

		/**
         * Combine a 2 value unsigned byte (8 bits per) into a set of signed short (16 bits x 1)
         */
		public static short CombineToShort(this ValueTuple<byte, byte> tuple) {
			return (short)tuple.CombineToUShort();
		}

		/**
         * Combine a 2 value signed byte (8 bits per) into a set of signed short (16 bits x 1)
         */
		public static short CombineToShort(this ValueTuple<sbyte, sbyte> tuple) {
			return (short)tuple.CombineToUShort();
		}

		/**
         * Split a single signed short value (16 bit x 1) into an 2 value byte tuple
         */
		public static ValueTuple<byte, byte> SplitIntoByte(this short value) {
			return ((ushort)value).SplitIntoByte();
		}

		/**
         * Split a single signed short value (16 bit x 1) into an 2 value sbyte tuple
         */
		public static ValueTuple<sbyte, sbyte> SplitIntoSByte(this short value) {
			return ((ushort)value).SplitIntoSByte();
		}
	}
}
