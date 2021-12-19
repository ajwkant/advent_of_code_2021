


f = open("input_day2.txt", "r")


x = 0
y = 0
aim = 0

for line in f:
	line = line.split()
	if line[0] == "up":
		aim -= int(line[1])
	elif line[0] == "down":
		aim += int(line[1])
	elif line[0] == "forward":
		y += aim * int(line[1])
		x += int(line[1])
print(x, y, aim, x * y)

