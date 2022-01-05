


f = open("input_day1.txt", "r")
count = 0
not_first = False
for line in f:
	line = line.split()
	for number in line:
		if not_first:
			if (int(number) > temp):
				count += 1
		not_first = True
		temp = int(number)
print(count)
