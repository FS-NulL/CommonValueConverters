# Common Composable WPF Value Converters

A set of common value converters that can be used in WPF projects. The ValueConverterGroup converter allows multiple converters to be chained together. The individual converters can still be used in isolation.

## Exmaple Usage

```
    <Window.Resources>
        <vc:ValueConverterGroup x:Key="require_8_chars">
            <vc:StringToLengthConverter/>
            <vc:IntGreaterEqualConverter Threshold="8"/>
        </vc:ValueConverterGroup>
    </Window.Resources>
    
    <StackPanel>
        <TextBox x:Name="textbox"/>
        <Button Content="Click" 
                IsEnabled="{Binding ElementName=textbox, 
                    Path=Text, 
                    Converter={StaticResource require_8_chars}}"/>
    </StackPanel>
```

The above example enables the button when there is >= 8 characters in the textbox.

## Acknowledgements

The ValueConverterGroup class was written by [Trevi Awater](https://github.com/awatertrevi/). The original can ne found [here.](https://gist.github.com/awatertrevi/68924981bdea1800f5af162e4eb2b1f5#file-valueconvertergroup-cs)

## Getting Started
Add the shared project to your solution, then add the following XML namespace to your window:
```
xmlns:vc="clr-namespace:CommonValueConverters"
```

## Converters
### BoolInvertConverter
This takes a bool and returns the invert of the original value.

### BoolToColorConverter
This has two properties:
* TrueColor (Defualt: Red)
* FalseColor (Default: Black)

If it given a true value, it returns the color assigned to the TrueColor property. If it is given a false value, it returns the value assigned to the FalseColor property. The TrueColor's default value is Red and the FalseColor's default value is Black. This will return a System.Windows.Media.Color.
```
<vc:BoolToColorConverter x:Key="bcConv" TrueColor="Green" FalseColor="Pink"/>
```

### BoolToVisibilityConverter
This takes a bool and converts it to a System.Windows.Visibility. Because Visibility is a 3 state enum, this converter's FalseVisibility property can be used to switch between Collapsed and Hidden Visibility. Collapsed is the default.
* TrueVisibility (Default: Visible)
* FalseVisibility (Default: Collapsed)

```
<vc:BoolToVisibilityConverter FalseVisibility="Collapsed" x:Key="bcvis"/>
<vc:BoolToVisibilityConverter FalseVisibility="Hidden" x:Key="bhvis"/>
```

### CaseConverter
This is used to convert to all uppercase or all lower case. It has one property:
* To (Default: Upper)
```
<vc:CaseConverter x:Key="caseConv" To="Lower"/>
...
<StackPanel>
    <TextBox x:Name="textbox"/>
    <TextBlock Text="{Binding ElementName=textbox, 
        Path=Text, 
        Converter={StaticResource caseConv}}"/>
</StackPanel>
```

### ColorToBrushConverter
This takes a System.Windows.Media.Color and converts it into a System.Windows.Media.SolidColorBrush.
```
<vc:ValueConverterGroup x:Key="conv1">
    <vc:BoolInvertConverter/>
    <vc:BoolToColorConverter TrueColor="Green" FalseColor="Pink"/>
    <vc:ColorToBrushConverter/>
</vc:ValueConverterGroup>
```

### IntEqualConverter
This takes an integer and returns true if that value is equal to a specified value. This converter has one property:
* CompareTo (Default: 0)

### IntGreaterEqualConverter
This takes an integer and returns true if that value is greater than or equal to a specified threshold. The threshold is set by the Threshhold property. (Default: 1)
```
<vc:IntGreaterEqualConverter Threshold="8"/>
```

### IntLessEqualConverter
Returns true if a given integer is less than or equal to a specified threshold.

### NullToBoolConverter
Converts null to false and any non-null value to true.

### StringToLengthConverter
Gets the length of a string and returns it as an integer.