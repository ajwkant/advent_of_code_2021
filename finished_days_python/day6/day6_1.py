import re
import itertools

def read_input_data():
	f = open("input_day6.txt", "r")
	for line in f:
		line = re.split(',|\n', line)
		data = [int(i) for i in line]
	return data

def proceed_x_days(data, amount_of_days):

	days = [0] * 9
	for i in range(len(data)):
		days[data[i]] += 1

	schedule = range(7)
	new_entries = [0, 0]
	cycled_schedule = itertools.cycle(schedule)
	x = 0

	for day in range(amount_of_days + 1):

		previous = x

		temp = days[x]
		days[previous] += new_entries[0]
		new_entries[0] = new_entries[1]
		new_entries[1] = temp

		x = next(cycled_schedule)

	total = 0
	for each in days:
		total += each
	for new in new_entries:
		total += new

	print("\nTotal:")
	print(total)


def main():
	data = read_input_data()
	proceed_x_days(data, 256)

if __name__ == "__main__":
	main()