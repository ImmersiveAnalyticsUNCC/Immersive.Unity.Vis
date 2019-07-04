# Immersive.Unity.Vis

---

With the advances of augmented reality (AR), virtual reality (VR), and mixed reality (MR, there is a need to visualize various data on devices beyond desktop computers.

This work provides a library of example immersive visualization and interaction projects built with Unity3D for AR (such as HoloLens) and VR (such as Oculus Rift and HTC Vive). Each example can be downloaded and run with Unity3D separately, which makes modification easy for developers. To deploy these examples on a particular device, the corresponding API should be downloaded and used to compile the executable program (please refer to the developer documentation of selected devices).

We have chosen most commonly used visualizations, including bar chart, line chart, scatter plot, etc. Most of our projects work by reading data from CSV files or random numbers. Interaction functions are also provided in some projects, such as mouse hover or selection.



---

## List of Visualizations

 - [Stacked/Grouped Bars](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Stacked-Bar-Chart)
 - [Circular Heatchart](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Circular-Heatchart)
 - [Bubble chart](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Bubble-Chart)
 - [Scatterplot](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Scatterplot)
 - [Image / image stack](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/wiki/Stacked-Images)
 - [Node link network visualization](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/wiki/Node-link-network-visualization)
 - [Parallel coordinate](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Parallel-Coordinate-Graph)
 - [3D Bar Chart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/wiki/3D-barChart)
 - [Geospatial visualization](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/wiki/GeoSpatial-Vis)
 - Matrix (coming)

---



## Generic Utilities

- We've started to design a generic data adaptor. ([Checkout this file](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/blob/master/DataAdapter.cs))
    - Currently has an implementation for csv files and a simple json reader. The json reader comes from here: [http://wiki.unity3d.com/index.php/SimpleJSON](http://wiki.unity3d.com/index.php/SimpleJSON)
- [Custom Mesh Generation]()
- [Selections & Data Binding](https://github.com/ImmersiveAnalyticsUNCC/Unity.Vis/wiki/Selection-and-data-binding)

---

## Need Help?

In case of any problem or assistance, feel free to reach out to us.



## Example Snapshots

![Bar Chart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Stacked_Bars/barChart.png)
![heatchart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Circular_Heatchart/Circular_Heatchart_Example.png)



## Past Contributors

Tahir Mahmood (May 2019)

Willis Fulmer (Dec 2018)

Timothy Hayduk (May 2018)





