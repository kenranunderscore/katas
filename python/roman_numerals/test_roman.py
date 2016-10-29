import pytest
import roman


single_digit_values = (
    (1, 'I'),
    (2, 'II'),
    (3, 'III'),
    (4, 'IV'),
    (5, 'V'),
    (6, 'VI'),
    (7, 'VII'),
    (8, 'VIII'),
    (9, 'IX')
)


extended_known_values = (
    (1, 'I'),
    (2, 'II'),
    (3, 'III'),
    (4, 'IV'),
    (5, 'V'),
    (6, 'VI'),
    (7, 'VII'),
    (8, 'VIII'),
    (9, 'IX'),
    (10, 'X'),
    (50, 'L'),
    (100, 'C'),
    (500, 'D'),
    (1000, 'M'),
    (31, 'XXXI'),
    (148, 'CXLVIII'),
    (294, 'CCXCIV'),
    (312, 'CCCXII'),
    (421, 'CDXXI'),
    (528, 'DXXVIII'),
    (621, 'DCXXI'),
    (782, 'DCCLXXXII'),
    (870, 'DCCCLXX'),
    (941, 'CMXLI'),
    (1043, 'MXLIII'),
    (1110, 'MCX'),
    (1226, 'MCCXXVI'),
    (1301, 'MCCCI'),
    (1485, 'MCDLXXXV'),
    (1509, 'MDIX'),
    (1607, 'MDCVII'),
    (1754, 'MDCCLIV'),
    (1832, 'MDCCCXXXII'),
    (1993, 'MCMXCIII'),
    (2074, 'MMLXXIV'),
    (2152, 'MMCLII'),
    (2212, 'MMCCXII'),
    (2343, 'MMCCCXLIII'),
    (2499, 'MMCDXCIX'),
    (2574, 'MMDLXXIV'),
    (2646, 'MMDCXLVI'),
    (2723, 'MMDCCXXIII'),
    (2892, 'MMDCCCXCII'),
    (2975, 'MMCMLXXV'),
    (3051, 'MMMLI'),
    (3185, 'MMMCLXXXV'),
    (3250, 'MMMCCL'),
    (3313, 'MMMCCCXIII'),
    (3408, 'MMMCDVIII'),
    (3501, 'MMMDI'),
    (3610, 'MMMDCX'),
    (3743, 'MMMDCCXLIII'),
    (3844, 'MMMDCCCXLIV'),
    (3888, 'MMMDCCCLXXXVIII'),
    (3940, 'MMMCMXL'),
    (3999, 'MMMCMXCIX')
)


def test_single_arabic_digits_are_converted_correctly():
    """Ensures that integers between 1 and 9 are converted
       correctly to their Roman numeral counterparts.
    """
    for digit, numeral in single_digit_values:
        assert roman.to_roman(digit) == numeral


def test_negative_number_raises_exception():
    """Ensures that negative integers raise an error
       that indicates that the value was out of Roman
       numeral range.
    """
    with pytest.raises(roman.NumberOutOfRangeError):
        roman.to_roman(-2)


def test_zero_raises_exception():
    """Ensures that 0 raises an 'out of range' error."""
    with pytest.raises(roman.NumberOutOfRangeError):
        roman.to_roman(0)


def test_number_greater_than_3999_raises_exception():
    """Ensures that a value greater than 3999
       raises an 'out of range' error.
    """
    with pytest.raises(roman.NumberOutOfRangeError):
        roman.to_roman(4000)


def test_numbers_are_converted_correctly():
    """Ensures that some given test integers are
       converted correctly to Roman numerals.
    """
    for digit, numeral in extended_known_values:
        assert roman.to_roman(digit) == numeral


def test_too_many_repeated_numeral_letters():
    """Ensures that Roman numeral letters which are
       repeated too many times are rejected.
    """
    for numeral in ('MMMM', 'DD', 'CCCC', 'LL', 'XXXX', 'VV', 'IIII'):
        with pytest.raises(roman.InvalidRomanNumeralError):
            roman.from_roman(numeral)


def test_numerals_are_converted_correctly():
    """Ensures that some given test numerals are
       converted correctly to integers.
    """
    for digit, numeral in extended_known_values:
        assert roman.from_roman(numeral) == digit


def test_sanity_check_to_then_from_roman():
    """Ensures that from_roman is a left inverse
       for to_roman.
    """
    for i in range(1, 3999):
        assert i == roman.from_roman(roman.to_roman(i))
