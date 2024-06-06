using System;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;
using SkiaSharp;
// Create a new PlotModel

class Graph
{
    private string title;
    private PlotModel plotModel;

    public Graph(string title)
    {
        this.title = title;
        plotModel = new PlotModel { Title = title };
    }

    public void AddLineSeries()
    {

        // Create a new LineSeries and add some data points
        var lineSeries = new LineSeries
        {
            Title = "Series 1",
            MarkerType = MarkerType.Circle
        };

        lineSeries.Points.Add(new DataPoint(0, 0));
        lineSeries.Points.Add(new DataPoint(10, 18));
        lineSeries.Points.Add(new DataPoint(20, 12));
        lineSeries.Points.Add(new DataPoint(30, 8));
        lineSeries.Points.Add(new DataPoint(40, 15));

        // Add the LineSeries to the PlotModel
        plotModel.Series.Add(lineSeries);
    }

    public void SaveAsPNG(int width = 800, int height = 600)
    {
        // Render the PlotModel to an image
        using (var bitmap = new SKBitmap(width, height))
        using (var canvas = new SKCanvas(bitmap))
        {
            var renderer = new PngExporter { Width = width, Height = height };
            
            using (var stream = File.OpenWrite(title))
            {
                renderer.Export(plotModel, stream);
            }
        }

        Console.WriteLine($"Plot saved as {title}.png");
    }
}

