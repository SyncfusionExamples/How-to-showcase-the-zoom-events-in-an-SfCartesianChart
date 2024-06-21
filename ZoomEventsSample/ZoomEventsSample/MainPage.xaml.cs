using Syncfusion.Maui.Charts;

namespace ZoomEventsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Zoom Event Handling in C#
            //VerticalStackLayout views = new VerticalStackLayout();
            //var label1 = new Label
            //{
            //    Text = "Axis range minimum:",
            //};

            //var label2 = new Label();
            //label2.SetBinding(Label.TextProperty, new Binding("VisibleMinimum", stringFormat: "{0: MMM d}"));

            //var label3 = new Label
            //{
            //    Text = "Axis range maximum:",
            //};

            //var label4 = new Label();
            //label4.SetBinding(Label.TextProperty, new Binding("VisibleMaximum", stringFormat: "{0: MMM d}"));

            //SfCartesianChart chart = new SfCartesianChart();
            //chart.ZoomEnd += Chart_ZoomEnd;

            //DateTimeAxis primaryAxis = new DateTimeAxis();
            //primaryAxis.Title = new ChartAxisTitle
            //{
            //    Text = "Year",
            //};
            //primaryAxis.LabelStyle = new ChartAxisLabelStyle
            //{
            //    LabelFormat = "MMM-dd"
            //};
            //chart.XAxes.Add(primaryAxis);

            //NumericalAxis secondaryAxis = new NumericalAxis();
            //secondaryAxis.Title = new ChartAxisTitle
            //{
            //    Text = "Stoke price [in dollar]",
            //};
            //chart.YAxes.Add(secondaryAxis);

            //chart.ZoomPanBehavior = new ChartZoomPanBehavior();

            //AreaSeries areaSeries = new AreaSeries()
            //{
            //    ItemsSource = new ViewModel().Data,
            //    XBindingPath = "Year",
            //    YBindingPath = "StrokePrice"
            //};
            //chart.Series.Add(areaSeries);

            //views.Add(label1);
            //views.Add(label2);
            //views.Add(label3);
            //views.Add(label4);
            //views.Add(chart);

            //this.Content = views;
        }


        private void Chart_ZoomEnd(object sender, ChartZoomEventArgs e)
        {
            if (e.Axis is DateTimeAxis dateTimeAxis)
            {
                DateTime minimum = DateTime.FromOADate(dateTimeAxis.VisibleMinimum);
                DateTime maximum = DateTime.FromOADate(dateTimeAxis.VisibleMaximum);
               
                viewModel.VisibleMinimum = minimum;
                viewModel.VisibleMaximum = maximum;

            }
        }
    }

}
