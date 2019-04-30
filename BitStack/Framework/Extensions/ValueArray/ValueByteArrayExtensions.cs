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
	 * An Extension of the ValueByteExtension which allows working with bits
	 * on an array of values. All functionality is piped directly to the
	 * ValueByteExtension whenever possible. 
	 *
	 * Since Arrays are a reference type, some functions will not return 
	 * anything and will modify the array value directly.
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
	public static sealed class ValueByteArrayExtensions {
		const int BIT_LEN = 8;
		
		/**
		 * Return the state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitAt(this byte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].BitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].BitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].BitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitAt(pos % BIT_LEN);
		}
		
		/**
		 * Return the inverted state of the bit (either 1 or 0) at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int BitInvAt(this byte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].BitInvAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].BitInvAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].BitInvAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			return data[bitIndex].BitInvAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the ON/1 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBitAt(this byte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].SetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].SetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].SetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBitAt(pos % BIT_LEN);
		}

		/**
		 * Sets the state of the bit into the OFF/0 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void UnsetBitAt(this byte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].UnsetBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].UnsetBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].UnsetBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].UnsetBitAt(pos % BIT_LEN);
		}

		/**
		 * Toggles the state of the bit into the ON/1 or OFF/0 at provided
		 * position. position value must be between [0, data.Length * 8].
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void ToggleBitAt(this byte[] data, int pos) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].ToggleBitAt(int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].ToggleBitAt(int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].ToggleBitAt(int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].ToggleBitAt(pos % BIT_LEN);
		}
		
		/**
		 * Sets the state of the bit into the OFF/0 or ON/1 at provided
		 * position. position value must be between [0, data.Length * 8]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetBit(this byte[] data, int pos, int bit) {
			int bitIndex = pos / BIT_LEN;
			
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].SetBit(int, int) - bit position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].SetBit(int, int) - array is null");
				}
				
				if (bitIndex > data.Length) {
					BitDebug.Exception("byte[].SetBit(int, int) - bit bucket must not be greater than array " + data.Length + " was " + bitIndex);
				}
			#endif
			
			// pipe into the single value type
			data[bitIndex] = data[bitIndex].SetBit(pos % BIT_LEN, bit);
		}

		/**
		 * Count the number of set bits in the provided byte array (8 bits)
		 * A general purpose Hamming Weight or popcount function which returns the number of
		 * set bits in the argument.
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static int PopCount(this byte[] data) {
			#if BITSTACK_DEBUG
				if (data == null) {
					BitDebug.Exception("byte[].PopCount() - array is null");
				}
			#endif
			
			int counter = 0;
			int length = data.Length;
			
			for (int i = 0; i < length; i++) {
				counter += data[i].PopCount();
			}
			
			return counter;
		}

		/**
		 * Returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static byte ByteAt(this byte[] data, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].ByteAt(int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].ByteAt(int) - array is null");
				}
				
				if (pos > data.Length) {
					BitDebug.Exception("byte[].ByteAt(int) - byte bucket must not be greater than array " + data.Length + " was " + pos);
				}
			#endif
			
			return data[pos];
		}

		/**
		 * Sets and returns the byte (8 bits) at provided position index
		 * Position value must be between [0, data.Length]
		 */
		#if BITSTACK_METHOD_INLINE
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		#endif
		public static void SetByteAt(this byte[] data, byte newData, int pos) {
			#if BITSTACK_DEBUG
				if (pos < 0) {
					BitDebug.Exception("byte[].SetByteAt(byte, int) - byte position must not be less than 0 was " + pos);
				}
				
				if (data == null) {
					BitDebug.Exception("byte[].SetByteAt(byte, int) - array is null");
				}
				
				if (pos > data.Length) {
					BitDebug.Exception("byte[].SetByteAt(byte, int) - byte bucket must not be greater than array " + data.Length + " was " + pos);
				}
			#endif
			
			data[pos] = newData;
		}
	}
}
