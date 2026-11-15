# Event Bus Deluxe
## A way for different parts of your project to communicate while staying fully decoupled (Designed primarily for Godot)

Have you ever had to replace an old particle system in your game with a new one? And had to spend hours dealing with broken scripts that still try to use the old system?
Do you wish there was a way for a single node to communicate with thousands without having to manually set up thousands of signal connections?
Have you ever wondered if there was a way to connect signals between objects dynamically spawned in a runtime?

Well look no further, Event Bus Deluxe is the solution to these problems and more!

Event bus deluxe is, at its core, a dictionary. With Types being its keys, and Lists of functions being its values. To get started, all you need to do is define a struct, like this one:

``` C#
public struct SpawnFireEvent{
	Vector3 location;
	float duration;
	float intensity;
	Color fireColor;
}
```

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

Now, when we call the following:
```C#
SpawnFireEvent fireEventData = new SpawnFireEventData{
	location = new Vector3(10, 5 13);
	float duration = 1.2f;
	float intensity = 21.5f;
	Color fireColor = Color.Red;
}
EventBusDeluxe.Fire<SpawnFireEvent>(fireEventData);
```

Every function that has subscribed to SpawnFireEvent (such as SpawnFireFunction) will be called, and fireEventData will be passed to all of them. For our examples, this just means that SpawnFireFunction will be called, but we could also subscribe another function that tracks how many fires have been spawned. Or another function that spawns in a hitbox for the fire. Or another that alerts enemies to the presence of fire, and tells them to avoid it. And we aren't limited to just our SpawnFireEvent. We could define SpawnEnemyEvent, or PlayerLeveledUpEvent. You can create as many event structs as you want, and subscribe as many functions to each event as you want.

To unsubscribe our SpawnFireFunction from SpawnFireEvent, we would write:
```C#
EventBusDeluxe.UnSubscribe<SpawnFireEvent>(SpawnFireFunction);

```
And that's all. SpawnFireEvent will no longer be called when SpawnFireEvent is Fired.
