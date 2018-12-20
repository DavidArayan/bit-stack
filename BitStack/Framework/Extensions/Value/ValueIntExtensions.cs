#if NET_4_6
using System.Runtime.CompilerServices;
#endif

namespace BitStack {

	/**
	 * Contains useful extension methods for the int Value datatype.
	 * int is a signed 32 bit value.
	 * 
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int
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
	public static class ValueIntExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool Bool(this int data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 31]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.BitAt(int) - position must be between 0 and 31 but was " + pos);
				}
			#endif
			return ((data >> pos) & 1);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 31]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.BitInvAt(int) - position must be between 0 and 31 but was " + pos);
				}
			#endif
			return 1 - ((data >> pos) & 1);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 31]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int SetBitAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.SetBitAt(int) - position must be between 0 and 31 but was " + pos);
				}
			#endif
			return (data | 1 << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 31]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int UnsetBitAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.UnsetBitAt(int) - position must be between 0 and 31 but was " + pos);
				}
			#endif
			return (data & ~(1 << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 31].
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int ToggleBitAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.ToggleBitAt(int) - position must be between 0 and 31 but was " + pos);
				}
			#endif
			return (data ^ (1 << pos));
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 31]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int SetBit(this int data, int pos, int bit) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 31) {
					BitDebug.Exception("int.SetBit(int, int) - position must be between 0 and 31 but was " + pos);
				}
				
				if (bit != 0 && bit != 1) {
					BitDebug.Exception("int.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
				}
			#endif
			int mask = 1 << pos;
			int m1 = (bit << pos) & mask;
			int m2 = data & ~mask;
			
			return (m2 | m1);
		}

		/**
		 * Count the number of set bits in the provided int value (32 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this int value) {
			return ((uint)value).PopCount();
		}

		/**
		 * Checks if the provided value is a power of 2.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool IsPowerOfTwo(this int value) {
			return value != 0 && (value & value - 1) == 0;
		}

		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 3]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this int data, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 3) {
					BitDebug.Exception("int.ByteAt(int) - position must be between 0 and 3 but was " + pos);
				}
			#endif
			return (byte)(data >> (24 - (pos * 8)));
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 3]
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int SetByteAt(this int data, byte newData, int pos) {
			#if UNITY_EDITOR || DEBUG
				if (pos < 0 || pos > 3) {
					BitDebug.Exception("int.SetByteAt(int) - position must be between 0 and 3 but was " + pos);
				}
			#endif
			int shift = 24 - (pos * 8);
			int mask = 0xFF << shift;
			int m1 = (newData << shift) & mask;
			int m2 = data & ~mask;
			
			return (m2 | m1);
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * Int. The String will contain 32 characters of 1 or 0 for each bit position
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string BitString(this int value) {
			return ((uint)value).BitString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int IntFromBitString(this string data, int readIndex) {
			return (int)data.UIntFromBitString(readIndex);
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int IntFromBitString(this string data) {
			return data.IntFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		#if NET_4_6
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string HexString(this int value) {
			return value.ToString("X");
		}
	}
}
