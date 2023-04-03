namespace Dealership
{
    using System;
    using System.Text.RegularExpressions;
    using Dealership.Exceptions;

    public static class Validator
    {
        public const string InvalidMakeError = "Make must be between {0} and {1} characters long!";
        public const string InvalidModelError = "Model must be between {0} and {1} characters long!";
        public const string InvalidPriceError = "Price must be between {0} and {1}!";
        public const string InvalidCapacityError = "Weight capacity must be between {0} and {1}!";
        public const string InvalidCategoryError = "Category must be between {0} and {1} characters long!";
        public const string InvalidSeatsError = "Seats must be between {0} and {1}!";
        public const string InvalidCommentError = "Content must be between {0} and {1} characters long!";


        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidMakeError, min, max));
            }
        }

        public static void ValidateIntRangeWeightCapacity(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidCapacityError, min, max));
            }
        }
        public static void ValidateIntRangeCategory(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidCategoryError, min, max));
            }
        }

        public static void ValidateIntRangeSeats(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidSeatsError, min, max));
            }
        }
        public static void ValidateIntRangeComment(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidSeatsError, min, max));
            }
        }

        public static void ValidateDecimalRange(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new InvalidUserInputException(string.Format(InvalidPriceError, min, max));
            }
        }

        public static void ValidateSymbols(string value, string pattern, string message)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(value))
            {
                throw new ArgumentException(message);
            }
        }

        
    }
}
