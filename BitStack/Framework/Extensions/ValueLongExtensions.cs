
namespace BitStack {

	/**
	 * Contains useful extension methods for the long Value datatype.
	 * long is a signed 64 bit value.
	 * 
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/long
	 */
	public static class ValueLongExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		public static bool Bool(this long data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 63]
		 */
		public static int BitAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.BitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (int)((data >> pos) & 1);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 63]
		 */
		public static int BitInvAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.BitInvAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return 1 - (int)((data >> pos) & 1);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 63]
		 */
		public static long SetBitAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.SetBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (data | 1L << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 63]
		 */
		public static long UnsetBitAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.UnsetBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (data & ~(1L << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 63].
		 */
		public static long ToggleBitAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.ToggleBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return data ^ (1L << pos);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 63]
		 */
		public static long SetBit(this long data, int pos, long bit) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("long.SetBit(int, int) - position must be between 0 and 63 but was " + pos);
				}
				
				if (bit != 0 && bit != 1) {
					BitDebug.Exception("long.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
				}
			#endif
			long mask = 1L << pos;
			long m1 = (bit << pos) & mask;
			long m2 = data & ~mask;
			
			return (m2 | m1);
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
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 7]
		 */
		public static byte ByteAt(this long data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("long.ByteAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return (byte)(data >> (56 - (pos * 8)));
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 3]
		 */
		public static long SetByteAt(this long data, byte newData, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("long.SetByteAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			int shift = 56 - (pos * 8);
			long mask = (long)0xFF << shift;
			long m1 = ((long)newData << shift) & mask;
			long m2 = data & ~mask;
			
			return (m2 | m1);
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * Long. The String will contain 64 characters of 1 or 0 for each bit position
		 */
		public static string BitString(this long value) {
			return ((ulong)value).BitString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static long LongFromBitString(this string data, int readIndex) {
			return (long)data.ULongFromBitString(readIndex);
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static long LongFromBitString(this string data) {
			return data.LongFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		public static string HexString(this long value) {
			return value.ToString("X");
		}
	}
}
