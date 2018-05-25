using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using BitStack;

/**
 * Comparison of Float (32 bit) and Double (64 bit) values is often tricky due
 * to precision loss. These Unit tests will execute tolerance tests to ensure that
 * comparison operations work properly.
 */
public class ValueDecimalTests {
	private static readonly float FLOAT_SMALL_POSITIVE = float.Epsilon;
	private static readonly float FLOAT_SMALL_NEGATIVE = -float.Epsilon;
	private static readonly float FLOAT_ZERO = 0.0f;
    
	private static readonly double DOUBLE_SMALL_POSITIVE = double.Epsilon;
    private static readonly double DOUBLE_SMALL_NEGATIVE = -double.Epsilon;
    private static readonly double DOUBLE_ZERO = 0.0;

	[Test]
    public void Test_FloatEqualTolerance() {
		float test = 0.0f;

		Debug.Assert(test.IsEqual(FLOAT_ZERO),
		             "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_ZERO + ")");

		Debug.Assert(test.IsEqual(FLOAT_SMALL_POSITIVE),
		             "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_SMALL_POSITIVE + ")");

		Debug.Assert(test.IsEqual(FLOAT_SMALL_NEGATIVE), 
		             "Expected Test(" + test + ") to be Equal to Float(" + FLOAT_SMALL_NEGATIVE + ")");
    }

	[Test]
    public void Test_FloatUnequalTolerance() {
        float test = 0.000001f;

        Debug.Assert(!test.IsEqual(FLOAT_ZERO),
		             "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_ZERO + ")");

        Debug.Assert(!test.IsEqual(FLOAT_SMALL_POSITIVE),
		             "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_SMALL_POSITIVE + ")");

        Debug.Assert(!test.IsEqual(FLOAT_SMALL_NEGATIVE),
		             "Expected Test(" + test + ") to be Unqual to Float(" + FLOAT_SMALL_NEGATIVE + ")");
    }

	[Test]
    public void Test_DoubleEqualTolerance() {
		double test = 0.0;

        Debug.Assert(test.IsEqual(DOUBLE_ZERO),
                     "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_ZERO + ")");

        Debug.Assert(test.IsEqual(DOUBLE_SMALL_POSITIVE),
		             "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_SMALL_POSITIVE + ")");

        Debug.Assert(test.IsEqual(DOUBLE_SMALL_NEGATIVE),
		             "Expected Test(" + test + ") to be Equal to Double(" + DOUBLE_SMALL_NEGATIVE + ")");
    }

	[Test]
    public void Test_DoubleUnequalTolerance() {
		double test = 0.0000001;

        Debug.Assert(!test.IsEqual(DOUBLE_ZERO),
		             "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_ZERO + ")");

        Debug.Assert(!test.IsEqual(DOUBLE_SMALL_POSITIVE),
		             "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_SMALL_POSITIVE + ")");

        Debug.Assert(!test.IsEqual(DOUBLE_SMALL_NEGATIVE),
		             "Expected Test(" + test + ") to be Unqual to Double(" + DOUBLE_SMALL_NEGATIVE + ")");
    }
}
