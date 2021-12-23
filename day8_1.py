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

def count_unique_segments(digits):
	count = 0
	for line in digits:
		for digit in line:
			dlen = len(digit)
			if dlen is 2 or dlen is 3 or dlen is 4 or dlen is 7:
				count += 1
	print(count)

def main():
	# read_input_data()
	signals, digits = read_input_data()
	unique_segments = count_unique_segments(digits)
	print(unique_segments)

if __name__ == "__main__":
	main()