using System;

namespace ProyeccionPuntoQ;

public class Punto
{
    public double X { get; }
    public double Y { get; }

    public Punto(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double DistanciaA(Punto otro)
    {
        return Math.Sqrt(Math.Pow(X - otro.X, 2) + Math.Pow(Y - otro.Y, 2));
    }
}

public class Segmento
{
    public Punto A { get; }
    public Punto B { get; }

    public Segmento(Punto a, Punto b)
    {
        A = a;
        B = b;
    }
}

public class Resultado
{
    public Punto Q { get; }
    public double TOriginal { get; }
    public double T { get; }
    public double Distancia { get; }

    public Resultado(Punto q, double tOriginal, double t, double distancia)
    {
        Q = q;
        TOriginal = tOriginal;
        T = t;
        Distancia = distancia;
    }
}

public class Calculadora
{
    public Resultado Calcular(Segmento segmento, Punto p)
    {
        double dx = segmento.B.X - segmento.A.X;
        double dy = segmento.B.Y - segmento.A.Y;
        double denominador = dx * dx + dy * dy;

        if (denominador == 0)
        {
            return new Resultado(segmento.A, 0, 0, p.DistanciaA(segmento.A));
        }

        double tOriginal = ((p.X - segmento.A.X) * dx +
                            (p.Y - segmento.A.Y) * dy) / denominador;
        double t = Math.Clamp(tOriginal, 0, 1);
        Punto q = new Punto(segmento.A.X + t * dx, segmento.A.Y + t * dy);

        return new Resultado(q, tOriginal, t, p.DistanciaA(q));
    }
}
