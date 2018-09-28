import json
import operator

raw_us_data_file = open('2009US.json')
raw_json_string = raw_us_data_file.read()
# For some strange reason, our CSV to JSON converter was adding some weird hidden chars at the 
# beginning of the files, and the number of hidden chars was different depending on the file...
# 2015US.json had 4, while the others only had 3... This line will remove them.
raw_json_string = raw_json_string[3:len(raw_json_string)]
print "First char: " + str(raw_json_string)[0] + " Last Char: " + str(raw_json_string)[len(raw_json_string)-1]
data = json.loads(raw_json_string)
raw_us_data_file.close()

state_totals = {}

for doc in data["docs"]:
	amount = 0
	if doc["UNIT_OF_MEASURE"] == "Pounds":
		amount = doc["TOTAL_RELEASES"]
	elif doc["UNIT_OF_MEASURE"] == "Grams":
		amount = doc["TOTAL_RELEASES"] * 0.00220462
	if doc["ST"] in state_totals and doc["CHEMICAL"] in state_totals[doc["ST"]]:
		state_totals[doc["ST"]][doc["CHEMICAL"]] += amount
	elif doc["ST"] in state_totals:
		state_totals[doc["ST"]][doc["CHEMICAL"]] = amount
	else:
		state_totals[doc["ST"]] = {}
		state_totals[doc["ST"]][doc["CHEMICAL"]] = amount

for state in state_totals:
	state_totals[state] = sorted(state_totals[state].items(), key=operator.itemgetter(1), reverse=True)
	
max_chemicals = {}
for state in state_totals:
	max_chemicals[state] = {}
	i = 1;
	for chem in state_totals[state]:
		print chem
		max_chemicals[state]["name" + str(i)] = chem[0]
		max_chemicals[state]["value" + str(i)] = chem[1]
		i += 1
		if i > 10:
			break
		

# Map values to smaller range to fit on bar graph
range_min = 5
range_max = 80
for state in max_chemicals:
	max_value = max_chemicals[state]["value1"]
	try:
		min_value = max_chemicals[state]["value10"]
		
		for i in range(1, 11):
			value = max_chemicals[state]["value" + str(i)]
			original_span = max_value - min_value
			map_span = range_max - range_min
			
			valueScaled = float(value - min_value) / float(original_span)
			
			max_chemicals[state]["value" + str(i)] = range_min + (valueScaled * map_span)
	except(KeyError):
		print "Don't have 10 values for " + str(state)
		
		
# Write out the mapped json heights
with open('StateChemicals2009.json', 'w') as fp:
	json.dump(max_chemicals, fp)