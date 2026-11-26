using Microsoft.Maui.Graphics;

namespace Tanaffas.Drawables;

/// <summary>Peak flow line over green, yellow and red bands computed from the personal best.</summary>
public class PeakFlowChart : IDrawable
{
    public IReadOnlyList<double?> Values { get; set; } = Array.Empty<double?>();
    public int PersonalBest { get; set; } = 500;

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        const float pad = 10f;
        float left = pad, top = pad;
        float w = dirtyRect.Width - 2 * pad, h = dirtyRect.Height - 2 * pad;
        float bottom = top + h;

        var present = Values.Where(v => v.HasValue).Select(v => v!.Value).ToList();
        var max = Math.Max(PersonalBest * 1.1, present.Count > 0 ? present.Max() : 0);
        if (max <= 0) return;

        float Y(double v) => (float)(bottom - v / max * h);
        var yGreen = Y(PersonalBest * 0.8);
        var yRed = Y(PersonalBest * 0.5);

        canvas.FillColor = Color.FromArgb("#CFF5E0");
        canvas.FillRectangle(left, top, w, Math.Max(0f, yGreen - top));
        canvas.FillColor = Color.FromArgb("#FDE7D8");
        canvas.FillRectangle(left, yGreen, w, Math.Max(0f, yRed - yGreen));
        canvas.FillColor = Color.FromArgb("#FBDAD7");
        canvas.FillRectangle(left, yRed, w, Math.Max(0f, bottom - yRed));

        if (Values.Count == 0) return;
        var step = Values.Count > 1 ? w / (Values.Count - 1) : 0f;
        var dark = Color.FromArgb("#064E4A");

        canvas.StrokeColor = dark;
        canvas.StrokeSize = 2.5f;
        float? px = null, py = null;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i] is not double v) continue;
            var x = left + i * step;
            var y = Y(v);
            if (px.HasValue && py.HasValue) canvas.DrawLine(px.Value, py.Value, x, y);
            px = x; py = y;
        }

        canvas.FillColor = dark;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i] is not double v) continue;
            canvas.FillCircle(left + i * step, Y(v), 4f);
        }
    }
}

/// <summary>Simple bar chart. The last bar (today) is drawn darker.</summary>
public class BarChart : IDrawable
{
    public IReadOnlyList<int> Values { get; set; } = Array.Empty<int>();

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (Values.Count == 0) return;
        const float pad = 8f;
        var w = dirtyRect.Width - 2 * pad;
        var h = dirtyRect.Height - 2 * pad;
        var slot = w / Values.Count;
        var barWidth = Math.Max(2f, slot * 0.6f);
        var max = Math.Max(1, Values.Max());

        for (var i = 0; i < Values.Count; i++)
        {
            var barHeight = Values[i] == 0 ? 3f : Values[i] / (float)max * h;
            var x = pad + i * slot + (slot - barWidth) / 2;
            var y = pad + h - barHeight;
            canvas.FillColor = i == Values.Count - 1 ? Color.FromArgb("#8A4B0C") : Color.FromArgb("#9FD6CC");
            canvas.FillRoundedRectangle(x, y, barWidth, barHeight, 3f);
        }
    }
}

