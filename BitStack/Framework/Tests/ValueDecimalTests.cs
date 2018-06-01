using UnityEngine;
using NUnit.Framework;
using BitStack;

/**
 * Comparison of Float (32 bit) and Double (64 bit) values is often tricky due
 * to precision loss. These Unit tests will execute tolerance tests to ensure that
 * comparison operations work properly.
 */
public class ValueDecimalTests {
	static readonly float FLOAT_SMALL_POSITIVE = float.Epsilon;
	static readonly float FLOAT_SMALL_NEGATIVE = -float.Epsilon;
	static readonly float FLOAT_ZERO;

	static readonly double DOUBLE_SMALL_POSITIVE = double.Epsilon;
	static readonly double DOUBLE_SMALL_NEGATIVE = -double.Epsilon;
	static readonly double DOUBLE_ZERO;

	[Test]
	public void Test_FloatEqualTolerance() {
		var test = 0.0f;

		Debug.Assert(test.IsEqual(FLOAT_ZERO),
					 "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_ZERO + ")");

		Debug.Assert(test.IsEqual(FLOAT_SMALL_POSITIVE),
					 "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_SMALL_POSITIVE + ")");

		Debug.Assert(test.IsEqual(FLOAT_SMALL_NEGATIVE),
					 "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_SMALL_NEGATIVE + ")");
	}

	[Test]
	public void Test_FloatUnequalTolerance() {
		var test = 0.000001f;

		Debug.Assert(!test.IsEqual(FLOAT_ZERO),
					 "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_ZERO + ")");

		Debug.Assert(!test.IsEqual(FLOAT_SMALL_POSITIVE),
					 "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_SMALL_POSITIVE + ")");

		Debug.Assert(!test.IsEqual(FLOAT_SMALL_NEGATIVE),
					 "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_SMALL_NEGATIVE + ")");
	}

	[Test]
	public void Test_DoubleEqualTolerance() {
		var test = 0.0;

		Debug.Assert(test.IsEqual(DOUBLE_ZERO),
					 "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_ZERO + ")");

		Debug.Assert(test.IsEqual(DOUBLE_SMALL_POSITIVE),
					 "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_SMALL_POSITIVE + ")");

		Debug.Assert(test.IsEqual(DOUBLE_SMALL_NEGATIVE),
					 "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_SMALL_NEGATIVE + ")");
	}

	[Test]
	public void Test_DoubleUnequalTolerance() {
		var test = 0.0000001;

		Debug.Assert(!test.IsEqual(DOUBLE_ZERO),
					 "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_ZERO + ")");

		Debug.Assert(!test.IsEqual(DOUBLE_SMALL_POSITIVE),
					 "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_SMALL_POSITIVE + ")");

		Debug.Assert(!test.IsEqual(DOUBLE_SMALL_NEGATIVE),
					 "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_SMALL_NEGATIVE + ")");
	}
}
