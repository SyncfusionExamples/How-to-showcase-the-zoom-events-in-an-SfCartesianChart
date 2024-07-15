# How to retrieve axis range min/max values on Zoom in .NET MAUI SfCartesianChart
[.NET MAUI SfCartesianChart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts) provides [zoom and pan events](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#events) that enable customization of the zoom behavior in charts. This article highlights the key events and demonstrates how to dynamically retrieve the axis [VisibleMinimum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMinimum) and [VisibleMaximum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMaximum) values during these interactions.

### Zoom and Pan Events:
* **[ZoomStart:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ZoomStart)** Triggered when the user initiates a zoom action. Can be canceled to interrupt the action.
* **[ZoomDelta:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ZoomDelta)** Activated during the zooming process and can be canceled.
* **[ZoomEnd:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ZoomEnd)** Triggered when the zooming action finishes.
* **[SelectionZoomStart:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_SelectionZoomStart)** Occurs when the user begins box selection zooming.
* **[SelectionZoomDelta:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_SelectionZoomDelta)** Activated during the process of selecting a region for zooming and can be canceled.
* **[SelectionZoomEnd:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_SelectionZoomEnd)** Triggered after the selection zooming ends.
* **[Scroll:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_Scroll)** Triggered during panning and can be canceled.
* **[Reset:](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ResetZoom)** Triggered after the chart is reset by double-tapping.

### Initialize SfCartesianChart:
Begin by setting up the **SfCartesianChart** according to the [guidelines in the documentation](https://help.syncfusion.com/maui/cartesian-charts/getting-started).

### Dynamically retrieve axis visible minimum and maximum :

To dynamically retrieve the axis visible minimum and maximum values based on user interactions, initialize the [ZoomEnd](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ZoomEnd) and [Scroll](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_Scroll)  events in the SfCartesianChart. The ZoomEnd event triggers when zooming concludes, and the Scroll event triggers when panning the chart. Inside these event handlers, you can access parameters such as [VisibleMinimum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMinimum) and [VisibleMaximum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMaximum)of the axis. Convert these double values to DateTime objects to enable direct manipulation and visualization of date and time values.

XAML
 
 ```html
 <Label Text="Axis visible minimum:"/>
 <Label Text="{Binding VisibleMinimum, StringFormat='{0: MMM d}'}" />
 <Label Text="Axis visible maximum:" />
 <Label Text="{Binding VisibleMaximum, StringFormat='{0: MMM d}'}"/>

<chart:SfCartesianChart ZoomEnd="Chart_ZoomEnd"       
                        Scroll="Chart_Scroll">

    <chart:SfCartesianChart.XAxes>
    <chart:DateTimeAxis>
        <chart:DateTimeAxis.Title>
        <chart:ChartAxisTitle Text="Year"/>
        </chart:DateTimeAxis.Title>
        <chart:DateTimeAxis.LabelStyle>
        <chart:ChartAxisLabelStyle LabelFormat="MMM-dd"/>
        </chart:DateTimeAxis.LabelStyle>
    </chart:DateTimeAxis>
    </chart:SfCartesianChart.XAxes>

  <chart:SfCartesianChart.YAxes>
      <chart:NumericalAxis>
          <chart:NumericalAxis.Title>
              <chart:ChartAxisTitle Text="Stoke price"/>
          </chart:NumericalAxis.Title>
      </chart:NumericalAxis>
  </chart:SfCartesianChart.YAxes>
  
<chart:SfCartesianChart.ZoomPanBehavior>
    <chart:ChartZoomPanBehavior EnableDoubleTap="False" />
</chart:SfCartesianChart.ZoomPanBehavior>

</chart:SfCartesianChart> 
 ```
 
 ```csharp
private void Chart_ZoomEnd(object sender, ChartZoomEventArgs e)
 {
     if (e.Axis is DateTimeAxis dateTimeAxis)
     {      
         viewModel.VisibleMinimum = DateTime.FromOADate(dateTimeAxis.VisibleMinimum);
         viewModel.VisibleMaximum = DateTime.FromOADate(dateTimeAxis.VisibleMaximum);

     } 
  }
  
 private void Chart_Scroll(object sender, ChartScrollEventArgs e)
 {
     if (e.Axis is DateTimeAxis dateTimeAxis)
     {
         viewModel.VisibleMinimum = DateTime.FromOADate(dateTimeAxis.VisibleMinimum);
         viewModel.VisibleMaximum = DateTime.FromOADate(dateTimeAxis.VisibleMaximum);
     }
 }
 ```
 
C# :
 ```csharp
 VerticalStackLayout views = new VerticalStackLayout();
 var label1 = new Label
 {
     Text = "Axis range minimum:",
 };

 var label2 = new Label();
 label2.SetBinding(Label.TextProperty, new Binding("VisibleMinimum", stringFormat: "{0: MMM d}"));

 var label3 = new Label
 {
     Text = "Axis range maximum:",
 };

 var label4 = new Label();
 label4.SetBinding(Label.TextProperty, new Binding("VisibleMaximum", stringFormat: "{0: MMM d}"));

 SfCartesianChart chart = new SfCartesianChart();
 chart.ZoomEnd += Chart_ZoomEnd;
 chart.Scroll += Chart_Scroll;

 DateTimeAxis primaryAxis = new DateTimeAxis();
 primaryAxis.Title = new ChartAxisTitle
 {
     Text = "Year",
 };
 primaryAxis.LabelStyle = new ChartAxisLabelStyle
 {
     LabelFormat = "MMM-dd"
 };
 chart.XAxes.Add(primaryAxis);

 NumericalAxis secondaryAxis = new NumericalAxis();
 secondaryAxis.Title = new ChartAxisTitle
 {
     Text = "Stoke price [in dollar]",
 };
 chart.YAxes.Add(secondaryAxis);

  chart.ZoomPanBehavior = new ChartZoomPanBehavior()
  {
      EnableDoubleTap = false,
  };

 views.Add(label1);
 views.Add(label2);
 views.Add(label3);
 views.Add(label4);
 views.Add(chart);

 this.Content = views;
 ```
 
 ![Zoom_chart.gif](https://support.syncfusion.com/kb/agent/attachment/article/16330/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI0MzExIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.C6IxxwTgnrZOUKN0WdpfR7k6_QhDB83hQz3u81e8nww)
