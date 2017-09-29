Miscellaneous Topics
====================

This is a catch-all bin for any gotchas that you may encounter while programming
a WPF application. 


## UI Threading
WPF, internally, is multithreaded. There is a dedicated UI thread that handles
events and refreshes the UI. In your application, you may have other threads that
may be doing various other work, such as opening a file or reading a joystick.
The .NET Framework will complain if you attempt to naïvely pass objects across
thread boundaries. To correctly update UI elements from a non-UI thread, you must
use a `Dispatcher` object. There are two methods used to do so:
* `Dispatcher.Invoke` - Blocks the non-UI thread until the operation is complete
* `Dispatcher.BeginInvoke` - Asynchronously perform the requested operation

Now you may be thinking, that's awfully vague - what's the "requested operation"?
The "requested operation" is the action that you want to perform as if you were
on the UI thread. For example, if you read a joystick on a non-UI thread and you
wanted to update a textbox on the UI, the "update textbox" is the "requested
operation".

Example usage:
```C#
// suppose textBox is declared
// jsX is an integer, representing X axis of a joystick
// we are in a non-UI thread
// we can call Dispatcher as so:
using System.Windows;

Application.Current.Dispatcher.BeginInvoke(new Action(() => {
    textBox.Text = jsX.ToString();
}));

// if we are in the code behind of a WPF control or form
// we do not need to prefix with Application.Current
Dispatcher.BeginInvoke(new Action(() => {
    textBox.Text = jsX.ToString();
}));
```

### `Dispatcher.BeginInvoke` vs `Dispatcher.Invoke`
So you may be wondering, what's the difference between these two? When do I want
to use one over the other? 

In general, you want to choose the `BeginInvoke` version because it does not block
your non-UI thread. In other words, your non-UI thread can continue execution and
WPF can manage the intricacies of passing the data around. Additionally, 
`BeginInvoke` won't hang your application when you want to exit.

## Internationalization (i18n)
For larger business applications, you will need to make sure that users abroad
can use your application. The documentation on internationalizaion (i18n) is 
not very good for WPF, so here's a good place as any other to put this info.

In order to properly localize your application, all strings in the program must
be abstracted such that the program looks up the appropriately localized string.
In WPF, the most common way to do this is through ResourceDictionary files. 

ResourceDictionary files are simply XAML files that act as a key-value store for
any kind of objects. For us, however, we're just going to be cramming strings in here.
By default, ResourceDictionary files don't have access to System.String.
Let's take a look on how to set up a ResourceDictionary with the System.String class:

```XML
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:system="clr-namespace:System;assembly=mscorlib">
</ResourceDictionary>
```

Visual Studio will generate most of this file for you. The only thing you need to add
is the `xmnls:system="clr-namespace:System;assembly=mscorlib` part.

Now we can add some strings, like so:
```XML
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    xmlns:system="clr-namespace:System;assembly=mscorlib">
    <system:String x:Key="Title">English Title</system:String>
</ResourceDictionary>
```

If we reference the `Title` key anywhere in our code, the ResourceDictionary will hand
us `English Title`. Well, it's actually not quite _so_ simple. 

To access the ResourceDictionary from your code, you need to call 
`Application.Current.Resources[key]`. Make sure you cast it to a string.

If we want to dynamically change the language on the go, we need to do the following:
* Detect the language culture code (e.g. en-US) we want to go to.
* Check if we have a ResourceDictionary for it. If not, use the default one.
* Set `Thread.CurrentThread.CurrentCulture` and `Thread.CurrentThread.CurrentUICulture`
to the new culture code. This probably needs to be in the UI thread. 
_(If you can verify this, that'd be awesome!)_
* Create a new `ResourceDictionary` object and load the correct ResourceDictionary XAML
file into it.
* Call `Application.Current.Resources.MergedDictionaries.Add()` and pass it the 
dictionary you created in the previous step.

And that's it! Now, this isn't something I can just write some text and send you on
your way. Crack open the i18n-test solution in this folder, and there'll be an example
there. You should be able to match up each step above.

