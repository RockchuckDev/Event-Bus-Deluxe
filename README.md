# Event Bus Deluxe

## Features
- Decoupled communication
- Multiple subscribers per event
- Works with dynamically created elements

# Installation
Copy EventBusDeluxe.cs to your project (that's it).

# Usage
## Creating Events
To get started, define a struct that will contain information relevant to your event, like this one:

``` C#
public struct SpawnFireEvent{
	public Vector3 location;
	public float duration;
	public float intensity;
	public Color fireColor;
}
```

## Subscribing Functions to Events
Next, you need to figure out which part of your game wants to listen to this event, and subscribe that part to this event. Just like so:

``` C#
public class FireSystem{
	// 
	public override void _Ready()
	{
		// The function you pass into subscribe must have a parameter of the type of event you are subscribing the function to
		// In the case below, we are subscribing SpawnFireFunction to the SpawnFireEvent, therefore SpawnFireFunction must have a single parameter of SpawnFireEvent (which it does)
        EventBusDeluxe.Subscribe<SpawnFireEvent>(SpawnFireFunction);
	}
	
	public void SpawnFireFunction(SpawnFireEvent eventData){
		// Here, we would handle spawning in fire, accessing values such as eventData.location and eventData.fireColor;
	}
}
```
Note: Any number of functions can be subscribed to a given event type


## Firing Events
Now, when write call the following:
```C#
SpawnFireEvent fireEventData = new SpawnFireEventData{
	location = new Vector3(10, 5 13);
	float duration = 1.2f;
	float intensity = 21.5f;
	Color fireColor = Color.Red;
}
EventBusDeluxe.Fire<SpawnFireEvent>(fireEventData);
```
Every function that has subscribed to SpawnFireEvent (such as SpawnFireFunction) will be called, and fireEventData will be passed to all of them.

## Unsubscribing Functions From Events

To unsubscribe our SpawnFireFunction from SpawnFireEvent, we would write:
```C#
EventBusDeluxe.UnSubscribe<SpawnFireEvent>(SpawnFireFunction);

```
And that's all. SpawnFireEvent will no longer be called when SpawnFireEvent is Fired.
