#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {

	/**
	 * Contains useful extension methods for the short Value datatype.
	 * ushort is an unsigned 16 bit value.
	 * 
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ushort
	 *
	 * NOTICE ABOUT PERFORMANCE
	 * 
	 * UNITY_EDITOR or DEBUG flags ensure that common errors are caught. These
	 * flags are removed in production mode so don't rely on try/catch methods.
	 * If performing benchmarks, ensure that the flags are not taken into account.
	 * The flags ensure that common problems are caught in code and taken care of.
	 *
	 * CRITICAL CHANGES
	 * 20/12/2018 - for .NET 4.6 targets, all functions are hinted to use AggressiveInlining
	 */
	public static class ValueUShortExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool Bool(this ushort data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 15]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.BitAt(int) - position must be between 0 and 15 but was " + pos);
				}
			#endif
			return ((data >> pos) & 1);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 15]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.BitInvAt(int) - position must be between 0 and 15 but was " + pos);
				}
			#endif
			return 1 - ((data >> pos) & 1);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 15]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort SetBitAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.SetBitAt(int) - position must be between 0 and 15 but was " + pos);
				}
			#endif
			return (ushort)(data | 1u << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 15]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort UnsetBitAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.UnsetBitAt(int) - position must be between 0 and 15 but was " + pos);
				}
			#endif
			return (ushort)(data & ~(1u << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 15].
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort ToggleBitAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.ToggleBitAt(int) - position must be between 0 and 15 but was " + pos);
				}
			#endif
			return (ushort)(data ^ (1u << pos));
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 15]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort SetBit(this ushort data, int pos, int bit) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 15) {
					BitDebug.Exception("ushort.SetBit(int, int) - position must be between 0 and 15 but was " + pos);
				}
				
				if (bit != 0 && bit != 1) {
					BitDebug.Exception("ushort.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
				}
			#endif
			int mask = 1 << pos;
			int m1 = (bit << pos) & mask;
			int m2 = data & ~mask;
			
			return (ushort)(m2 | m1);
		}

		/**
		 * Count the number of set bits in the provided short value (16 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this ushort data) {
			return ((uint)data).PopCount();
		}

		/**
		 * Checks if the provided value is a power of 2.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool IsPowerOfTwo(this ushort value) {
			return value != 0 && (value & value - 1) == 0;
		}
		
		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 1]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this ushort data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 1) {
					BitDebug.Exception("ushort.ByteAt(int) - position must be between 0 and 1 but was " + pos);
				}
			#endif
			return (byte)(data >> (8 - (pos * 8)));
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 1]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort SetByteAt(this ushort data, byte newData, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 1) {
					BitDebug.Exception("ushort.SetByteAt(int) - position must be between 0 and 1 but was " + pos);
				}
			#endif
			int shift = 8 - (pos * 8);
			int mask = 0xFF << shift;
			int m1 = (newData << shift) & mask;
			int m2 = data & ~mask;
			
			return (ushort)(m2 | m1);
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * ushort. The String will contain 16 characters of 1 or 0 for each bit position
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string BitString(this ushort value) {
#pragma warning disable XS0001 // Find APIs marked as TODO in Mono
			var stringBuilder = new System.Text.StringBuilder(16);
#pragma warning restore XS0001 // Find APIs marked as TODO in Mono

			for (int i = 15; i >= 0; i--) {
				stringBuilder.Append(value.BitAt(i));
			}

			return stringBuilder.ToString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort UShortFromBitString(this string data, int readIndex) {
			#if UNITY_EDITOR || DEBUG
				if ((readIndex + 16) > data.Length) {
					BitDebug.Exception("string.UShortFromBitString(int) - read index and ushort length is less than the string size");
				}
			#endif
			ushort value = 0;

			for (int i = readIndex, j = 15; i < 16; i++, j--) {
				value = data[i] == '1' ? value.SetBitAt(j) : value.UnsetBitAt(j);
			}

			return value;
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static ushort UShortFromBitString(this string data) {
			return data.UShortFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string HexString(this ushort value) {
			return value.ToString("X");
		}
	}
}
