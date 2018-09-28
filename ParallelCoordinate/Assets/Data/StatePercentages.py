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
	
	# Totals
	if doc["ST"] in state_totals:
		state_totals[doc["ST"]]["TOTAL"] += amount
	else:
		state_totals[doc["ST"]] = {}
		state_totals[doc["ST"]]["TOTAL"] = amount
	
	# Handle FEDERAL_FACILITY
	if doc["FEDERAL_FACILITY"] == "YES":
		if doc["ST"] in state_totals and "FEDERAL_FACILITY" in state_totals[doc["ST"]]:
			state_totals[doc["ST"]]["FEDERAL_FACILITY"] += amount
		elif doc["ST"] in state_totals:
			state_totals[doc["ST"]]["FEDERAL_FACILITY"] = amount
		else:
			state_totals[doc["ST"]] = {}
			state_totals[doc["ST"]]["FEDERAL_FACILITY"] = amount
			
	# Handle CLEAR_AIR_ACT_CHEMICAL
	if doc["CLEAR_AIR_ACT_CHEMICAL"] == "YES":
		if doc["ST"] in state_totals and "CLEAR_AIR_ACT_CHEMICAL" in state_totals[doc["ST"]]:
			state_totals[doc["ST"]]["CLEAR_AIR_ACT_CHEMICAL"] += amount
		elif doc["ST"] in state_totals:
			state_totals[doc["ST"]]["CLEAR_AIR_ACT_CHEMICAL"] = amount
		else:
			state_totals[doc["ST"]] = {}
			state_totals[doc["ST"]]["CLEAR_AIR_ACT_CHEMICAL"] = amount
	
	# Handle METAL
	if doc["METAL"] == "YES":
		if doc["ST"] in state_totals and "METAL" in state_totals[doc["ST"]]:
			state_totals[doc["ST"]]["METAL"] += amount
		elif doc["ST"] in state_totals:
			state_totals[doc["ST"]]["METAL"] = amount
		else:
			state_totals[doc["ST"]] = {}
			state_totals[doc["ST"]]["METAL"] = amount
	
	# Handle CARCINOGEN
	if doc["CARCINOGEN"] == "YES":
		if doc["ST"] in state_totals and "CARCINOGEN" in state_totals[doc["ST"]]:
			state_totals[doc["ST"]]["CARCINOGEN"] += amount
		elif doc["ST"] in state_totals:
			state_totals[doc["ST"]]["CARCINOGEN"] = amount
		else:
			state_totals[doc["ST"]] = {}
			state_totals[doc["ST"]]["CARCINOGEN"] = amount

state_percents = {}

for state in state_totals:
	state_percents[state] = {}
	for key in state_totals[state]:
		if key != "TOTAL":
			state_percents[state][str(key + "_TOTAL")] = state_totals[state][key]
			state_percents[state][key] = (state_totals[state][key] / state_totals[state]["TOTAL"]) * 100.0
	
# Write out the percentages
with open('StatePercentages2009.json', 'w') as fp:
	json.dump(state_percents, fp)