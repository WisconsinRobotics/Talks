Data Binding
============

MSDN has provided a fantastic writeup on Data Binding [here](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/data-binding-overview).
Go ahead and read it. Don't worry, I'll wait. 

If MSDN didn't make much sense, let me know on what didn't make sense and I'll
expand on it here. It's probably easier to see an example, however. Check out
the DataBindingExample solution provided. 

It shows how to bind to a collection of objects and have it display in a grid.
It allows you to edit those objects on the fly. There's an example of how to
create a ValueConverter - used when you need to convert a custom object to 
something the UI can display. If you hit the "Dump Model Info" button in the 
program, it'll dump out the current contents of the list of objects
in the textbox to the right. 

This will probably make more sense when you play with the program. Have fun!

## Custom User Controls & Data Binding
Here's a fun combination - setting up custom user controls to be bindable.
This isn't exactly straightforward, and I haven't fully figured this one out yet.
The following appears to work well, though.

### Setting up the user control
Ensuring that the user control is set up correctly is where most of the trickiness
lies. I'm going to bullet the requirements instead of writing in narrative form,
since that's easier to digest.
* You will need to assign field names to the custom user control and parent
layout container. This will allow us to set the DataContext correctly for the
DependencyProperties to find the C# properties as well as helping the child
controls find the correct values.
```XML
<UserControl x:Name="parent">
    <Grid x:Name="root"></Grid>
</UserControl>
```
* Create your dependency properties as normal. 
* For each child element that requires binding to a custom dependency property,
you need to bind using the `Path` and `ElementName`attribute. For example,
if I have a custom dependency property called `CustomText` that's going to go into
a Label:
```XML
<UserControl x:Name="parent">
    <Grid x:Name="root">
        <Label Content="{Binding Path=CustomText, ElementName=root}" />
    </Grid>
</UserControl>
```
* If you want content to flow from the user control to the consumer, you may need
to add the `Mode=TwoWay` and `UpdateSourceTrigger=PropertyChanged` to the above
binding.
* In the code behind, you need to set the root layout DataContext to the user control.
In our example, that'd be:
```C#
public partial class CustomUserControl : UserControl
{
    public CustomUserControl()
    {
        InitializeComponent();
        root.DataContext = this;
    }
}
```

### Setting up the user control consumer
Unlike the user control code, it's comparatively easy to consume the user control.
In fact, you pretty much just need to make sure you bind two way and set
the `UpdateSourceTrigger` attribute in the binding to `PropertyChanged` if 
necessary. 

### Example
TBD

I'm right now betting on the fact that this won't be needed anytime soon. 
If we need an example, open an issue and I'll cook something up.

