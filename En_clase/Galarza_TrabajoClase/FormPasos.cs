using System;
using System.Windows.Forms;

namespace ProyeccionPuntoQ;

public partial class FormPasos : Form
{
    public FormPasos()
    {
        InitializeComponent();
    }

    public FormPasos(Segmento s, Punto p, Resultado r) : this()
    {
        double dx = s.B.X - s.A.X;
        double dy = s.B.Y - s.A.Y;
        double apx = p.X - s.A.X;
        double apy = p.Y - s.A.Y;
        double denominador = dx * dx + dy * dy;

        if (denominador == 0)
        {
            textoProcedimiento.Text =
                "A y B coinciden: el segmento es un solo punto." + Environment.NewLine +
                $"Q = A = ({s.A.X:0}, {s.A.Y:0})" + Environment.NewLine +
                $"Distancia P-Q = {r.Distancia:0.###}";
            return;
        }

        textoProcedimiento.Text =
            $"A = ({s.A.X:0}, {s.A.Y:0})    B = ({s.B.X:0}, {s.B.Y:0})    P = ({p.X:0}, {p.Y:0})\r\n\r\n" +
            "1) Hallar los vectores:\r\n" +
            $"AB = B - A = ({dx:0}, {dy:0})\r\n" +
            $"AP = P - A = ({apx:0}, {apy:0})\r\n\r\n" +
            "2) Calcular la proyección:\r\n" +
            "t = (AP · AB) / (AB · AB)\r\n" +
            $"t = ({apx:0} × {dx:0} + {apy:0} × {dy:0}) / ({dx:0}² + {dy:0}²)\r\n" +
            $"t = {r.TOriginal:0.###}\r\n\r\n" +
            "3) Limitar t al segmento [0, 1]:\r\n" +
            $"t utilizado = {r.T:0.###}\r\n\r\n" +
            "4) Encontrar el punto Q:\r\n" +
            "Q = A + t · AB\r\n" +
            $"Qx = {s.A.X:0} + {r.T:0.###} × {dx:0} = {r.Q.X:0.###}\r\n" +
            $"Qy = {s.A.Y:0} + {r.T:0.###} × {dy:0} = {r.Q.Y:0.###}\r\n\r\n" +
            "5) Distancia mínima entre P y el segmento:\r\n" +
            $"d = √((Px - Qx)² + (Py - Qy)²) = {r.Distancia:0.###}\r\n\r\n" +
            "Nota: si t se limita a 0 o 1, Q queda en un extremo del segmento.";
    }
}
