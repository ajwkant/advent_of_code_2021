
import re

f = open("input_day5.txt", "r")

data = []
for line in f:
	line = re.split(',| -> | |\n', line)
	line = filter(None, line)
	# print(line)
	data.append(line)

max_x = 0
max_y = 0
for line in data:
	if int(line[0]) > max_x:
		max_x = int(line[0])
	if int(line[2]) > max_x:
		max_x = int(line[2])
	if int(line[1]) > max_y:
		max_y = int(line[1])
	if int(line[3]) > max_y:
		max_y = int(line[3])





























# import re

# def check_if_bingo(boards):
# 	for board in boards:
# 		for line in board:
# 			if all(number == 'X' for number in line):
# 				return board
# 		j = 0
# 		for j in range(0, 5):
# 			if all(line[j] == 'X' for line in board):
# 				return board
# 	return "nothing"

# def fill_in_boards(number, boards):
# 	for board in boards:
# 		for line in board:
# 			i = 0
# 			for i in range(0, len(line)):
# 				if line[i] == number:
# 					line[i] = 'X'



# f = open("input_day4.txt", "r")

# first_line = True
# line_count = 0
# boards = []
# for line in f:
# 	if first_line:
# 		number_list = re.split(',|\n', line)
# 		number_list.pop()
# 		first_line = False
# 	elif len(line) > 1:
# 		if line_count == 0:
# 			new_board = []
# 		line = line.split()
# 		new_board.append(line)
# 		line_count += 1
# 		if (line_count == 5):
# 			boards.append(new_board)
# 			line_count = 0

# for number in number_list:
# 	winning_board = boards[0]
# 	fill_in_boards(number, boards)
# 	# for board in boards:
# 	# 	print("\n")
# 	# 	for line in board:
# 	# 		print(line)
# 	board = check_if_bingo(boards)
# 	while (board is not "nothing"):
# 		boards.remove(board)
# 		board = check_if_bingo(boards)

# 	# print("\n\n" + str(number) + "\n\n")
# 	# for board in boards:
# 	# 	print("\n")
# 	# 	for line in board:
# 	# 		print(line)

# 	if len(boards) > 0:
# 		continue

# 	# if winning_board == "nothing":
# 	# 	continue
# 	winning_number = number
# 	break


# sum = 0
# for line in winning_board:
# 	for number in line:
# 		if number != 'X':
# 			sum += int(number)
# print(sum, int(winning_number))
# print(sum * int(winning_number))






















# def remove_wrong_numbers(i, digit, array):
# 	array = [number for number in array if not number[i] == digit]
# 	return array

# def bin_to_int(string):
# 	x = 0
# 	for char in string:
# 		if (char == '0'):
# 			x *= 2
# 		else:
# 			x = x * 2 + 1
# 	return x

# array = []

# for line in f:
# 	line = line.split()
# 	for number in line:
# 		array.append(number)
# array_scrubber_rating = list(array)

# i = 0
# oxygen_rating = 0
# scrubber_rating = 0
# oxy = ''
# scrub = ''
# line_len = len(number)
# for i in range(0, line_len):
# 	zero_count = 0
# 	for number in array:
# 		if number[i] == '0':
# 			zero_count += 1
# 	if zero_count > len(array) / 2:
# 		array = remove_wrong_numbers(i, '1', array)
# 	else:
# 		array = remove_wrong_numbers(i, '0', array)
# 	if len(array) == 1:
# 		oxy = array[0]

# for i in range(0, line_len):
# 	zero_count = 0
# 	for number in array_scrubber_rating:
# 		if number[i] == '0':
# 			zero_count += 1
# 	if zero_count > len(array_scrubber_rating) / 2:
# 		array_scrubber_rating = remove_wrong_numbers(i, '0', array_scrubber_rating)
# 	else:
# 		array_scrubber_rating = remove_wrong_numbers(i, '1', array_scrubber_rating)
# 	if len(array_scrubber_rating) == 1:
# 		scrub = array_scrubber_rating[0]

# print(bin_to_int(oxy), bin_to_int(scrub), bin_to_int(oxy) * bin_to_int(scrub))
