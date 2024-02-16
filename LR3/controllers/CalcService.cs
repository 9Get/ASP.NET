namespace LR3.controllers
{
    public class CalcService
    {
        public T Add<T>(params T[] numbers) where T : IConvertible
        {
            if (typeof(T) == typeof(string))
            {
                throw new ArgumentException("Cannot perform addition on strings.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("At least one number must be provided.");
            }

			dynamic res = numbers[0];

			for (int i = 1; i < numbers.Length; i++)
			{
				res += numbers[i];
			}

			return res;
        }

        public T Substract<T>(params T[] numbers) where T : IConvertible
        {
            if (typeof(T) == typeof(string))
            {
                throw new ArgumentException("Cannot perform substraction on strings.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("At least one number must be provided.");
            }

            dynamic res = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                res -= numbers[i];
            }

            return res;
        }

        public T Product<T>(params T[] numbers) where T : IConvertible
        {
            if (typeof(T) == typeof(string))
            {
                throw new ArgumentException("Cannot perform multiplication on strings.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("At least one number must be provided.");
            }

            dynamic res = numbers[0];

			for (int i = 1; i < numbers.Length; i++)
			{
				res *= numbers[i];
			}

			return res;
        }

        public T Divide<T>(params T[] numbers) where T : IConvertible
        {
            if (typeof(T) == typeof(string))
            {
                throw new ArgumentException("Cannot perform division on strings.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("At least one number must be provided.");
            }

            dynamic res = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i].ToDouble(null) == 0)
                {
					throw new DivideByZeroException("Cannot divide by zero.");
                }

                res /= numbers[i];
            }

            return res;
        }
    }
}
