
namespace BitStack {

	/**
	 * Contains useful extension methods for the short Value datatype.
	 * short is a signed 16 bit value.
	 * 
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/short
	 */
	public static class ValueShortExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		public static bool Bool(this short data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 15]
		 */
		public static int BitAt(this short data, int pos) {
			return ((data >> pos) & 1);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 15]
		 */
		public static short SetBitAt(this short data, int pos) {
			return (short)((ushort)data | 1u << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 15]
		 */
		public static short UnsetBitAt(this short data, int pos) {
			return (short)(data & ~(1 << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 15].
		 */
		public static short ToggleBitAt(this short data, int pos) {
			return (short)(data ^ (1 << pos));
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 15]
		 */
		public static short SetBit(this short data, int pos, short bit) {
			int mask = 1 << pos;
			int m1 = (bit << pos) & mask;
			int m2 = data & ~mask;
			
			return (short)(m2 | m1);
		}

		/**
		 * Count the number of set bits in the provided ushort value (16 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		public static int PopCount(this short data) {
			return ((ushort)data).PopCount();
		}

		/**
		 * Checks if the provided value is a power of 2.
		 */
		public static bool IsPowerOfTwo(this short value) {
			return value != 0 && (value & value - 1) == 0;
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * ushort. The String will contain 16 characters of 1 or 0 for each bit position
		 */
		public static string BitString(this short value) {
			return ((ushort)value).BitString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static short ShortFromBitString(this string data, int readIndex) {
			return (short)data.UShortFromBitString(readIndex);
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static short ShortFromBitString(this string data) {
			return data.ShortFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		public static string HexString(this short value) {
			return value.ToString("X");
		}
	}
}
