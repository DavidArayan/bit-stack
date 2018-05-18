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
		public static bool IsEqual(this float a, float b) {
			const float floatNormal = (1 << 23) * float.Epsilon;
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

			// Shortcut, handles infinities
            if (a == b) {
                return true;
            }

			// a or b is zero, or both are extremely close to it.
            // relative error is less meaningful here
            if (a == 0.0f || b == 0.0f || diff < floatNormal) {
                return diff < (floatNormal * 0.00001f);
            }

            // use relative error
			return diff < Math.Min((absA + absB), float.MaxValue) * 0.00001f;
        }

		/**
         * Perform a robust approximate equality test between two 64 bit
         * floating point numbers.
         */
		public static bool IsEqual(this double a, double b) {
			const double doubleNormal = (1L << 52) * double.Epsilon;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);

            // Shortcut, handles infinities
            if (a == b) {
                return true;
            }

            // a or b is zero, or both are extremely close to it.
            // relative error is less meaningful here
			if (a == 0.0 || b == 0.0 || diff < doubleNormal) {
				return diff < (doubleNormal * 0.00000001);
            }
            
            // use relative error
			return diff < Math.Min((absA + absB), double.MaxValue) * 0.00000001;
        }
    }
}
