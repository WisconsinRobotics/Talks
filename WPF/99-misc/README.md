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
