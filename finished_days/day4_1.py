
import re

def check_if_bingo(boards):
	for board in boards:
		for line in board:
			if all(number == 'X' for number in line):
				return board
		j = 0
		for j in range(0, 5):
			if all(number[j] == 'X' for number in board):
				return board
	return "nothing"

def fill_in_boards(number, boards):
	for board in boards:
		for line in board:
			i = 0
			for i in range(0, len(line)):
				if line[i] == number:
					line[i] = 'X'



f = open("input_day4.txt", "r")

first_line = True
line_count = 0
boards = []
for line in f:
	if first_line:
		number_list = re.split(',|\n', line)
		number_list.pop()
		first_line = False
	elif len(line) > 1:
		if line_count == 0:
			new_board = []
		line = line.split()
		new_board.append(line)
		line_count += 1
		if (line_count == 5):
			boards.append(new_board)
			line_count = 0

for number in number_list:
	fill_in_boards(number, boards)
	for board in boards:
		print("\n")
		for line in board:
			print(line)
	winning_board = check_if_bingo(boards)
	if winning_board == "nothing":
		continue
	winning_number = number
	break


sum = 0
for line in winning_board:
	for number in line:
		if number != 'X':
			sum += int(number)
print(sum * int(winning_number))
