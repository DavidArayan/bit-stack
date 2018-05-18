
namespace BitStack {

	/**
     * Contains useful extension methods for the sbyte Value datatype.
     * sbyte is a signed 8 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sbyte
     */
	public static class ValueSByteExtensions {

		/**
         * Simple method to get a simple true/false value from data
         */
        public static bool Bool(this sbyte data) {
            return data > 0;
        }

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 7]
         */
        public static int BitAt(this sbyte data, int pos) {
            return ((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 7]
         */
		public static sbyte SetBitAt(this sbyte data, int pos) {
			return (sbyte)((byte)data | 1 << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 7]
         */
		public static sbyte UnsetBitAt(this sbyte data, int pos) {
			return (sbyte)(data & ~(1 << pos));
        }

        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 7].
         */
		public static sbyte ToggleBitAt(this sbyte data, int pos) {
			return (sbyte)(data ^ (1 << pos));
        }

        /**
         * Count the number of set bits in the provided sbyte value (8 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
		public static int PopCount(this sbyte data) {
            return ((byte)data).PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
		public static bool IsPowerOfTwo(this sbyte value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * ushort. The String will contain 8 characters of 1 or 0 for each bit position
         */
		public static string BitString(this sbyte value) {
			return ((byte)value).BitString();
        }

		/**
         * Given a string in binary form ie (10110101) convert into
         * a byte and return. Will only look at the first 8 characters
         */
        public static sbyte SByteFromBitString(this string data, int readIndex) {
			return (sbyte)data.ByteFromBitString(readIndex);
        }

        /**
         * Given a string in binary form ie (10110101) convert into
         * a byte and return. Will only look at the first 8 characters
         */
        public static sbyte SByteFromBitString(this string data) {
            return data.SByteFromBitString(0);
        }

        /**
         * Returns the Hex Value as a String.
         */
		public static string HexString(this sbyte value) {
            return value.ToString("X");
        }
    }
}
