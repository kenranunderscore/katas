import re


class NumberOutOfRangeError(Exception):
    pass


class InvalidRomanNumeralError(Exception):
    pass


roman_numeral_validator = re.compile(
    '^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$',
    re.IGNORECASE
)


base_conversions = {
    1: 'I',
    4: 'IV',
    5: 'V',
    9: 'IX',
    10: 'X',
    40: 'XL',
    50: 'L',
    90: 'XC',
    100: 'C',
    400: 'CD',
    500: 'D',
    900: 'CM',
    1000: 'M'
}


base_numbers = sorted(base_conversions.keys(), reverse=True)


def to_roman(arabic_number):
    if arabic_number < 0:
        raise NumberOutOfRangeError('negative values are not allowed')
    elif arabic_number == 0:
        raise NumberOutOfRangeError('zero is not allowed')
    elif arabic_number > 3999:
        raise NumberOutOfRangeError('number is too big')

    resulting_numeral = ''
    for num in base_numbers:
        while arabic_number >= num:
            arabic_number -= num
            resulting_numeral += base_conversions[num]

    return resulting_numeral


def from_roman(roman_numeral):
    if not roman_numeral_validator.match(roman_numeral):
        raise InvalidRomanNumeralError('invalid roman numeral')
