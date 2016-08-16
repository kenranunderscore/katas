from collections import OrderedDict
import re


class NumberOutOfRangeError(Exception):
    pass


class InvalidRomanNumeralError(Exception):
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


base_numbers = sorted(base_conversions.keys(), reverse=True)


def to_roman(arabic_number):
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
    if not roman_numeral_validator.match(roman_numeral):
        raise InvalidRomanNumeralError('invalid roman numeral')

    resulting_number = 0
    i = 0
    while i < len(roman_numeral):
        current_letter = roman_numeral[i]

        if i + 1 < len(roman_numeral):
            potential_base_numeral = current_letter + roman_numeral[i + 1]
            if potential_base_numeral in base_numerals:
                resulting_number += base_numerals[potential_base_numeral]
                i += 2
                continue

        resulting_number += base_numerals[roman_numeral[i]]
        i += 1

    return resulting_number
