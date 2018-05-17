
namespace BitStack {

	/**
     * Contains useful extension methods for the int Value datatype.
     * int is a signed 32 bit value.
     * 
     * For more info visit https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int
     */
	public static class ValueIntExtensions {
        
		/**
         * Simple method to get a simple true/false value from data
         */
        public static bool Bool(this int data) {
            return data > 0;
        }

        /**
         * Return the state of the bit (either 1 or 0) at provided
         * position. position value must be between [0, 31]
         */
        public static int BitAt(this int data, int pos) {
			return ((data >> pos) & 1);
        }

        /**
         * Sets the state of the bit into the ON/1 at provided
         * position. position value must be between [0, 31]
         */
        public static int SetBitAt(this int data, int pos) {
            return (data | 1 << pos);
        }

        /**
         * Sets the state of the bit into the OFF/0 at provided
         * position. position value must be between [0, 31]
         */
        public static int UnsetBitAt(this int data, int pos) {
            return (data & ~(1 << pos));
        }

        /**
         * Toggles the state of the bit into the ON/1 or OFF/0 at provided
         * position. position value must be between [0, 31].
         */
        public static int ToggleBitAt(this int data, int pos) {
			return (data ^ (1 << pos));
        }

        /**
         * Count the number of set bits in the provided int value (32 bits)
         * A general purpose Hamming Weight or popcount function which returns the number of
         * set bits in the argument.
         */
        public static int PopCount(this int value) {
			return ((uint)value).PopCount();
        }

        /**
         * Checks if the provided value is a power of 2.
         */
        public static bool IsPowerOfTwo(this int value) {
            return value != 0 && (value & value - 1) == 0;
        }

        /**
         * Returns the String representation of the Bit Sequence from the provided
         * Int. The String will contain 32 characters of 1 or 0 for each bit position
         */
        public static string BitString(this int value) {
			return ((uint)value).BitString();
        }

        /**
         * Returns the Hex Value as a String.
         */
        public static string HexString(this int value) {
            return value.ToString("X");
        }
    }
}
