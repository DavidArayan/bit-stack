
namespace BitStack {
    
	/**
     * Contains useful extension methods for the ulong Value datatype.
     * ulong is an unsigned 64 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ulong
     */
	public static class ValueULongExtension {

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 63]
         */
        public static int BitAt(this ulong data, int pos) {
            return (int)((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 63]
         */
        public static ulong SetBitAt(this ulong data, int pos) {
            return (data | 1U << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 63]
         */
        public static ulong UnsetBitAt(this ulong data, int pos) {
            return (data & ~(1U << pos));
        }
        
        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 63].
         */
        public static ulong ToggleBitAt(this ulong data, int pos) {
            return data ^ (1U << pos);
        }
        
        /**
         * Count the number of set bits in the provided ulong value (64 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
        public static int PopCount(this ulong value) {
            uint upper = (uint)value;
            uint lower = (uint)(value >> 32);

            return upper.PopCount() + lower.PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
        public static bool IsPowerOfTwo(this ulong value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * Long. The String will contain 64 characters of 1 or 0 for each bit position
         */
        public static string BitString(this ulong value) {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(64);

            for (int i = 0; i < 64; i++) {
                stringBuilder.Append(value.BitAt(i));
            }

            return stringBuilder.ToString();
        }

        /**
         * Returns the Hex Value as a String.
         */
        public static string HexString(this ulong value) {
            return value.ToString("X");
        }

        /**
         * Allows combining 8 x 8 bit byte values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> tuple) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows splitting a single unsigned 64 but ulong value into 8 x 8 bit byte values.
         * Returns a System.ValueTuple of the split values
         */
		public static System.ValueTuple<byte, byte, byte, byte, byte, byte, byte, byte> SplitByte(this ulong value) {
			throw new System.Exception("unimplemented");
		}

        /**
         * Allows combining 8 x 8 bit sbyte values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte> tuple) {
            throw new System.Exception("unimplemented");
        }

		/**
         * Allows splitting a single unsigned 64 but ulong value into 8 x 8 bit sbyte values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte, sbyte> SplitSByte(this ulong value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 4 x 16 bit ushort values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<ushort, ushort, ushort, ushort> tuple) {
			throw new System.Exception("unimplemented");
		}

		/**
         * Allows splitting a single unsigned 64 but ulong value into 4 x 16 bit ushort values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<ushort, ushort, ushort, ushort> SplitUShort(this ulong value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 4 x 16 bit short values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<short, short, short, short> tuple) {
			throw new System.Exception("unimplemented");
		}

		/**
         * Allows splitting a single unsigned 64 but ulong value into 4 x 16 bit short values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<short, short, short, short> SplitShort(this ulong value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 2 x 32 bit uint values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<uint, uint> tuple) {
			throw new System.Exception("unimplemented");
		}

		/**
         * Allows splitting a single unsigned 64 but ulong value into 2 x 32 bit uint values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<uint, uint> SplitUInt(this ulong value) {
            throw new System.Exception("unimplemented");
        }

        /**
         * Allows combining 2 x 32 bit int values into a single unsigned 64 bit long value
         * Accepts a System.ValueTuple type
         */
		public static ulong Combine(this System.ValueTuple<int, int> tuple) {
			throw new System.Exception("unimplemented");
		}

		/**
         * Allows splitting a single unsigned 64 but ulong value into 2 x 32 bit int values.
         * Returns a System.ValueTuple of the split values
         */
        public static System.ValueTuple<int, int> SplitInt(this ulong value) {
            throw new System.Exception("unimplemented");
        }
    }
}
