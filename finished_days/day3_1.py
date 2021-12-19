
f = open("input_day3.txt", "r")

gamma = 0
epsilon = 0
count = 0
array_not_initialized = True
array = []

for line in f:
	line = line.split()
	i = 0
	count += 1
	for number in line:
		if array_not_initialized:
			for i in range(0, len(str(number))):
				array.append(0)
			array_not_initialized = False
			i = 0
		for i in range(0, len(str(number))):
			if number[i] == '0':
				array[i] += 1
			i += 1
for number in array:
	if number > count / 2:
		gamma = gamma * 2 + 1
		epsilon = epsilon * 2
	else:
		gamma = gamma * 2
		epsilon = epsilon * 2 + 1
print(gamma, epsilon, gamma * epsilon)


