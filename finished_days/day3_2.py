

f = open("input_day3.txt", "r")

def remove_wrong_numbers(i, digit, array):
	array = [number for number in array if not number[i] == digit]
	return array

def bin_to_int(string):
	x = 0
	for char in string:
		if (char == '0'):
			x *= 2
		else:
			x = x * 2 + 1
	return x

array = []

for line in f:
	line = line.split()
	for number in line:
		array.append(number)
array_scrubber_rating = list(array)

i = 0
oxygen_rating = 0
scrubber_rating = 0
oxy = ''
scrub = ''
line_len = len(number)
for i in range(0, line_len):
	zero_count = 0
	for number in array:
		if number[i] == '0':
			zero_count += 1
	if zero_count > len(array) / 2:
		array = remove_wrong_numbers(i, '1', array)
	else:
		array = remove_wrong_numbers(i, '0', array)
	if len(array) == 1:
		oxy = array[0]

for i in range(0, line_len):
	zero_count = 0
	for number in array_scrubber_rating:
		if number[i] == '0':
			zero_count += 1
	if zero_count > len(array_scrubber_rating) / 2:
		array_scrubber_rating = remove_wrong_numbers(i, '0', array_scrubber_rating)
	else:
		array_scrubber_rating = remove_wrong_numbers(i, '1', array_scrubber_rating)
	if len(array_scrubber_rating) == 1:
		scrub = array_scrubber_rating[0]

print(bin_to_int(oxy), bin_to_int(scrub), bin_to_int(oxy) * bin_to_int(scrub))
