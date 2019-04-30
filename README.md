<h3 align="center">
  <img src="Graphics/icon.png?raw=true" alt="BitStack Logo" width="600">
</h3>

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/577417c2e74242e290b1abeec1b89c2e)](https://app.codacy.com/app/DavidArayan/bit-stack?utm_source=github.com&utm_medium=referral&utm_content=DavidArayan/bit-stack&utm_campaign=Badge_Grade_Settings)
[![Twitter: @DavidArayan](https://img.shields.io/badge/contact-DavidArayan-blue.svg?style=flat)](https://twitter.com/DavidArayan)
[![Join the chat at https://gitter.im/ezyframeworks/bitstack](https://img.shields.io/badge/chat-gitter/bitstack-green.svg?style=flat)](https://gitter.im/ezyframeworks/bitstack)
[![License](https://img.shields.io/badge/license-MIT-orange.svg?style=flat)](LICENSE)

_BitStack_ when you need to manipulate bits but can't be bothered learning about it all. Easy of use, stability and open source.

***

#### Open Source Bit Manipulation Framework for the Unity3D Game Engine

* Uses extension methods for ease of use
* Unit [Tests](BitStack/Framework/Tests) written for all functionality, ensuring stability
* Supports signed and unsigned operations on byte, short, int and long
* Flexible and Documented API
* No external plugin dependencies, fully written in C#
* Updated for Unity3D 2018
* MIT Open Source [License](LICENSE)

#### Contributions and Bug Reports

* Contributions are always welcome and highly appreciated! please use Pull Request
* Bugs, Comments, General Enquiries and Feature Requests please use the Issue Tracker

***

#### Basic Usage Example

There are cases where an array of boolean values are required. The below example shows how an array of 64 boolean values can be replaced via a single unsigned long value.

```C#
// an array of 64 bool values. Depending on architecture a 
// bool can either be 8 bits, 16 bits or even a full 32 bits.
bool[] toggles = new bool[64];

// Set a few booleans as true in positions 4 and 17
toggles[4] = true;
toggles[17] = true;

// Access our boolean values
print(toggles[4]); // prints true
print(toggles[17]); // prints true
print(toggles[23]); // prints false
```

Using the BitStack extensions, above example can be replaced as follows.

```C#
// in here, a ulong is always 64 bits. We can use each bit 
// in place of a boolean toggle, saving space and array allocation
ulong toggles = 0;

// Set a few bits to 1/true in positions 4 and 17
toggles = toggles.SetBitAt(4);
toggles = toggles.SetBitAt(17);

// Access our boolean values
print(toggles.BitAt(4)); // prints 1
print(toggles.BitAt(17)); // prints 1
print(toggles.BitAt(23)); // prints 0

// If working with integers (1 or 0) is inconvenient, there is an option to
// return the boolean value as traditional true/false
print(toggles.BitAt(4).Bool()); // prints true
print(toggles.BitAt(17).Bool()); // prints true
print(toggles.BitAt(23).Bool()); // prints false
```

BitStack supports a number of binary operations on the following C# value types.

```C#
// both signed and unsigned 64 bit value types
ulong toggles64 = 0;
long toggles64 = 0

// both signed and unsigned 32 bit value types
uint toggles32 = 0;
int toggles32 = 0;

// both signed and unsigned 16 bit value types
ushort toggles16 = 0;
short toggles16 = 0;

// both signed and unsigned 8 bit value types
sbyte toggles8 = 0;
byte toggles8 = 0;
```

#### Basic Extension Methods

* _value.SetBitAt(int bitPosition)_ Sets the bit at the provided bit position to the ON/1 State. Example.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong value = 0;

// Sets the bit at position 5 to ON/1 State
value = value.SetBitAt(5);
```

* _value.UnsetBitAt(int bitPosition)_ Unset the bit at the provided bit position to the OFF/0 State. Example.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong value = 0;

// Sets the bit at position 5 to OFF/0 State
value = value.UnsetBitAt(5);
```

* _value.ToggleBitAt(int bitPosition)_ Toggles the bit at the provided bit position.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong val = 0;

// Sets the bit at position 5 to ON/1 State
val = val.ToggleBitAt(5);

// Sets the bit at position 5 to OFF/0 State
val = val.ToggleBitAt(5);

// Sets the bit at position 5 to ON/1 State again
val = val.ToggleBitAt(5);
```

* _value.BitAt(int bitPosition)_ Returns the current state of the bit at the provided bit position.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong val = 0;

// Sets the bit at position 5 to ON/1 State
val = val.SetBitAt(5);

// This will print the current state of the bit at position 5
print(val.BitAt(5)); // prints 1

// Sets the bit at position 5 to OFF/0 State
val = val.UnsetBitAt(5);

// This will print the current state of the bit at position 5
print(val.BitAt(5)); // prints 0
```

* _value.Bool()_ Returns true if the value is greater than 0, otherwise returns false. Can be used as a simple convenience function.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong val = 0;

val = val.SetBitAt(5);
print(val.BitAt(5).Bool()); // prints true

val = val.UnsetBitAt(5);
print(val.BitAt(5).Bool()); // prints false
```

* _value.PopCount()_ Returns the number of bits which have been set to the ON/1 State. The result can be used to derive how many bits are in the OFF/0 State.

```C#
// can be long, uint, int, ushort, short, sbyte or byte
ulong value = 0;

val = val.SetBitAt(5).SetBitAt(17).SetBitAt(23);
print(value.PopCount()); // prints 3

val = val.UnsetBitAt(5).UnsetBitAt(17).SetBitAt(23);
print(val.PopCount()); // prints 1
```

* _value.IsPowerOfTwo()_ Returns true if the provided value is actually a power of 2, otherwise returns false.

```C#
print(256.IsPowerOfTwo()) // prints true
print(127.IsPowerOfTwo()) // prints false
```

* _value.BitString()_ Returns the bit sequence of the provided value as a String. This is useful for debugging purposes or if visual observation of the bit sequence is required. The length of the String will vary depending on the bit length of the value. For example, a long value will return 64 character String whilst an int value will return 32 characters.

```C#
byte val = 0;

print(val.BitString()); // prints 00000000
```

#### Advanced Extension Methods

The advanced extension methods allows proper splitting/combining of value types into other value types whilst preserving the full bit sequence. These operations are useful when dealing with custom data types which need to be transformed for various reasons. 

The basic Split() methods will split values into smaller bits and Combine() will merge them back up. The Split method will return a Tuple with multiple values.

* _value.SplitIntoByte()_ Splits the provided value into it's byte representation. The number of bytes returned depends on the value.

```C#
int val = 42;

// this returns a tuple of (byte, byte, byte, byte)
var byteSplit = val.SplitIntoByte();

// inidividual bytes can be accessed as follows
byteSplit.Item1; // first byte
byteSplit.Item2; // seconds byte
byteSplit.Item3; // third byte
byteSplit.Item4; // fourth byte

// additionally the split bytes can be re-combined back into it's original value
int combinedValue = byteSplit.CombineToInt();

print(combinedValue); // prints 42
```

The following _Split_ options are available for the various value types

* long and ulong (64 bits)

```C#
long val = 42; // long or ulong

val.SplitIntoByte(); 		// ((byte, byte, byte, byte), (byte, byte, byte, byte))
val.SplitIntoSByte(); 		// ((sbyte, sbyte, sbyte, sbyte), (sbyte, sbyte, sbyte, sbyte))
val.SplitIntoShort();		// (short, short, short, short)
val.SplitIntoUShort();		// (ushort, ushort, ushort, ushort)
val.SplitIntoInt();			// (int, int)
val.SplitIntoUInt();		// (uint, uint)
```

* int and uint (32 bits)

```C#
int val = 42; // int or uint

val.SplitIntoByte(); 		// (byte, byte, byte, byte)
val.SplitIntoSByte(); 		// (sbyte, sbyte, sbyte, sbyte)
val.SplitIntoShort();		// (short, short)
val.SplitIntoUShort();		// (ushort, ushort)
```

* short and ushort (16 bits)

```C#
short val = 42; // short or ushort

val.SplitIntoByte(); 		// (byte, byte)
val.SplitIntoSByte(); 		// (sbyte, sbyte)
```

The basic Combine() methods will reverse the Split() operation.

```C#
// psuedo-code for a tuple. The available operations will depend on the type/length of the tuple
var tuple = ...;

long lValue = tuple.CombineToLong();
ulong ulValue = tuple.CombineToULong();
int iValue = tuple.CombineToInt();
uint uiValue = tuple.CombineToUInt();
short sValue = tuple.CombineToShort();
ushort usValue = tuple.CombineToUShort();
```

The generic Tuple types can also be combined to/from arrays. This allows storing and/or shuffling the results if required.

```C#
int val = 42;

// generate an array from the split bytes of the integer value 42
byte[] values = val.SplitIntoByte().ToArray();

values[0]; // first byte
values[1]; // seconds byte
values[2]; // third byte
values[3]; // fourth byte

// combine the array back into the original 4 component tuple and finally back to the integer
int originalVal = values.ToTuple4().CombineToInt();

print(originalVal); // prints 42
```
