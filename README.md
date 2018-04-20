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

![Exmaple](https://i.imgur.com/uGRpsZZ.gif)

## Acknowledgements

The ValueConverterGroup class was written by [Trevi Awater](https://github.com/awatertrevi/). The original can be found [here.](https://gist.github.com/awatertrevi/68924981bdea1800f5af162e4eb2b1f5#file-valueconvertergroup-cs)

## Getting Started
Add the shared project to your solution, reference it in your project, then add the following XML namespace to your window XAML:
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

### StringEqualityConverter
Returns true/false based on if the bound value matches the converter parameter.
```
<Window.Resources>
    <vc:StringEqualityConverter x:Key="string_equal"/>
</Window.Resources>
...
<TextBox x:Name="textbox"/>
<Button Content="Equal 123" 
        IsEnabled="{Binding ElementName=textbox, 
            Path=Text, 
            Converter={StaticResource string_equal},
            ConverterParameter='123'}"/>
```

### StringToLengthConverter
Gets the length of a string and returns it as an integer.

## MultiValueConverters
These converters can take multiple inputs and produce a single output. The bindings inside the multibinding can use converters too.

### AddIntConverter
Adds up N number of integer inputs
```
<Window.Resources>
    <mvc:AddIntConverter x:Key="add_converter"/>
</Window.Resources>
...
<Slider Minimum="0" Maximum="10" TickFrequency="1" IsSnapToTickEnabled="True" x:Name="sl1"/>
<Slider Minimum="0" Maximum="10" TickFrequency="1" IsSnapToTickEnabled="True" x:Name="sl2"/>
<TextBlock>
    <TextBlock.Text>
        <MultiBinding Converter="{StaticResource add_converter}" StringFormat="{}{0}">
            <Binding Path="Value" ElementName="sl1"/>
            <Binding Path="Value" ElementName="sl2"/>
        </MultiBinding>
    </TextBlock.Text>
</TextBlock>
```

### AllConverter
Returns true if all inputs are true. Input type must be boolean.
```
<Window.Resources>
    <mvc:AllConverter x:Key="all_true"/>
</Window.Resources>
...        
<CheckBox Content="cb1" x:Name="cb1" HorizontalAlignment="Center"/>
<CheckBox Content="cb2" x:Name="cb2" HorizontalAlignment="Center"/>
<CheckBox Content="cb3" x:Name="cb3" HorizontalAlignment="Center"/>
<CheckBox Content="cb4" x:Name="cb4" HorizontalAlignment="Center"/>
<Button Content="All True">
    <Button.IsEnabled>
        <MultiBinding Converter="{StaticResource all_true}">
            <Binding ElementName="cb1" Path="IsChecked"/>
            <Binding ElementName="cb2" Path="IsChecked"/>
            <Binding ElementName="cb3" Path="IsChecked"/>
            <Binding ElementName="cb4" Path="IsChecked"/>
        </MultiBinding>
    </Button.IsEnabled>
</Button>
```

### AnyConverter
Returns true if any input is true. Input type must be boolean.
```
<Window.Resources>
    <mvc:AnyConverter x:Key="any_true"/>
</Window.Resources>
...        
<CheckBox Content="cb1" x:Name="cb1" HorizontalAlignment="Center"/>
<CheckBox Content="cb2" x:Name="cb2" HorizontalAlignment="Center"/>
<CheckBox Content="cb3" x:Name="cb3" HorizontalAlignment="Center"/>
<CheckBox Content="cb4" x:Name="cb4" HorizontalAlignment="Center"/>
<Button Content="All True">
    <Button.IsEnabled>
        <MultiBinding Converter="{StaticResource any_true}">
            <Binding ElementName="cb1" Path="IsChecked"/>
            <Binding ElementName="cb2" Path="IsChecked"/>
            <Binding ElementName="cb3" Path="IsChecked"/>
            <Binding ElementName="cb4" Path="IsChecked"/>
        </MultiBinding>
    </Button.IsEnabled>
</Button>
```
