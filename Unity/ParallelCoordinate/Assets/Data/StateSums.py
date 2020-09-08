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
state_mapped_totals = {}

for doc in data["docs"]:
	amount = 0
	if doc["UNIT_OF_MEASURE"] == "Pounds":
		amount = doc["TOTAL_RELEASES"]
	elif doc["UNIT_OF_MEASURE"] == "Grams":
		amount = doc["TOTAL_RELEASES"] * 0.00220462
	if doc["ST"] in state_totals:
		state_totals[doc["ST"]] += amount
	else:
		state_totals[doc["ST"]] = amount

# Find the max and min values
max_key = max(state_totals.iteritems(), key=operator.itemgetter(1))[0]
min_key = min(state_totals.iteritems(), key=operator.itemgetter(1))[0]

print state_totals
print state_totals[min_key]
print state_totals[max_key]

# Map the values to our height range 10 - 30
range_min = 10
range_max = 30
for key in state_totals:
	value = state_totals[key]
	original_span = state_totals[max_key] - state_totals[min_key]
	map_span = range_max - range_min
	
	# Convert to a 0-1 range
	valueScaled = float(value - state_totals[min_key]) / float(original_span)
	
	# Convert to our specified range
	state_mapped_totals[key] = range_min + (valueScaled * map_span)

print "\n"
print state_mapped_totals

# Write out the mapped json heights
with open('StateHeights2009.json', 'w') as fp:
	json.dump(state_mapped_totals, fp)