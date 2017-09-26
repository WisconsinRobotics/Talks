Layout Basics
=============

An important, but often overlooked part of UI design is the UI layout.
The layout determines how elements are positioned on screen, and their behavior
when the screen is resized. 
If we hardcode element positions on screen, we won't be able to resize.

Ideally, we want our UI to adjust when our screen size changes. To help us with this task,
WPF provides several different top level containers. Here's a small listing:
* Grid
* StackPanel
* DockPanel
* Canvas
* WrapPanel
* UniformGrid

Let's go over the various containers and how to use them:

## Grid
This is the most flexible and common container to use. You have to specify
how many rows and columns you want, as well as how much space they take.
Let's look at an example:

### Basic Usage
```XML
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>

    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <Button Grid.Row="0" Grid.Column="0">Push me!</Button>
    <Grid Grid.Row="1" Grid.Column="1"></Grid>
</Grid>
```
The above specifies a 2x2 grid of equal proportions, and places a button
in the top left corner as well as another grid right under it.

There are various ways to specify the size of a row or column:
* Relative sizes (the `*` notation). If you have 2 columns with sizes `3*` and `7*`, column 0 would take 30% (3 / (3 + 7)) of the size and column 1 70%.
* Absolute sizes - a pixel value for the element. Don't use this if you want stuff
to expand with the size of your window. (Sometimes you don't, but those cases are
special or rare)
* Automatic sizes - specified by putting `auto` in the Width or Height attribute. 
This tells WPF to let make this row or column as big as the child elements need to
be, and no more. 

It's pretty easy to use. Specify the number of rows and columns you need via
the `Grid.RowDefinitions` and `Grid.ColumnDefinitions` tags, and then
assign coordinates to child elements. You can also have subgrids as well!

If we visualize this via a table, we can see the coordinate system of a Grid. 
Let (x, y) mean (row, col):

| (0, 0) | (0, 1) |
| ------ | -----  |
| (1, 0) | (1, 1) |


## StackPanel
If you just want to list controls in one direction, then the StackPanel is what
you're looking for. 

```XML
<!-- StackPanels can go horizontally or vertically -->
<StackPanel Orientation="Vertical">
    <Button>Btn 1</Button>
    <Button>Btn 2</Button>
    <Button>Btn 3</Button>
</StackPanel>
```

In this case, you'll get 3 buttons going straight down vertically in a row.

There honestly isn't that much to say - nice and simple!

## DockPanel
The DockPanel is useful when you need to put certain elements in either the top,
left, right, or bottom parts of the window. For example, a DockPanel is usually
used to pin a menu bar at the top of a window.

This [website](https://wpftutorial.net/DockPanel.html) explains it very well.

## Canvas
If you're drawing 2D art in a GUI, you'll probably want full
control of how each control is laid out. If you aren't, there really is no reason
to use this layout method.

```XML
<Canvas>
    <Ellipse Canvas.Left="250" Canvas.Top="250" Width="50" Height="50" Fill="Red"/>
</Canvas>
```
This will put an ellipse with major and minor diameter of 50 pixels at (250, 250)
where (0, 0) is the top left corner.

If you resize this panel, nothing will happen. All coordinates specified are 
absolute coordinates.

[MSDN](https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview)
provides a good reference for drawing with Canvas.

## WrapPanel
The WrapPanel, as its name suggests, is like StackPanel in that it'll list
controls in one direction, but will wrap those controls when it hits the edge of
the window.

```XML
<!-- WrapPanels can go horizontally or vertically -->
<WrapPanel Orientation="Vertical">
    <Button>Btn 1</Button>
    <Button>Btn 2</Button>
    <Button>Btn 3</Button>
</WrapPanel>
```

If we reached the end of the screen with "Btn 2", WrapPanel would make a new
column with "Btn 3" at the top.

## UniformGrid
_Disclaimer: I have never used this panel before._

So the UniformGrid is a special type of grid where each cell is the same size. 

```XML
<UniformGrid Rows="2" Columns="2">
    <Button>Top Left</Button>
    <Button>Bottom Right</Button>
</UniformGrid>
```

# LayoutContainer Solution
Crack open the LayoutContainer solution to play with these layouts firsthand.
Each container/layout method has its own C# project. Feel free to change up 
everything and anything!
