using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly string[] _defaultDelimiters = {",", "\n"};
        private const string _customDelimiterPrefix = "//";
        private const char _customDelimiterSuffix = '\n';

        public int Add(string numbers)
        {
            var parsedNumbers = ExtractNumbers(EmptyIfNull(numbers))
                .Select(ParseNumber)
                .ToList();

            CheckForNegatives(parsedNumbers);

            return parsedNumbers.Sum();
        }

        private IEnumerable<string> ExtractNumbers(string numbers)
        {
            return GetNumberSection(numbers)
                .Split(GetDelimiters(numbers), StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] GetDelimiters(string numbers)
        {
            var customDelimiters = GetDelimiterSection(numbers)
                .Split(new []{"]", "["}, StringSplitOptions.RemoveEmptyEntries);

            return _defaultDelimiters.Concat(customDelimiters)
                .ToArray();
        }

        private string GetDelimiterSection(string numbers)
        {
            if (HasCustomDelimiter(numbers))
            {
                var start = _customDelimiterPrefix.Length;
                var end = numbers.IndexOf(_customDelimiterSuffix, StringComparison.Ordinal);

                return numbers.Substring(start, end - start);
            }

            return string.Empty;
        }

        private string GetNumberSection(string numbers)
        {
            if (HasCustomDelimiter(numbers))
            {
                var start = numbers.IndexOf(_customDelimiterSuffix, StringComparison.Ordinal);

                return numbers.Substring(start, numbers.Length - start);
            }

            return numbers;
        }

        private bool HasCustomDelimiter(string numbers)
        {
            return numbers.StartsWith(_customDelimiterPrefix);
        }

        private string EmptyIfNull(string numbers)
        {
            return numbers ?? "";
        }

        private int ParseNumber(string numberAsText)
        {
            if (string.IsNullOrWhiteSpace(numberAsText))
            {
                return 0;
            }

            return int.Parse(numberAsText);
        }

        private void CheckForNegatives(IEnumerable<int> numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception($"negatives not allowed {string.Join(", ", negativeNumbers)}");
            }
        }
    }
}