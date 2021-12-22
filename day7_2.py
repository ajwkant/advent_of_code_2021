import re

def read_input_data():
	f = open("input_day7.txt", "r")
	for line in f:
		line = re.split(',|\n', line)
		data = [int(i) for i in line]
	return data

def calc_cost(distance):
	cost = 0
	incremental_cost = 1
	for _ in range(distance):
		cost += incremental_cost
		incremental_cost += 1
	return cost


def find_total_cost(data, pos):
	total = 0
	for number in data:
		distance = abs(number - pos)
		total += calc_cost(distance)
	return total

def find_cheapest_position(data):
	lowest_cost = find_total_cost(data, min(data))
	cheapest_pos = min(data)
	for x in range(min(data) + 1, max(data) + 1):
		cost = find_total_cost(data, x)
		if cost < lowest_cost:
			lowest_cost = cost
			cheapest_pos = x
	return lowest_cost, cheapest_pos

def main():
	data = read_input_data()
	cost, cheapest = find_cheapest_position(data)
	print(cost, cheapest)

if __name__ == "__main__":
	main()