
namespace BitStack {

    /**
     * Provides Generic Extension Methods for the System.ValueTuple which is used
     * throughout the stack 
     */
	public static class ValueTupleGenericExtensions {
        
        /**
         * Convert the provided 8 value struct tuple into an array of 8 elements and return
         * The generated array
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T, T, T, T, T, T, T> tuple) 
			where T : struct
		{
			return tuple.ToArray(new T[8], 0);
		}

        /**
         * Convert the provided array into an 8 component tuple where each tuple value
         * is an index from the array starting from read position 0
         */
		public static System.ValueTuple<T, T, T, T, T, T, T, T> ToTuple8<T>(this T[] array) 
			where T : struct
		{
			return array.ToTuple8(0);
		}

        /**
         * Convert the provided array into an 8 component tuple where each tuple value
         * is an index from the array starting from read position readIndex
         */
		public static System.ValueTuple<T, T, T, T, T, T, T, T> ToTuple8<T>(this T[] array, int readIndex)
            where T : struct 
		{
			return new System.ValueTuple<T, T, T, T, T, T, T, T>(
				array[readIndex + 0],
				array[readIndex + 1],
				array[readIndex + 2],
				array[readIndex + 3],
				array[readIndex + 4],
				array[readIndex + 5],
				array[readIndex + 6],
				array[readIndex + 7]
			);
        }

		/**
         * Convert the provided 4 value struct tuple into an array of 4 elements and return
         * The generated array
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T, T, T> tuple) 
			where T : struct 
		{
            return tuple.ToArray(new T[4], 0);
        }

		/**
         * Convert the provided array into an 4 component tuple where each tuple value
         * is an index from the array starting from read position 0
         */
        public static System.ValueTuple<T, T, T, T> ToTuple4<T>(this T[] array)
            where T : struct 
		{
            return array.ToTuple4(0);
        }

        /**
         * Convert the provided array into an 4 component tuple where each tuple value
         * is an index from the array starting from read position readIndex
         */
        public static System.ValueTuple<T, T, T, T> ToTuple4<T>(this T[] array, int readIndex)
            where T : struct 
		{
            return new System.ValueTuple<T, T, T, T>(
                array[readIndex + 0],
                array[readIndex + 1],
                array[readIndex + 2],
                array[readIndex + 3]
            );
        }

		/**
         * Convert the provided 2 value struct tuple into an array of 2 elements and return
         * The generated array
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T> tuple) 
			where T : struct 
		{
            return tuple.ToArray(new T[2], 0);
        }

		/**
         * Convert the provided array into an 2 component tuple where each tuple value
         * is an index from the array starting from read position 0
         */
        public static System.ValueTuple<T, T> ToTuple2<T>(this T[] array)
            where T : struct 
		{
            return array.ToTuple2(0);
        }

        /**
         * Convert the provided array into an 4 component tuple where each tuple value
         * is an index from the array starting from read position readIndex
         */
        public static System.ValueTuple<T, T> ToTuple2<T>(this T[] array, int readIndex)
            where T : struct 
		{
            return new System.ValueTuple<T, T>(
                array[readIndex + 0],
                array[readIndex + 1]
            );
        }
        
		/**
         * Write the provided 8 value struct tuple into an existing array. Provide
         * the start position of the write operation. This function will write 8 values
         * from the start.
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T, T, T, T, T, T, T> tuple,
		                             T[] array, 
		                             int start) 
			where T : struct
		{
			array[start + 0] = tuple.Item1;
			array[start + 1] = tuple.Item2;
			array[start + 2] = tuple.Item3;
			array[start + 3] = tuple.Item4;
			array[start + 4] = tuple.Item5;
			array[start + 5] = tuple.Item6;
			array[start + 6] = tuple.Item7;
			array[start + 7] = tuple.Rest;

            return array;
        }

		/**
         * Write the provided 4 value struct tuple into an existing array. Provide
         * the start position of the write operation. This function will write 4 values
         * from the start.
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T, T, T> tuple,
		                          T[] array, 
		                          int start) 
			where T : struct
		{
            array[start + 0] = tuple.Item1;
            array[start + 1] = tuple.Item2;
            array[start + 2] = tuple.Item3;
			array[start + 3] = tuple.Item4;

            return array;
        }

		/**
         * Write the provided 2 value struct tuple into an existing array. Provide
         * the start position of the write operation. This function will write 2 values
         * from the start.
         */
		public static T[] ToArray<T>(this System.ValueTuple<T, T> tuple,
                                  T[] array,
		                          int start) 
			where T : struct
		{
            array[start + 0] = tuple.Item1;
            array[start + 1] = tuple.Item2;

            return array;
        }
    }
}
