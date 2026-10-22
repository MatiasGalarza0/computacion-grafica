using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyeccionPuntoQ;

public partial class Form1 : Form
{
    private readonly Calculadora calculadora = new Calculadora();
    private Segmento? segmento;
    private Punto? puntoP;
    private Resultado? resultado;

    public Form1()
    {
        InitializeComponent();
        Calcular();
    }

    private void botonCalcular_Click(object? sender, EventArgs e) => Calcular();

    private void Calcular()
    {
        segmento = new Segmento(
            new Punto((int)ax.Value, (int)ay.Value),
            new Punto((int)bx.Value, (int)by.Value));
        puntoP = new Punto((int)px.Value, (int)py.Value);
        resultado = calculadora.Calcular(segmento, puntoP);

        string ubicacion = segmento.A.X == segmento.B.X && segmento.A.Y == segmento.B.Y
            ? "A y B coinciden"
            : resultado.T <= 0 ? "Q está en A"
            : resultado.T >= 1 ? "Q está en B" : "Q está en el segmento AB";

        etiquetaResultado.Text =
            $"Q = ({Numero(resultado.Q.X)}, {Numero(resultado.Q.Y)})   |   " +
            $"Distancia P–Q = {Numero(resultado.Distancia)}" +
            Environment.NewLine + ubicacion;

        panelPlano.Invalidate();
    }

    private void botonLimpiar_Click(object? sender, EventArgs e)
    {
        ax.Value = 2; ay.Value = 2;
        bx.Value = 8; by.Value = 2;
        px.Value = 5; py.Value = 6;
        Calcular();
    }

    private void botonPasos_Click(object? sender, EventArgs e)
    {
        Calcular();
        if (segmento != null && puntoP != null && resultado != null)
        {
            using FormPasos ventana = new FormPasos(segmento, puntoP, resultado);
            ventana.ShowDialog(this);
        }
    }

    private static string Numero(double valor)
    {
        if (Math.Abs(valor - Math.Round(valor)) < 0.00000001)
            return Math.Round(valor).ToString("0");
        return valor.ToString("0.###");
    }

    private void PanelPlano_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int ancho = panelPlano.ClientSize.Width;
        int alto = panelPlano.ClientSize.Height;
        if (ancho < 170 || alto < 150) return;

        RectangleF dibujo = new RectangleF(54, 24, ancho - 78, alto - 65);

        double minX = 0, maxX = 0, minY = 0, maxY = 0;
        if (segmento != null && puntoP != null && resultado != null)
        {
            foreach (Punto p in new[] { segmento.A, segmento.B, puntoP, resultado.Q })
            {
                minX = Math.Min(minX, p.X);
                maxX = Math.Max(maxX, p.X);
                minY = Math.Min(minY, p.Y);
                maxY = Math.Max(maxY, p.Y);
            }
        }
        else
        {
            minX = -5; maxX = 5; minY = -5; maxY = 5;
        }

        double margenX = Math.Max(2, (maxX - minX) * 0.15);
        double margenY = Math.Max(2, (maxY - minY) * 0.15);
        minX -= margenX; maxX += margenX;
        minY -= margenY; maxY += margenY;

        double escala = Math.Min(dibujo.Width / (maxX - minX),
                                 dibujo.Height / (maxY - minY));
        double centroX = (minX + maxX) / 2;
        double centroY = (minY + maxY) / 2;
        double visibleMinX = centroX - dibujo.Width / (2 * escala);
        double visibleMaxX = centroX + dibujo.Width / (2 * escala);
        double visibleMinY = centroY - dibujo.Height / (2 * escala);
        double visibleMaxY = centroY + dibujo.Height / (2 * escala);

        PointF Pixel(double x, double y) => new PointF(
            (float)(dibujo.Left + (x - visibleMinX) * escala),
            (float)(dibujo.Bottom - (y - visibleMinY) * escala));

        double deseado = 42 / escala;
        double potencia = Math.Pow(10, Math.Floor(Math.Log10(deseado)));
        double factor = deseado / potencia;
        int paso = Math.Max(1, (int)(potencia *
            (factor <= 1 ? 1 : factor <= 2 ? 2 : factor <= 5 ? 5 : 10)));

        using Pen cuadricula = new Pen(Color.FromArgb(225, 230, 237), 1f);
        using Pen ejes = new Pen(Color.FromArgb(105, 114, 124), 1.8f);
        using Pen borde = new Pen(Color.FromArgb(220, 225, 230), 1f);
        using Font numeros = new Font("Segoe UI", 8F);
        using Brush tinta = new SolidBrush(Color.FromArgb(95, 105, 115));

        g.SetClip(dibujo);
        for (double x = Math.Ceiling(visibleMinX / paso) * paso;
             x <= visibleMaxX; x += paso)
        {
            PointF a = Pixel(x, visibleMinY);
            PointF b = Pixel(x, visibleMaxY);
            g.DrawLine(cuadricula, a, b);
        }
        for (double y = Math.Ceiling(visibleMinY / paso) * paso;
             y <= visibleMaxY; y += paso)
        {
            PointF a = Pixel(visibleMinX, y);
            PointF b = Pixel(visibleMaxX, y);
            g.DrawLine(cuadricula, a, b);
        }

        if (visibleMinY <= 0 && visibleMaxY >= 0)
            g.DrawLine(ejes, Pixel(visibleMinX, 0), Pixel(visibleMaxX, 0));
        if (visibleMinX <= 0 && visibleMaxX >= 0)
            g.DrawLine(ejes, Pixel(0, visibleMinY), Pixel(0, visibleMaxY));

        if (segmento != null && puntoP != null && resultado != null)
        {
            using Pen lapizAB = new Pen(Color.RoyalBlue, 2.7f);
            using Pen lapizPQ = new Pen(Color.Firebrick, 2f) { DashStyle = DashStyle.Dash };
            g.DrawLine(lapizAB, Pixel(segmento.A.X, segmento.A.Y),
                                 Pixel(segmento.B.X, segmento.B.Y));
            g.DrawLine(lapizPQ, Pixel(puntoP.X, puntoP.Y),
                                 Pixel(resultado.Q.X, resultado.Q.Y));
        }
        g.ResetClip();

        for (double x = Math.Ceiling(visibleMinX / paso) * paso;
             x <= visibleMaxX; x += paso)
        {
            string valor = x.ToString("0");
            SizeF medida = g.MeasureString(valor, numeros);
            PointF p = Pixel(x, 0);
            g.DrawString(valor, numeros, tinta,
                p.X - medida.Width / 2, dibujo.Bottom + 4);
        }
        for (double y = Math.Ceiling(visibleMinY / paso) * paso;
             y <= visibleMaxY; y += paso)
        {
            string valor = y.ToString("0");
            SizeF medida = g.MeasureString(valor, numeros);
            PointF p = Pixel(0, y);
            g.DrawString(valor, numeros, tinta,
                dibujo.Left - medida.Width - 6, p.Y - medida.Height / 2);
        }
        g.DrawRectangle(borde, dibujo.X, dibujo.Y, dibujo.Width, dibujo.Height);
        g.DrawString("X", numeros, tinta, dibujo.Right + 6, dibujo.Bottom - 16);
        g.DrawString("Y", numeros, tinta, dibujo.Left + 5, dibujo.Top - 20);

        if (segmento == null || puntoP == null || resultado == null) return;

        List<RectangleF> etiquetas = new List<RectangleF>();
        DibujarPunto(g, Pixel(segmento.A.X, segmento.A.Y), "A", segmento.A,
            Color.RoyalBlue, dibujo, etiquetas);
        DibujarPunto(g, Pixel(segmento.B.X, segmento.B.Y), "B", segmento.B,
            Color.RoyalBlue, dibujo, etiquetas);
        DibujarPunto(g, Pixel(puntoP.X, puntoP.Y), "P", puntoP,
            Color.Firebrick, dibujo, etiquetas);
        DibujarPunto(g, Pixel(resultado.Q.X, resultado.Q.Y), "Q", resultado.Q,
            Color.ForestGreen, dibujo, etiquetas);
    }

    private static void DibujarPunto(Graphics g, PointF p, string nombre,
        Punto valor, Color color, RectangleF dibujo, List<RectangleF> ocupadas)
    {
        using Brush tinta = new SolidBrush(color);
        using Brush fondo = new SolidBrush(Color.FromArgb(245, 255, 255, 255));
        using Font fuente = new Font("Segoe UI", 9F, FontStyle.Bold);
        g.FillEllipse(tinta, p.X - 5, p.Y - 5, 10, 10);

        string texto = $"{nombre} ({Numero(valor.X)}, {Numero(valor.Y)})";
        SizeF medida = g.MeasureString(texto, fuente);
        float[][] opciones = nombre switch
        {
            "A" => new[] { new float[] { -medida.Width - 8, -medida.Height - 8 },
                           new float[] { 9, -medida.Height - 8 },
                           new float[] { -medida.Width - 8, 8 } },
            "Q" => new[] { new float[] { 9, 8 },
                           new float[] { -medida.Width - 8, 8 },
                           new float[] { 9, -medida.Height - 8 } },
            _ => new[] { new float[] { 9, -medida.Height - 8 },
                         new float[] { -medida.Width - 8, -medida.Height - 8 },
                         new float[] { 9, 8 } }
        };

        RectangleF caja = RectangleF.Empty;
        foreach (float[] o in opciones)
        {
            float x = Math.Clamp(p.X + o[0], dibujo.Left + 2,
                Math.Max(dibujo.Left + 2, dibujo.Right - medida.Width - 2));
            float y = Math.Clamp(p.Y + o[1], dibujo.Top + 2,
                Math.Max(dibujo.Top + 2, dibujo.Bottom - medida.Height - 2));
            RectangleF candidata = new RectangleF(x, y, medida.Width, medida.Height);
            if (ocupadas.TrueForAll(otra => !otra.IntersectsWith(candidata)))
            {
                caja = candidata;
                break;
            }
            caja = candidata;
        }
        ocupadas.Add(caja);
        g.FillRectangle(fondo, caja);
        g.DrawString(texto, fuente, tinta, caja.Location);
    }
}

