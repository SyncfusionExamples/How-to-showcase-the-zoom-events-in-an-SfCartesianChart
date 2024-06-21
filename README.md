# How to retrieve axis range min/max values on Zoom in .NET MAUI SfCartesianChart
This article demonstrates how to retrieve axis range minimum and maximum values during zooming in the [.NET MAUI SfCartesianChart](https://www.syncfusion.com/maui-controls/maui-cartesian-charts). By utilizing [Zoom events](https://help.syncfusion.com/maui/cartesian-charts/zooming-and-panning#events), can obtain and work with the axis range values effectively.
###### 
###### Step 1:
Begin by setting up the **SfCartesianChart** according to the [guidelines in the documentation](https://help.syncfusion.com/maui/cartesian-charts/getting-started).
###### 
###### Step 2:
Initialize the [ZoomEnd](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html#Syncfusion_Maui_Charts_SfCartesianChart_ZoomEnd) event in the [SfCartesianChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCartesianChart.html). This event is invoked when zooming ends. Within this event handler, can access the axis parameters such as [VisibleMinimum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMinimum) and [VisibleMaximum](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartAxis.html#Syncfusion_Maui_Charts_ChartAxis_VisibleMaximum), and convert these double values to DateTime objects. This allows  to work with date and time values directly.

XAML
 
 ```html
 <Label Text="Axis range minimum:"/>
 <Label Text="{Binding VisibleMinimum, StringFormat='{0: MMM d}'}" />
 <Label Text="Axis range maximum:" />
 <Label Text="{Binding VisibleMaximum, StringFormat='{0: MMM d}'}"/>

<chart:SfCartesianChart ZoomEnd="chart_ZoomEnd">

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

</chart:SfCartesianChart> 
 ```

 
 ```csharp
private void chart_ZoomEnd(object sender, ChartZoomEventArgs e)
 {
     if (e.Axis is DateTimeAxis dateTimeAxis)
     {
         DateTime minimum = DateTime.FromOADate(dateTimeAxis.VisibleMinimum);
         DateTime maximum = DateTime.FromOADate(dateTimeAxis.VisibleMaximum);
               
         viewModel.VisibleMinimum = minimum;
         viewModel.VisibleMaximum = maximum;

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

 chart.ZoomPanBehavior = new ChartZoomPanBehavior();


 views.Add(label1);
 views.Add(label2);
 views.Add(label3);
 views.Add(label4);
 views.Add(chart);

 this.Content = views;
 ```
 
  
 ![Zoom_chart.gif](https://support.syncfusion.com/kb/agent/attachment/article/16330/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI0MzExIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.C6IxxwTgnrZOUKN0WdpfR7k6_QhDB83hQz3u81e8nww)

For more information about zoom and pan events, refer to the [Zoom and Pan events UG](https://help.syncfusion.com/maui/cartesian-charts/zooming-and-panning#events) and see the runnable demo from this [Github location](https://github.com/SyncfusionExamples/How-to-showcase-the-zoom-events-in-an-SfCartesianChart).
