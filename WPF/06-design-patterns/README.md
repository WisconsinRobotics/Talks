Design Patterns
===============

At this point, we have covered the basic ideas of WPF. WPF provides many ways
to allow the developer to create modular applications that make it easier to
separate business logic and the user interface. 

This section is intended to bring all of these concepts together and introduce
to common design patterns used when developing user interfaces in industry.
We will also discuss Prism, a popular WPF extension that is built around 
a MVVM, a design pattern.

Let's start off with the most common one - Model-View-Controller (MVC). Before we
do, however, a note of caution. They aren't a panacea to all your problems - 
in other words, choose the right design for the right job. Also, these patterns
are not mutually exclusive. You can mix them together at the same time.

## Model-View-Controller (MVC)
The components:
* Model - core business logic. Represents all of the data.
* View - how the data is displayed to the user 
* Controller - handles how the user interacts with the data

Honestly, the [Wikipedia](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)
page explains this one very well, at least conceptually.

I'll put a brief paraphrasing in an attempt to give multiple views of the same
concept. When you boot up your application, the model will initialize as usual.
When the model finishes up with its duties, it'll update the view as necessary.

When the user looks at the screen, he or she will see the view. Upon interacting
with the view, the controller will receive the requested action. Depending on
the action, the controller will notify the model to update its data or other
state, or the view to change the screen.

## Model-View-Presenter (MVP)
Model-View-Presenter changes the above pattern slightly. Instead of having the
model update the view directly, we have a "presenter" layer that takes care of 
"presenting" the data to the view. It's also responsible for taking user actions
and updating the model as well. 

The [Wikipedia](https://en.wikipedia.org/wiki/Model–view–presenter) page has a good diagram of it as well.

## Model-View-ViewModel (MVVM)
The Model-View-ViewModel pattern is conceptually very similar to the MVP pattern.
The key difference, however, is the presence of a "binding" layer that allows
the automatic updating of the view from bound variables. If this sounds familiar,
it certainly should! MVVM is very much associated with WPF, XAML, and its 
accompanying data binding model. 

So in effect, the ViewModel is responsible for binding to the XAML, and handling
UI display logic. As usual, the [Wikipedia](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel)
describes the pattern very well.

# Implementing MVVM in WPF
So the million dollar question is: how do we do this in WPF? Well, that's a very
good question. There's a lot of frameworks out there, or you could roll 
your own. For example, the most well-used ones appear to be:
* [Prism 6.0](https://prismlibrary.readthedocs.io/en/latest/)
* [Caliburn.Micro](http://caliburnmicro.com/)
* [MVVMLight](http://www.mvvmlight.net/)

Here, we will cover a basic application using Prism, because that's what I'm 
familiar with. If you have worked with another framework and like it, feel free
to add another section describing a simple example.

## Prism Example
Please note that there are multiple ways to build a Prism application. The way
I'm showing right now is the first method that I was able to figure out. If you
want to explore the framework, refer to Prism's documentation [here](https://prismlibrary.readthedocs.io/en/latest/).

### Example Introduction
_Coming Soon..._
### Setup
_Coming Soon..._
### Creating the Bootstrapper
_Coming Soon..._
### Creating a Module
_Coming Soon..._
#### Defining the Module
_Coming Soon..._
#### Creating the Module views
_Coming Soon..._
#### Registering the Module with the Bootstrapper
_Coming Soon..._
### Putting it all together in the Shell/MainWindow
_Coming Soon..._
### Prism Events
_Coming Soon..._
#### Defining Events
_Coming Soon..._
#### Listening for events
_Coming Soon..._
#### Sending events
_Coming Soon..._
