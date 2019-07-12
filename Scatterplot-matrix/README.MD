Scatterplot-matrix

A Unity project that visualizes scatterplot-matirx for the Graduate Admissions dataset: https://www.kaggle.com/mohansacharya/graduate-admissions

Functions provided in this example:
1. To run this project double click the SampleScene under the Scenes folder and click on the play button.

![Scatterplot-matrix](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Scatterplot-matrix/Scatterplot.PNG)

2. This project introduces to the use of toggle button in Unity. When certain toggle buttons are checked the corresponding scatterplot matrix will be generated.

![Interaction](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Scatterplot-matirx/Interaction.PNG)

3. Here 3 scripts have been used: 
	- Parser.cs: This file is responsible of parsing the csv file and storing it into a Dictionary along with the headers
	- Plot.cs: This script is used to plot the individual datapoints based on the values of the dataset. 
			   Since the values for certain columns like GRE, TOEFL.. are large, the script also normalizes their values so that the values lie within 0-1 range and the datapoints appear close to each other.
			   With the help of these new noramlized values we then plot the datapoints using Instantiate() method and assign color.
	- AxisToggle.cs: This scripts maitains a list of toggle buttons which needs to be displayed in the Game view.
					 OnToggleValueChanged() method is an event based method which is called when a toggle button is enabled or disabled.
