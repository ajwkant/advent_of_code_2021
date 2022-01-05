

f = open("input_day1.txt", "r")
first = True
second = True
count = 0
a_is_set = False
for line in f:
	line = line.split()
	for number in line:
		if not first:
			if not second:
				B = int(number) + middle + oldest
				if (a_is_set and B > A):
					count += 1
				A = B
				a_is_set = True
			second = False
		first = False
		if not second:
			oldest = middle
		middle = int(number)
print(count)
