from collections import OrderedDict
import re


class NumberOutOfRangeError(Exception):
    """Is raised when an integer is lesser than 1 or greater than 3999."""
    pass


class InvalidRomanNumeralError(Exception):
    """Is raised when a Roman numeral is malformed."""
    pass


roman_numeral_validator = re.compile(
    '^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$',
    re.IGNORECASE
)


base_conversions = OrderedDict((
    (1000, 'M'),
    (900, 'CM'),
    (500, 'D'),
    (400, 'CD'),
    (100, 'C'),
    (90, 'XC'),
    (50, 'L'),
    (40, 'XL'),
    (10, 'X'),
    (9, 'IX'),
    (5, 'V'),
    (4, 'IV'),
    (1, 'I')
))


base_numerals = {v: k for k, v in base_conversions.items()}


def to_roman(arabic_number):
    """Converts a positive integer between 1 and 3999 to a Roman numeral."""
    if arabic_number < 0:
        raise NumberOutOfRangeError('negative values are not allowed')
    elif arabic_number == 0:
        raise NumberOutOfRangeError('zero is not allowed')
    elif arabic_number > 3999:
        raise NumberOutOfRangeError('number is too big')

    resulting_numeral = ''
    for key in base_conversions.keys():
        while arabic_number >= key:
            arabic_number -= key
            resulting_numeral += base_conversions[key]

    return resulting_numeral


def from_roman(roman_numeral):
    """Converts Roman numerals between 1 and 3999 to an integer."""
    if not roman_numeral_validator.match(roman_numeral):
        raise InvalidRomanNumeralError('invalid roman numeral')

    numbers = [base_numerals[numeral] for numeral in roman_numeral]
    total = 0
    for current_n, next_n in zip(numbers, numbers[1:]):
        if current_n >= next_n:
            total += current_n
        else:
            total -= current_n

    return total + numbers[-1]
