# Easy loading

Set of tools to load scenes and monitor its progress.

![scene transition](Documentation~/Images/transition-sample.gif)

## Usage

## Scene loading - using ScreenTransition

1. Put the LoadScene script in a game object on your first scene.
2. Enter the scene name you want to load.
3. Tick the *async* checkbox if you want an asynchronous loading process
4. Select *OnStart* if you want the load to be launched as soon as the game object is loaded and enabled in your scene.

![load scene script](Documentation~/Images/loadScene.jpg)

- Select *OnCall* to disable auto load, and call the public *StartLoading()* method when you want to load the next scene.
- Select *OnEvent* so the load is done when the specified event is raised in your scene.
- Select *OnSceneLoaded* if you want the new load to be triggered as soon as this object detect a scene load.

## Scene loading - not using ScreenTransition

1. Put the LoadScene script in a game object on your first scene.
2. Enter the scene name you want to load.
3. Tick the *async* checkbox if you want an asynchronous loading process
4. Select *OnStart* if you want the load to be launched as soon as the game object is loaded and enabled in your scene.

You can select *OnCall* to disable auto load, and call the public *StartLoading()* method when you want to load the next scene.
Or you can select *OnEvent* so the load is done when the specified event is raised in your scene.
Or select *OnSceneLoaded* if you want the new load to be triggered as soon as this object detect a scene load.

### Loading object manager

This manager allows to chain load multiple objects before starting to load the next scene. It is useful if you have heavy components to load and must be sure they are loaded one after another (like a translation file that must be loaded before showing them as tips for instance).

1. Put the LoadingObjectManager in a game object on your scene.
2. Add multiple components in the object list
3. Set the LoadScene object.

Starting from the first, it will enable each GameObject attached to the component if not already.
If the component implements the IShouldWait interface, it will yield until the component set the initialization as complete, otherwise it waits for the end of frame.
Loop until all linked components are initialized.
Wait for one last frame, then call the StartLoading function on the LoadScene linked object.

### Demo

See the [FourScenesTemplate project](https://github.com/FredericRP/FourScenesTemplate) for a full demo of this easy loading package.
More information will be share on my [Medium profile](https://medium.com/@fredericrp).