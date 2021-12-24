import re

def read_input_data():
	f = open("input_day8.txt", "r")
	signals = []
	digits = []
	for line in f:
		line = line.split(' | ')
		signal = line[0].split(' ')
		signals.append(signal)
		digit = re.split(' |\n', line[1])
		digit = filter(None, digit)
		digits.append(digit)
	return signals, digits

def subtract_string(string1, string2):
	new = string1
	for char in string2:
		new = new.replace(char, '')
	return new

def find_known_letters(letters, signal):
	for string in signal:
		dlen = len(string)
		if dlen is 2:
			letters[1] = string
		if dlen is 3:
			letters[7] = string
		if dlen is 4:
			letters[4] = string
		if dlen is 7:
			letters[8] = string

def it_is_zero(number, letters):
	number = set(number)
	one = set(letters[1])
	intersection = one.intersection(number)
	if intersection == one:
		return True
	return False

def it_is_two(number, letters):
	eight = set(letters[8])
	nine = set(letters[9])
	lamp_four = subtract_string(letters[8], letters[9])
	lamp_four_set = set(lamp_four)
	number_set = set(number)
	intersection = lamp_four_set.intersection(number_set)
	if intersection == lamp_four_set:
		return True
	return False

def it_is_three(number, letters):
	one = set(letters[1])
	three = set(number)
	intersection = one.intersection(three)
	if intersection == one:
		return True
	return False

def it_is_nine(number, letters, lamps):
	left_after_sub = subtract_string(letters[8], letters[7])
	left_after_sub = subtract_string(left_after_sub, letters[4])
	left = set(left_after_sub)
	number_set = set(number)
	intersection = left.intersection(number_set)
	if intersection != left:
		lamps[4] = intersection.pop()
		lamps[6] = subtract_string(left.pop(), lamps[4])
		return True
	return False

def find_all_letters(letters, signal, lamps):
	could_be_two = []
	for number in signal:
		if len(number) == 5 and it_is_three(number, letters):
			letters[3] = number
		elif len(number) == 6 and it_is_nine(number, letters, lamps):
			letters[9] = number
		elif len(number) == 5:
			could_be_two.append(number)
		elif len(number) == 6 and it_is_zero(number, letters):
			letters[0] = number
		elif len(number) == 6:
			letters[6] = number
	for number in could_be_two:
		if it_is_two(number, letters):
			letters[2] = number
		else:
			letters[5] = number

def decipher_digits(letters, digits):
	total = 0
	for digit in digits:
		digit_set = set(digit)
		for i in range(len(letters)):
			number_set = set(letters[i])
			if number_set == digit_set:
				total = total * 10 + i
				break
	return total


def calculate_digit_value(signal, digits):
	letters = [ '' for _ in range(10)]
	lamps = [[0] for _ in range(7)]
	find_known_letters(letters, signal)
	find_all_letters(letters, signal, lamps)
	digit_value = decipher_digits(letters, digits)
	return digit_value

def main():
	signals, digits = read_input_data()
	total = 0
	i = 0
	for i in range(len(signals)):
		total += calculate_digit_value(signals[i], digits[i])
	print(total)

if __name__ == "__main__":
	main()