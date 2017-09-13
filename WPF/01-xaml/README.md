XAML Basics
===========

WPF separates its UI layout/definition from the business logic. This allows 
graphic artists prettify the UI without knowing how to program, and also forces
programmers to enforce good separation of UI and code. 

XAML is the UI component language, and is part of the XML family. You may have
heard of HTML, which is used to layout websites. If you know HTML, XAML is pretty
much the same.

Let's get some terminology out of the way:
```
<ns:Test a="1"></ns:Test>
```
* `Test` is a tag. Each tag must have a closing tag, or is self closing (`<Test />`).
* `ns:` is a namespace. You won't see this often. This is used to organize
different tags from different organizations.
* `a` is an attribute. 
* A `Control` is a WPF term for UI element, like a button.

Alright, let's see some code! Open up the solution in the ControlShowcase folder!

## The ControlShowcase Solution
The ControlShowcase program just shows how to instantiate some common controls 
in WPF. It's all in MainWindow.xaml. Each .xaml file is paired with a .xaml.cs
file for handling events, like button presses. That's done in the 
[Events](03-events) tutorial.

You may notice a lot of `<Grid></Grid>` tags. Those are used for layout, which we 
cover in the [Layout](02-layout) tutorial. For now, you can just run the program 
and play with the controls to get a feel for what they are. If you open up 
MainWindow.xaml within Visual Studio, Visual Studio will render a preview of the 
program. Feel free to click on a control, and Visual Studio will jump to the 
control you selected in the XAML code. 

Of course, the controls shown are not exhaustive. These were chosen since they
are pretty commonly used. You can also make your own! That's covered in the 
[User Controls](04-user-controls) tutorial.