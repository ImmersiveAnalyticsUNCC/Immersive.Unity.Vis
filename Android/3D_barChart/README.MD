# 3D Bar Chart

This is a 3d bar chart visualization made using unity3d.

## Functions provided in this example:
1. 3D bar chart

![Bar Chart](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Android/3D_barChart/barchart.png)

2. Labels for bar chart

3. Interactive mouse selection and text labels for showing data

![Mouse Interaction](https://github.com/ImmersiveAnalyticsUNCC/Immersive.Unity.Vis/blob/master/Android/3D_barChart/barchart-interact.png)

4. Switching datasets from object "main camera".

5. Loading json dataset.

6. To get started, double click the 3dChart scene under the "scene" directory. 

##Version 1.0

### Added Android support

### New Interaction

1. Pan: Can move camera around scene
2. Zoom: Zoom in/ out to better see barchart data
3. Rotate: Can rotate the Barchart around for better visualization
4. Reset: Can reset barchart/ camera to original positions/sizes

#### Mouse and Keyboard Interaction

Pan: Pan by clicking and draggin mouse across screen
Zoom: Zoom by using middle mouse wheel
Rotate: Uses a toggle button to switch between rotate/pan functions. Rotate by clicking and draggin mouse across screen in desired direction
Reset: Click button to reset scene positions/sizes
 
#### Mobile Interaction

Pan: Pan by draggin finger across screen in desired direction
Zoom: Zoom by using two fingers, can pinch to zoom in/out
Rotate: uses a toggle button to switch between rotate/pan functions. Rotate by swiping finger across scene
Reset: Tap button to reset scene positions/sizes

##Version 1.01 

Changed Toggle button to show when interaction is set to Pan/Rotate Respectively

To change UI Scale to adjust for screen size Find the "Canvas Scaler" component in the inspector of the "Canvas" element and adjust the value according to screen size.

	
