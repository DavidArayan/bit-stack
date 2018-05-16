using System;

namespace BitStack {

    /**
     * Contains simple utility methods for dealing with decimal numbers. These are often
     * required for writing robust code to deal with precision loss for real time applications.
     */
	public static class ValueDecimalExtensions {

        /**
         * Perform a robust approximate equality test between two 32 bit
         * floating point numbers.
         */
		public static bool IsEqual(this float x, float y) {
			return Math.Abs(x - y) <= float.Epsilon * Math.Max(Math.Abs(x), Math.Abs(y));
        }

		/**
         * Perform a robust approximate equality test between two 64 bit
         * floating point numbers.
         */
		public static bool IsEqual(this double x, double y) {
			return Math.Abs(x - y) <= double.Epsilon * Math.Max(Math.Abs(x), Math.Abs(y));
        }
    }
}
