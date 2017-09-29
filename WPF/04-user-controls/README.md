User Controls
=============

Up until this point, we have dealing exclusively with using the built-in controls for
everything. However, it's very unreasonable to try and cram everything in the 
MainWindow.xaml file. If you have a complex application, your XAML file is going to
be large, and the code behind even larger. Thus, we want a way to modularize our
application. The simplest way to do so is to define our own user control.

Luckily, it's straightforward to create a new user control. Just create one via the new file
dialog in Visual Studio. It will create a .xaml and .xaml.cs pair just like the 
MainWindow. 

From there on out, you program your user control in exactly the same way you did with
the MainWindow - add layout containers and built-in containers, hook up event handlers,
and more. 

It's also very easy to add your user control to other user controls or your 
MainWindow. The steps are:
* First, take note of what namespace your control lives in. Easiest way to 
do this is to look at the top of the user control XAML file or the namespace in the
code behind. 

* Add the namespace to the destination user control. It might already be there.
Note that you need to assign a "nickname" for the namespace. Below, we designate the
`Test.Controls` namespace as the name `local`.
```XML
<UserControl xmlns:local="clr-namespace:Test.Controls">
</UserControl>
```
* Add your control in the body of the destination user control:
```XML
<UserControl xmlns:local="clr-namespace:Test.Controls">
    <local:CustomControl></local:CustomControl>
</UserControl>
```

Check out the BasicUserControl solution to see this in action!

## Dependency Properties
In the above section, we learned how to build a basic user control. But how do you make
a user control that effectively functions like a template? In theory, you want to give
it some parameters so you can customize based on the situation.

WPF calls these dependency properties. Every single attribute you see on the builtin
controls (e.g. Text in TextBox) are in reality called dependency properties. We can
create our own!

This must be done in the code behind - no XAML here. The easiest way to show this is to
do a quick example. Let's say we have a CustomUserControl, and we want to make a custom
"Text" property. In other words, we want the final result to be:

```XML
<CustomUserControl Text="Some_User_Text_Goes_Here" />
```

To do this, let's hop in the backend code:
```C#
public partial class CustomUserControl : UserControl
{
    public CustomUserControl()
    {
        InitializeComponent();
    }

    public static DependencyProperty TextProperty = 
        DependencyProperty.Register("Text", typeof(string), typeof(CustomUserControl));

    public string Text
    {
        get { return GetValue(TextProperty) as string; }
        set { SetValue(TextProperty, value); }
    }
}
```

Let's go through this code:


To create a dependency property, you need to register it with the `DependencyProperty`
class. Standard convention dictates that you take your desired property name and append
`Property` to the name. Here's a quick rundown of what the `DependencyProperty.Register()`
method takes. 
* The first parameter is what you want your property to be called in XAML.
* The next parameter is the type of the XAML property. Usually it's string, int, or bool
. If you want a custom type, you'll probably need a ValueConverter.
* The third parameter is the parent control the property belongs to. This is almost
always your user control.

There are additional overloads of the `Register` method, but I won't cover them here.
If you need them, you're better off surfing StackOverflow than listening to me.

Check it out in the DependencyProperty solution!