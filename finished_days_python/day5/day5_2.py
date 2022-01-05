import re

def read_input_data():
	f = open("input_day5.txt", "r")
	data = []
	for line in f:
		line = re.split(',| -> | |\n', line)
		line = filter(None, line)
		new_line = [int(i) for i in line]
		data.append(new_line)
	return data

def find_max(data):
	max_x = 0
	max_y = 0
	for line in data:
		if line[0] > max_x:
			max_x = line[0]
		if line[2] > max_x:
			max_x = line[2]
		if line[1] > max_y:
			max_y = line[1]
		if line[3] > max_y:
			max_y = line[3]
	return (max_x + 1, max_y + 1)

def create_map(max_x, max_y):
	data_map = [[0] * max_x for _ in range(max_y)]
	return data_map

def is_diagonal(line):
	dx = abs(line[0] - line[2])
	dy = abs(line[1] - line[3])
	return dx == dy


def fill_in_map(data_map, data, max_x, max_y):
	for line in data:
		xlen = line[2] - line[0]
		ylen = line[3] - line[1]

		step = 1
		if xlen is 0:
			if ylen < 0:
				step = -1

			for x in range(line[1], line[3] + step, step):
				data_map[x][line[0]] += 1
		elif ylen is 0:
			if xlen < 0:
				step = -1

			for i in range(line[0], line[2] + step, step):
				data_map[line[1]][i] += 1
		elif is_diagonal(line):
			stepx, stepy = 1, 1
			if xlen < 0:
				stepx = -1
			if ylen < 0:
				stepy = -1
			for x, y in zip(range(line[0], line[2] + stepx, stepx), range(line[1], line[3] + stepy, stepy)):
				data_map[y][x] += 1


def count_multiple_overlaps(data_map):
	count = 0
	for line in data_map:
		for number in line:
			if number > 1:
				count += 1
	return count


def main():
	data = read_input_data()
	max_x, max_y = find_max(data)
	data_map = create_map(max_x, max_y)
	fill_in_map(data_map, data, max_x, max_y)
	count = count_multiple_overlaps(data_map)
	print(count)

if __name__ == "__main__":
	main()
