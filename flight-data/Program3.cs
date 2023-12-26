// Example draw graph
using System;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.ImageSharp;


var model = new PlotModel();

// оси
var axe_x = new LinearAxis(); 
axe_x.Position = AxisPosition.Bottom;
var axe_y = new LinearAxis();
axe_y.Position = AxisPosition.Left;

model.Axes.Add(axe_x);
model.Axes.Add(axe_y);
model.Background = OxyColors.White;

var line = new LineSeries();
for (var i = 0; i < 100; i++)  // рисуем 100 точек
{
	line.Points.Add(new DataPoint(i/100.0, Math.Sin(2 * Math.PI * i/100)));
}

line.Color = OxyColors.Red;
line.StrokeThickness = 2;
model.Series.Add(line);


using var png = File.Create("graph.png");
var exporter = new PngExporter(800, 600);
exporter.Export(model, png);

