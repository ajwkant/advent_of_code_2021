

f = open("input_day2.txt", "r")


x = 0
y = 0

for line in f:
	line = line.split()
	if line[0] == "up":
		y -= int(line[1])
	elif line[0] == "down":
		y += int(line[1])
	elif line[0] == "forward":
		x += int(line[1])
print(x, y, x * y)


