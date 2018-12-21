#if UNITY_EDITOR
#define BITSTACK_DEBUG
#endif

#if NET_4_6 && !BITSTACK_DISABLE_INLINE
#define BITSTACK_METHOD_INLINE
#endif

#if BITSTACK_METHOD_INLINE
using System.Runtime.CompilerServices;
#endif

namespace BitStack {

	/**
	 * Contains useful extension methods for the byte Value datatype.
	 * byte is an unsigned 8 bit value.
	 *
	 * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/byte
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
	public static class ValueByteExtensions {

		/**
		 * Simple method to get a simple true/false value from data
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool Bool(this byte data) {
			return data > 0;
		}

		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 7]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.BitAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return ((data >> pos) & 1);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, 7]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.BitInvAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return 1 - ((data >> pos) & 1);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, 7]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte SetBitAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.SetBitAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return (byte)(data | 1 << pos);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, 7]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte UnsetBitAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.UnsetBitAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return (byte)(data & ~(1 << pos));
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, 7].
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ToggleBitAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.ToggleBitAt(int) - position must be between 0 and 7 but was " + pos);
				}
			#endif
			return (byte)(data ^ (1 << pos));
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, 7]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte SetBit(this byte data, int pos, int bit) {
			#if BITSTACK_DEBUG
				if (pos < 0 || pos > 7) {
					BitDebug.Exception("byte.SetBit(int, int) - position must be between 0 and 7 but was " + pos);
				}
				
				if (bit != 0 && bit != 1) {
					BitDebug.Exception("byte.SetBit(int, int) - bit value must be either 0 or 1 but was " + bit);
				}
			#endif
			int mask = 1 << pos;
			int m1 = (bit << pos) & mask;
			int m2 = data & ~mask;
			
			return (byte)(m2 | m1);
		}

		/**
		 * Count the number of set bits in the provided sbyte value (8 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this byte data) {
			return ((uint)data).PopCount();
		}

		/**
		 * Checks if the provided value is a power of 2.
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static bool IsPowerOfTwo(this byte value) {
			return value != 0 && (value & value - 1) == 0;
		}

		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 0]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this byte data, int pos) {
			#if BITSTACK_DEBUG
				if (pos != 0) {
					BitDebug.Exception("byte.ByteAt(int) - position must be between 0 and 0 but was " + pos);
				}
			#endif
			return data;
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, 0]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte SetByteAt(this byte data, byte newData, int pos) {
			#if BITSTACK_DEBUG
				if (pos != 0) {
					BitDebug.Exception("byte.SetByteAt(int) - position must be between 0 and 0 but was " + pos);
				}
			#endif
			return newData;
		}

		/**
		 * Returns the String representation of the Bit Sequence from the provided
		 * ushort. The String will contain 8 characters of 1 or 0 for each bit position
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string BitString(this byte value) {
		#pragma warning disable XS0001 // Find APIs marked as TODO in Mono
			var stringBuilder = new System.Text.StringBuilder(8);
		#pragma warning restore XS0001 // Find APIs marked as TODO in Mono
		
			for (int i = 7; i >= 0; i--) {
				stringBuilder.Append(value.BitAt(i));
			}
		
			return stringBuilder.ToString();
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteFromBitString(this string data, int readIndex) {
			#if BITSTACK_DEBUG
				if ((readIndex + 8) > data.Length) {
					BitDebug.Exception("string.ByteFromBitString(int) - read index and byte length is less than the string size");
				}
			#endif
			byte value = 0;
		
			for (int i = readIndex, j = 7; i < 8; i++, j--) {
				value = data[i] == '1' ? value.SetBitAt(j) : value.UnsetBitAt(j);
			}
		
			return value;
		}

		/**
		 * Given a string in binary form ie (10110101) convert into
		 * a byte and return. Will only look at the first 8 characters
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteFromBitString(this string data) {
			return data.ByteFromBitString(0);
		}

		/**
		 * Returns the Hex Value as a String.
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static string HexString(this byte value) {
			return value.ToString("X");
		}
		
		/**
		 * Reverse the Bit Sequence of the given value
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ReverseBits(this byte value) {
			return (byte)(((value * 0x80200802UL) & 0x0884422110UL) * 0x0101010101UL >> 32);
		}
	}
}
