using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.SkiaSharp;
using SkiaSharp;

class Graph
{
    private string title;
    private PlotModel plotModel;

    public Graph(string title)
    {
        this.title = title;
        plotModel = new PlotModel { Title = title };
        plotModel.Legends.Add(new Legend { LegendPosition = LegendPosition.TopCenter, LegendPlacement = LegendPlacement.Outside, LegendOrientation = LegendOrientation.Horizontal, LegendTitle = "Legenda"});
    }

    public void AddLineSeries(long[] values, string seriesName)
    {

        // Create a new LineSeries and add some data points
        var lineSeries = new LineSeries
        {
            Title = seriesName,
            MarkerType = MarkerType.Circle
        };

        for (int i = 0; i < values.Length; i++)
        {
            lineSeries.Points.Add(new DataPoint(i, values[i]));
        }

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
            
            using (var stream = File.OpenWrite(title + ".png"))
            {
                renderer.Export(plotModel, stream);
            }
        }

        Console.WriteLine($"Plot saved as {title}.png");
    }
}

