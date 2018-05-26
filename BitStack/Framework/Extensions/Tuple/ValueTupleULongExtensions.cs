using System;

namespace BitStack {

    /**
     * Represents Extension methods for unsigned long value type for working
     * with Tuples.
     */
	public static class ValueTupleULongExtensions {

        /**
         * Combine a 2 value signed int (32 bits per) into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<int, int> tuple) {
			ulong u0 = (uint)tuple.Item1;
			ulong u1 = (uint)tuple.Item2;

			return u0 << 32 | u1;
		}

		/**
         * Combine a 2 value unsigned int (32 bits per) into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<uint, uint> tuple) {
            ulong u0 = tuple.Item1;
            ulong u1 = tuple.Item2;

            return u0 << 32 | u1;
        }

		/**
         * Combine a 4 value signed short (16 bits per) into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<short, short, short, short> tuple) {
			ulong u0 = (ushort)tuple.Item1;
            ulong u1 = (ushort)tuple.Item2;
            ulong u2 = (ushort)tuple.Item3;
            ulong u3 = (ushort)tuple.Item4;

			return u0 << 48 | u1 << 32 | u2 << 16 | u3;
		}

        /**
         * Combine a 4 value unsigned short (16 bits per) into a set of unsigned long (64 bits x 1)
         */
		public static ulong CombineToULong(this ValueTuple<ushort, ushort, ushort, ushort> tuple) {
            ulong u0 = tuple.Item1;
            ulong u1 = tuple.Item2;
            ulong u2 = tuple.Item3;
            ulong u3 = tuple.Item4;

            return u0 << 48 | u1 << 32 | u2 << 16 | u3;
        }

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

		/**
         * Split a single unsigned long value (64 bit x 1) into an 4 value short tuple
         */
        public static ValueTuple<short, short, short, short> SplitIntoShort(this ulong value) {
			short i0 = (short)(value >> 48);
			short i1 = (short)(value >> 32);
			short i2 = (short)(value >> 16);
			short i3 = (short)(value);

			return new ValueTuple<short, short, short, short>(i0, i1, i2, i3);
        }

		/**
         * Split a single unsigned long value (64 bit x 1) into an 4 value ushort tuple
         */
        public static ValueTuple<ushort, ushort, ushort, ushort> SplitIntoUShort(this ulong value) {
            ushort i0 = (ushort)(value >> 48);
            ushort i1 = (ushort)(value >> 32);
            ushort i2 = (ushort)(value >> 16);
            ushort i3 = (ushort)(value);

            return new ValueTuple<ushort, ushort, ushort, ushort>(i0, i1, i2, i3);
        }
        
		/**
         * Split a single unsigned long value (64 bit x 1) into an 2 value int tuple
         */
        public static ValueTuple<int, int> SplitIntoInt(this ulong value) {
			int i0 = (int)(value >> 32);
			int i1 = (int)(value);

			return new ValueTuple<int, int>(i0, i1);
        }

		/**
         * Split a single unsigned long value (64 bit x 1) into an 2 value uint tuple
         */
        public static ValueTuple<uint, uint> SplitIntoUInt(this ulong value) {
            uint i0 = (uint)(value >> 32);
            uint i1 = (uint)(value);

            return new ValueTuple<uint, uint>(i0, i1);
        }
    }
}
