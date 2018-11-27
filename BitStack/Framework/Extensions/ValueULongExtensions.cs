
namespace BitStack {

	/**
	 * Contains useful extension methods for the ulong Value datatype.
	 * ulong is an unsigned 64 bit value.
	 * 
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ulong
	 */
	public static class ValueULongExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		public static bool Bool(this ulong data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 63]
		 */
		public static int BitAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.BitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (int)((data >> pos) & 1Lu);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 63]
		 */
		public static int BitInvAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.BitInvAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return 1 - (int)((data >> pos) & 1Lu);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 63]
		 */
		public static ulong SetBitAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.SetBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (data | 1Lu << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 63]
		 */
		public static ulong UnsetBitAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.UnsetBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return (data & ~(1Lu << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 63].
		 */
		public static ulong ToggleBitAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.ToggleBitAt(int) - position must be between 0 and 63 but was " + pos);
				}
			#endif
			return data ^ (1Lu << pos);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 63]
		 */
		public static ulong SetBit(this ulong data, int pos, long bit) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 63) {
					BitDebug.Exception("ulong.SetBit(int, int) - position must be between 0 and 63 but was " + pos);
				}
				
				if (bit != 0 && bit != 1) {
					BitDebug.Exception("ulong.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
				}
			#endif
			ulong mask = 1Lu << pos;
			ulong m1 = ((ulong)bit << pos) & mask;
			ulong m2 = data & ~mask;
			
			return (m2 | m1);
		}

		/**
		 * Count the number of set bits in the provided ulong value (64 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		public static int PopCount(this ulong value) {
			value -= (value >> 1) & 0x5555555555555555;
			value = (value & 0x3333333333333333) + ((value >> 2) & 0x3333333333333333);
			value = (value + (value >> 4)) & 0x0f0f0f0f0f0f0f0f;

			return (int)((value * 0x0101010101010101) >> 56);
		}

		/**
		 * Checks if the provided value is a power of 2.
		 */
		public static bool IsPowerOfTwo(this ulong value) {
			return value != 0 && (value & value - 1) == 0;
		}
		
		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 7]
		 */
		public static byte ByteAt(this ulong data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("ulong.ByteAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return (byte)(data >> (56 - (pos * 8)));
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 3]
		 */
		public static ulong SetByteAt(this ulong data, byte newData, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("ulong.SetByteAt(int) - position must be between 0 and 3 but was " + pos);
				}
			#endif
			int shift = (newData << (8 * pos));
			ulong mask = ((ulong)0xff) << shift;
			return (ulong)((~mask & data) | (ulong)(shift));
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * Long. The String will contain 64 characters of 1 or 0 for each bit position
		 */
		public static string BitString(this ulong value) {
#pragma warning disable XS0001 // Find APIs marked as TODO in Mono
			var stringBuilder = new System.Text.StringBuilder(64);
#pragma warning restore XS0001 // Find APIs marked as TODO in Mono

			for (int i = 63; i >= 0; i--) {
				stringBuilder.Append(value.BitAt(i));
			}

			return stringBuilder.ToString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static ulong ULongFromBitString(this string data, int readIndex) {
			#if UNITY_EDITOR || DEBUG
				if ((readIndex + 64) > data.Length) {
					BitDebug.Exception("string.ULongFromBitString(int) - read index and ulong length is less than the string size");
				}
			#endif
			ulong value = 0;

			for (int i = readIndex, j = 63; i < 64; i++, j--) {
				value = data[i] == '1' ? value.SetBitAt(j) : value.UnsetBitAt(j);
			}

			return value;
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		public static ulong ULongFromBitString(this string data) {
			return data.ULongFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		public static string HexString(this ulong value) {
			return value.ToString("X");
		}
	}
}
