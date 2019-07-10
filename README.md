# Immersive.Unity.Vis

---

With the advances of augmented reality (AR), virtual reality (VR), and mixed reality (MR, there is a need to visualize various data on devices beyond desktop computers.

This work provides a library of example immersive visualization and interaction projects built with Unity3D for AR (such as HoloLens) and VR (such as Oculus Rift and HTC Vive). Each example can be downloaded and run with Unity3D separately, which makes modification easy for developers. To deploy these examples on a particular device, the corresponding API should be downloaded and used to compile the executable program (please refer to the developer documentation of selected devices).

We have chosen most commonly used visualizations, including bar chart, line chart, scatter plot, etc. Most of our projects work by reading data from CSV files or random numbers. Interaction functions are also provided in some projects, such as mouse hover or selection.



---

## List of Visualizations

 - Stacked / Grouped Bars
 - Circular heatchart
 - Bar chart
 - 3D bar chart
 - Bubble chart
 - Scatterplot
 - Image / image stack
 - Node link 
 - Parallel coordinate
 - Geospatial visualization

---

## Generic Utilities

- We've started to design a generic data adaptor. ([Checkout this file](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/blob/master/DataAdapter.cs))
    - Currently has an implementation for csv files and a simple json reader. The json reader comes from here: [http://wiki.unity3d.com/index.php/SimpleJSON](http://wiki.unity3d.com/index.php/SimpleJSON)
- [Custom Mesh Generation]()
- [Selections & Data Binding](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Selection-and-data-binding)

---

## Documentation

The summary of this library is available at: [pdf](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/iuv.pdf)

In case of any problems, feel free to reach out to us.


---

## Example Snapshots

![Bar Chart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Stacked_Bars/barChart.png)
![heatchart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Circular_Heatchart/Circular_Heatchart_Example.png)



## Past Contributors

Tahir Mahmood (May 2019)

Willis Fulmer (Dec 2018)

Timothy Hayduk (May 2018)





