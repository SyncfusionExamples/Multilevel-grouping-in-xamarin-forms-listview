# MultiLevel Grouping in ListView

The SfListView supports multiple level grouping by adding multiple [GroupDescriptor](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.DataSource.Portable~Syncfusion.DataSource.GroupDescriptor.html) objects into the [DataSource.GroupDescriptors](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.DataSource.Portable~Syncfusion.DataSource.DataSource~GroupDescriptors.html) collection. The grouped items will be displayed in hierarchical structure by customizing the [SfListView.GroupHeaderTemplate](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~GroupHeaderTemplate.html) property. In the `GroupHeaderTemplate`, set the `Padding` property to the custom view to arrange the group header items and sub-group header items in the hierarchical structure.

```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             xmlns:data="clr-namespace:Syncfusion.DataSource;assembly=Syncfusion.DataSource.Portable">
  <ContentPage.Resources>
    <ResourceDictionary>
      <local:GroupHeaderConverter x:Key="TemplateConverter"/>
    </ResourceDictionary>
  </ContentPage.Resources>
  <syncfusion:SfListView ItemsSource="{Binding EmployeeInfo}" ItemSize="60">
    <syncfusion:SfListView.DataSource>
      <data:DataSource>
        <data:DataSource.GroupDescriptors>
            <data:GroupDescriptor PropertyName="Designation" />
            <data:GroupDescriptor PropertyName="Level" />
        </data:DataSource.GroupDescriptors>
      </data:DataSource>
    </syncfusion:SfListView.DataSource>
    <syncfusion:SfListView.GroupHeaderTemplate>
      <DataTemplate>
          <ViewCell>
            <ViewCell.View>
              <StackLayout BackgroundColor="{Binding Level,Converter={StaticResource TemplateConverter}}"
                            Padding="{Binding Level,Converter={StaticResource TemplateConverter}}">
                  <Label Text="{Binding Key}" 
                        VerticalOptions="Center" HorizontalOptions="Start"/>
              </StackLayout>
            </ViewCell.View>
          </ViewCell>
      </DataTemplate>
    </syncfusion:SfListView.GroupHeaderTemplate>
  </syncfusion:SfListView>
</ContentPage>
```

```
listView.ItemsSource = viewModel.EmployeeInfo;
listView.ItemSize = 60;
listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
{
  PropertyName = "Designation",
});
listView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
{
  PropertyName = "Designation",
});
listView.GroupHeaderTemplate = new DataTemplate(() =>
{
  var stack = new StackLayout();
  Binding binding = new Binding("Level");
  binding.Converter = new TemplateConverter();
  stack.SetBinding(StackLayout.BackgroundColorProperty, binding);
  stack.SetBinding(StackLayout.PaddingProperty, binding);

  var label = new Label() { VerticalOptions=LayoutOptions.Center,HorizontalOptions=LayoutOptions.Start};
  label.SetBinding(Label.TextProperty, new Binding("Key"));

  return stack;
});

public class GroupHeaderConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
     if (targetType.Name == "Color")
     {
        if ((int)value == 1)
           return Color.FromHex("#D3D3D3");
        else
           return Color.Transparent;
     }
     else
     {
        if ((int)value == 1)
           return new Thickness(5, 5, 5, 0);
        else
           return new Thickness((int)value * 15, 5, 5, 0);
     }
  }

   public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
   {
     throw new NotImplementedException();
   }
}
```

To know more about grouping in ListView, please refer our documentation [here](https://help.syncfusion.com/xamarin/sflistview/grouping).