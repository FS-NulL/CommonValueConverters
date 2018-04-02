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

## Converters
### BoolInvertConverter
This takes a bool and returns the invert of the original value.

### BoolToColorConverter
This has two properties:
* TrueColor
* FalseColor

If it given a true value, it returns the color assigned to the TrueColor property. If it is given a false value, it returns the value assigned to the FalseColor property. The TrueColor's default value is Red and the FalseColor's default value is Black. This will return a System.Windows.Media.Color.

