from __future__ import print_function
import os
import time
import re
import itertools
import io

# найти слово в словаре
def parse(word, found):
	with io.open('dict.txt') as file:
		for line in file:
			if str(word + " ") in line:
				if line.lstrip(" *").startswith(str(word + " ")):
					line = line.lstrip(" *")
					word = line[:line.find(" | " + line[0])]
					found = True
	return word, found

# если есть число
def check_shape(word, found):
	try:
		int(word)
		found = True
		tags = ['ЧИСЛО', 'цел']
		return tags, found
	except ValueError:
		try:
			float(word.replace(',', '.'))
			found = True
			tags = ['ЧИСЛО', 'вещ']
			return tags, found
		except ValueError:
			pass
	return word, found


text = "Этот фильм точно интересный 4"
text = text.replace(u"ё", u"е").lower()
sentences = []
words = []
symbols = ' ,:@._()/'

for i in symbols:
	text = text.replace(str(i), ',')
words = text.split(',')
while 1:
	try:
		words.remove('')
	except ValueError:
		break

tag = ''


print(words)

for i in range(len(words)):
	found = False
	words[i], found = parse(words[i], found)
	if not found:
		words[i], found = check_shape(words[i], found)






print(words)











