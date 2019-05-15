using BitStack;
using NUnit.Framework;
using UnityEngine;

public static class ValueLinearKeyTests {

    [Test]
    public static void Test_LinearKeyEncodeZero() {
        Vector3 test = new Vector3(0, 0, 0);
        LinearKey3 linearKey = new LinearKey3(test);

        Debug.Assert(linearKey.key == 0, "Expected Test(" + test + ") to be Equal to Key(" + linearKey.key + ")");
    }

    [Test]
    public static void Test_LinearKeyEncodeDecode() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    LinearKey3 linearKey = new LinearKey3(test);
                    Vector3 decode = linearKey.Value;

                    Debug.Assert(test == decode, "Expected Test(" + test + ") to be Equal to Key(" + decode + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncX() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x + 1, y, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncX();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncXY() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x + 1, y + 1, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncXY();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncXZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x + 1, y, z + 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncXZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncYZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y + 1, z + 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncYZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncXYZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x + 1, y + 1, z + 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncXYZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecX() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x - 1, y, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecX();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncY() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y + 1, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncY();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecY() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y - 1, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecY();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeIncZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y, z + 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.IncZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y, z - 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecXY() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x - 1, y - 1, z);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecXY();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecXZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x - 1, y, z - 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecXZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecYZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x, y - 1, z - 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecYZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }

    [Test]
    public static void Test_LinearKeyEncodeDecodeDecXYZ() {
        for (int x = 4; x < 9; x++) {
            for (int y = 3; y < 10; y++) {
                for (int z = 2; z < 11; z++) {
                    Vector3 test = new Vector3(x, y, z);
                    Vector3 testInc = new Vector3(x - 1, y - 1, z - 1);

                    LinearKey3 linearKey = new LinearKey3(test);
                    LinearKey3 testKey = linearKey.DecXYZ();
                    Vector3 decode = testKey.Value;

                    Debug.Assert(testInc == decode, "Expected Test(" + testInc + ") to be Equal to Key(" + decode + ") via Original(" + test + ")");
                }
            }
        }
    }
}