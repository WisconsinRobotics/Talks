Event Basics
=============

When you click a button, you expect something to happen, like popping up a file
chooser dialog to open a file. WPF supports this by letting you bind a function/method
that is called when the event is triggered.

We won't go into the internals of how this is implemented, but if you want a small
taste, take a look at the [Wikipedia page](https://en.wikipedia.org/wiki/Event_loop).

## Terminology & Concepts
* An _Event_ is raised when something of interest happens (something is loaded, button clicked, drop down list changes)
* A _Callback_ is a function or method that is called when an event happens.
* _Binding_ a callback to an event is a fancy way of assigning a function to a event handler.
* A _Delegate_ defines a specific type of method with a certain set of parameters.
They allow functions to be passed as objects/parameters. If you are familiar with
C/C++, they are like function pointers.

## Binding to an Event

It's actually really easy to work with events in WPF. The attached solution, 
EventExample, shows a classic example of clicking a button and displaying a 
MessageBox. 

Most events require a callback method of something similar to this:
```C#
void Button_Clicked(object sender, RoutedEventArgs e)
{
    // do something //
}
```

However, some UI controls may require different types of EventArgs. Refer to the
appropriate MSDN page to see what that event may require.
