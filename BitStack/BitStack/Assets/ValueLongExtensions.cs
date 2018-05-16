
namespace BitStack {
	
    /**
     * Contains useful extension methods for the long Value datatype.
     * long is a signed 64 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/long
     */
	public static class ValueLongExtensions {

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 63]
         */
		public static int BitAt(this long data, int pos) {
            return (int)((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 63]
         */
        public static long SetBitAt(this long data, int pos) {
            return (data | 1L << pos);
        }

		/**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 63]
         */
        public static long UnsetBitAt(this long data, int pos) {
            return (data & ~(1L << pos));
        }

		/**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 63].
         */
        public static long ToggleBitAt(this long data, int pos) {
            return data ^ (1L << pos);
        }

		/**
         * Count the number of set bits in the provided long value (64 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
        public static int PopCount(this long value) {
			return ((ulong)value).PopCount();
        }

		/**
         * Checks if the provided value is a power of 2.
         */
        public static bool IsPowerOfTwo(this long value) {
            return value != 0 && (value & value - 1) == 0;
        }
        
        /**
         * Returns the String representation of the Bit Sequence from the provided
         * Long. The String will contain 64 characters of 1 or 0 for each bit position
         */
        public static string BitString(this long value) {
			return ((ulong)value).BitString();
        }

        /**
         * Returns the Hex Value as a String.
         */
		public static string HexString(this long value) {
			return value.ToString("X");
		}

		/**
         * Allows combining 8 x 8 bit byte values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit long value into 8 x 8 bit byte values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitByte(this long value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 8 x 8 bit sbyte values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit ulong value into 8 x 8 bit sbyte values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte> SplitSByte(this long value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 4 x 16 bit ushort values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<ushort, ushort, ushort, ushort> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit ulong value into 4 x 16 bit ushort values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<ushort, ushort, ushort, ushort> SplitUShort(this long value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 4 x 16 bit short values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<short, short, short, short> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit ulong value into 4 x 16 bit short values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<short, short, short, short> SplitShort(this long value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 2 x 32 bit uint values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<uint, uint> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit ulong value into 2 x 32 bit uint values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<uint, uint> SplitUInt(this long value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 2 x 32 bit int values into a single signed 64 bit long value
         * Accepts a System.ValueTuple type
         */
        public static long Combine(this System.ValueTuple<int, int> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single signed 64 bit ulong value into 2 x 32 bit int values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<int, int> SplitInt(this long value) {
            throw new System.Exception("unimplemented");
        }
    }
}
