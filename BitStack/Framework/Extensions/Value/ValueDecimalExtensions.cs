using System;

namespace BitStack {

	/**
	 * Contains simple utility methods for dealing with decimal numbers. These are often
	 * required for writing robust code to deal with precision loss for real time applications.
	 */
	public static class ValueDecimalExtensions {

		const float FLOAT_NORMAL = (1 << 23) * float.Epsilon;
		const double DOUBLE_NORMAL = (1L << 52) * double.Epsilon;

		/**
		 * Perform a robust approximate equality test between two 32 bit
		 * floating point numbers.
		 */
		public static bool IsEqual(this float a, float b) {
#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
			var absA = Math.Abs(a);
			var absB = Math.Abs(b);
			var diff = Math.Abs(a - b);

			// Shortcut, handles infinities
			if (a == b) {
				return true;
			}

			// a or b is zero, or both are extremely close to it.
			// relative error is less meaningful here
			if (a == 0.0f || b == 0.0f || diff < FLOAT_NORMAL) {
				return diff < (FLOAT_NORMAL * 0.00001f);
			}

			// use relative error
			return diff < Math.Min((absA + absB), float.MaxValue) * 0.00001f;
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator
		}

		/**
		 * Perform a robust approximate equality test between two 64 bit
		 * floating point numbers.
		 */
		public static bool IsEqual(this double a, double b) {
#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
			var absA = Math.Abs(a);
			var absB = Math.Abs(b);
			var diff = Math.Abs(a - b);

			// Shortcut, handles infinities
			if (a == b) {
				return true;
			}

			// a or b is zero, or both are extremely close to it.
			// relative error is less meaningful here
			if (a == 0.0 || b == 0.0 || diff < DOUBLE_NORMAL) {
				return diff < (DOUBLE_NORMAL * 0.00000001);
			}

			// use relative error
			return diff < Math.Min((absA + absB), double.MaxValue) * 0.00000001;
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator
		}
	}
}
