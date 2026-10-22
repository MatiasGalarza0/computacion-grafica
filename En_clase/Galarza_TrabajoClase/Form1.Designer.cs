#nullable enable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProyeccionPuntoQ;

partial class Form1
{
    private IContainer? components = null;
    private TableLayoutPanel principal = null!;
    private TableLayoutPanel contenido = null!;
    private TableLayoutPanel controles = null!;
    private TableLayoutPanel tablaPuntos = null!;
    private Label titulo = null!;
    private Label textoEntrada = null!;
    private Label etiquetaX = null!;
    private Label etiquetaY = null!;
    private Label etiquetaA = null!;
    private Label etiquetaB = null!;
    private Label etiquetaP = null!;
    private Label leyenda = null!;
    private NumericUpDown ax = null!;
    private NumericUpDown ay = null!;
    private NumericUpDown bx = null!;
    private NumericUpDown by = null!;
    private NumericUpDown px = null!;
    private NumericUpDown py = null!;
    private Panel panelPlano = null!;
    private Label etiquetaResultado = null!;
    private Button botonCalcular = null!;
    private Button botonPasos = null!;
    private Button botonLimpiar = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        principal = new TableLayoutPanel();
        contenido = new TableLayoutPanel();
        controles = new TableLayoutPanel();
        tablaPuntos = new TableLayoutPanel();
        titulo = new Label();
        textoEntrada = new Label();
        etiquetaX = new Label();
        etiquetaY = new Label();
        etiquetaA = new Label();
        etiquetaB = new Label();
        etiquetaP = new Label();
        leyenda = new Label();
        ax = new NumericUpDown();
        ay = new NumericUpDown();
        bx = new NumericUpDown();
        by = new NumericUpDown();
        px = new NumericUpDown();
        py = new NumericUpDown();
        panelPlano = new Panel();
        etiquetaResultado = new Label();
        botonCalcular = new Button();
        botonPasos = new Button();
        botonLimpiar = new Button();
        principal.SuspendLayout();
        contenido.SuspendLayout();
        controles.SuspendLayout();
        tablaPuntos.SuspendLayout();
        ((ISupportInitialize)ax).BeginInit();
        ((ISupportInitialize)ay).BeginInit();
        ((ISupportInitialize)bx).BeginInit();
        ((ISupportInitialize)by).BeginInit();
        ((ISupportInitialize)px).BeginInit();
        ((ISupportInitialize)py).BeginInit();
        SuspendLayout();
        // 
        // principal
        // 
        principal.ColumnCount = 1;
        principal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        principal.Controls.Add(titulo, 0, 0);
        principal.Controls.Add(contenido, 0, 1);
        principal.Controls.Add(etiquetaResultado, 0, 2);
        principal.Dock = DockStyle.Fill;
        principal.Location = new Point(0, 0);
        principal.Margin = new Padding(0);
        principal.Name = "principal";
        principal.Padding = new Padding(12);
        principal.RowCount = 3;
        principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        principal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        principal.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        principal.Size = new Size(970, 610);
        principal.TabIndex = 0;
        // 
        // titulo
        // 
        titulo.AutoSize = true;
        titulo.Dock = DockStyle.Fill;
        titulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        titulo.Location = new Point(15, 12);
        titulo.Margin = new Padding(3, 0, 3, 0);
        titulo.Name = "titulo";
        titulo.Size = new Size(940, 46);
        titulo.TabIndex = 0;
        titulo.Text = "Proyección del punto P sobre el segmento AB";
        titulo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // contenido
        // 
        contenido.ColumnCount = 2;
        contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 255F));
        contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contenido.Controls.Add(controles, 0, 0);
        contenido.Controls.Add(panelPlano, 1, 0);
        contenido.Dock = DockStyle.Fill;
        contenido.Location = new Point(12, 58);
        contenido.Margin = new Padding(0);
        contenido.Name = "contenido";
        contenido.RowCount = 1;
        contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        contenido.Size = new Size(946, 490);
        contenido.TabIndex = 1;
        // 
        // controles
        // 
        controles.ColumnCount = 1;
        controles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        controles.Controls.Add(textoEntrada, 0, 0);
        controles.Controls.Add(tablaPuntos, 0, 1);
        controles.Controls.Add(botonCalcular, 0, 2);
        controles.Controls.Add(botonPasos, 0, 3);
        controles.Controls.Add(botonLimpiar, 0, 4);
        controles.Controls.Add(leyenda, 0, 5);
        controles.Dock = DockStyle.Fill;
        controles.Location = new Point(0, 0);
        controles.Margin = new Padding(0, 0, 14, 0);
        controles.Name = "controles";
        controles.RowCount = 7;
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 166F));
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        controles.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
        controles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        controles.Size = new Size(241, 490);
        controles.TabIndex = 0;
        // 
        // textoEntrada
        // 
        textoEntrada.AutoSize = true;
        textoEntrada.Dock = DockStyle.Fill;
        textoEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        textoEntrada.Location = new Point(3, 0);
        textoEntrada.Name = "textoEntrada";
        textoEntrada.Size = new Size(235, 40);
        textoEntrada.TabIndex = 0;
        textoEntrada.Text = "Coordenadas enteras";
        textoEntrada.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tablaPuntos
        // 
        tablaPuntos.ColumnCount = 3;
        tablaPuntos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
        tablaPuntos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaPuntos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaPuntos.Controls.Add(etiquetaX, 1, 0);
        tablaPuntos.Controls.Add(etiquetaY, 2, 0);
        tablaPuntos.Controls.Add(etiquetaA, 0, 1);
        tablaPuntos.Controls.Add(etiquetaB, 0, 2);
        tablaPuntos.Controls.Add(etiquetaP, 0, 3);
        tablaPuntos.Controls.Add(ax, 1, 1);
        tablaPuntos.Controls.Add(ay, 2, 1);
        tablaPuntos.Controls.Add(bx, 1, 2);
        tablaPuntos.Controls.Add(by, 2, 2);
        tablaPuntos.Controls.Add(px, 1, 3);
        tablaPuntos.Controls.Add(py, 2, 3);
        tablaPuntos.Dock = DockStyle.Fill;
        tablaPuntos.Location = new Point(0, 40);
        tablaPuntos.Margin = new Padding(0);
        tablaPuntos.Name = "tablaPuntos";
        tablaPuntos.RowCount = 4;
        tablaPuntos.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tablaPuntos.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tablaPuntos.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tablaPuntos.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        tablaPuntos.Size = new Size(241, 166);
        tablaPuntos.TabIndex = 1;
        // 
        // etiquetaX
        // 
        etiquetaX.Dock = DockStyle.Fill;
        etiquetaX.Name = "etiquetaX";
        etiquetaX.Text = "X";
        etiquetaX.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // etiquetaY
        // 
        etiquetaY.Dock = DockStyle.Fill;
        etiquetaY.Name = "etiquetaY";
        etiquetaY.Text = "Y";
        etiquetaY.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // etiquetaA
        // 
        etiquetaA.Dock = DockStyle.Fill;
        etiquetaA.Name = "etiquetaA";
        etiquetaA.Text = "A";
        etiquetaA.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // etiquetaB
        // 
        etiquetaB.Dock = DockStyle.Fill;
        etiquetaB.Name = "etiquetaB";
        etiquetaB.Text = "B";
        etiquetaB.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // etiquetaP
        // 
        etiquetaP.Dock = DockStyle.Fill;
        etiquetaP.Name = "etiquetaP";
        etiquetaP.Text = "P";
        etiquetaP.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ax
        // 
        ax.DecimalPlaces = 0;
        ax.Dock = DockStyle.Fill;
        ax.Location = new Point(34, 36);
        ax.Margin = new Padding(4, 8, 4, 4);
        ax.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        ax.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        ax.Name = "ax";
        ax.Size = new Size(97, 23);
        ax.TabIndex = 0;
        ax.TextAlign = HorizontalAlignment.Center;
        ax.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // ay
        // 
        ay.DecimalPlaces = 0;
        ay.Dock = DockStyle.Fill;
        ay.Margin = new Padding(4, 8, 4, 4);
        ay.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        ay.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        ay.Name = "ay";
        ay.TabIndex = 1;
        ay.TextAlign = HorizontalAlignment.Center;
        ay.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // bx
        // 
        bx.DecimalPlaces = 0;
        bx.Dock = DockStyle.Fill;
        bx.Margin = new Padding(4, 8, 4, 4);
        bx.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        bx.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        bx.Name = "bx";
        bx.TabIndex = 2;
        bx.TextAlign = HorizontalAlignment.Center;
        bx.Value = new decimal(new int[] { 8, 0, 0, 0 });
        // 
        // by
        // 
        by.DecimalPlaces = 0;
        by.Dock = DockStyle.Fill;
        by.Margin = new Padding(4, 8, 4, 4);
        by.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        by.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        by.Name = "by";
        by.TabIndex = 3;
        by.TextAlign = HorizontalAlignment.Center;
        by.Value = new decimal(new int[] { 2, 0, 0, 0 });
        // 
        // px
        // 
        px.DecimalPlaces = 0;
        px.Dock = DockStyle.Fill;
        px.Margin = new Padding(4, 8, 4, 4);
        px.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        px.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        px.Name = "px";
        px.TabIndex = 4;
        px.TextAlign = HorizontalAlignment.Center;
        px.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // py
        // 
        py.DecimalPlaces = 0;
        py.Dock = DockStyle.Fill;
        py.Margin = new Padding(4, 8, 4, 4);
        py.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
        py.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
        py.Name = "py";
        py.TabIndex = 5;
        py.TextAlign = HorizontalAlignment.Center;
        py.Value = new decimal(new int[] { 6, 0, 0, 0 });
        // 
        // botonCalcular
        // 
        botonCalcular.Dock = DockStyle.Fill;
        botonCalcular.Location = new Point(3, 211);
        botonCalcular.Margin = new Padding(3, 5, 8, 5);
        botonCalcular.Name = "botonCalcular";
        botonCalcular.TabIndex = 2;
        botonCalcular.Text = "Calcular y graficar";
        botonCalcular.UseVisualStyleBackColor = true;
        botonCalcular.Click += botonCalcular_Click;
        // 
        // botonPasos
        // 
        botonPasos.Dock = DockStyle.Fill;
        botonPasos.Margin = new Padding(3, 5, 8, 5);
        botonPasos.Name = "botonPasos";
        botonPasos.TabIndex = 3;
        botonPasos.Text = "Ver procedimiento";
        botonPasos.UseVisualStyleBackColor = true;
        botonPasos.Click += botonPasos_Click;
        // 
        // botonLimpiar
        // 
        botonLimpiar.Dock = DockStyle.Fill;
        botonLimpiar.Margin = new Padding(3, 5, 8, 5);
        botonLimpiar.Name = "botonLimpiar";
        botonLimpiar.TabIndex = 4;
        botonLimpiar.Text = "Restablecer";
        botonLimpiar.UseVisualStyleBackColor = true;
        botonLimpiar.Click += botonLimpiar_Click;
        // 
        // leyenda
        // 
        leyenda.AutoSize = true;
        leyenda.Dock = DockStyle.Fill;
        leyenda.Location = new Point(3, 350);
        leyenda.Name = "leyenda";
        leyenda.TabIndex = 5;
        leyenda.Text = "Azul: segmento AB\r\nRojo: P–Q\r\nVerde: punto Q";
        leyenda.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // panelPlano
        // 
        panelPlano.BackColor = Color.White;
        panelPlano.BorderStyle = BorderStyle.FixedSingle;
        panelPlano.Dock = DockStyle.Fill;
        panelPlano.Location = new Point(255, 0);
        panelPlano.Margin = new Padding(0);
        panelPlano.Name = "panelPlano";
        panelPlano.Size = new Size(691, 490);
        panelPlano.TabIndex = 1;
        panelPlano.Paint += PanelPlano_Paint;
        // 
        // etiquetaResultado
        // 
        etiquetaResultado.AutoSize = true;
        etiquetaResultado.Dock = DockStyle.Fill;
        etiquetaResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        etiquetaResultado.Location = new Point(15, 548);
        etiquetaResultado.Margin = new Padding(3, 0, 3, 0);
        etiquetaResultado.Name = "etiquetaResultado";
        etiquetaResultado.TabIndex = 2;
        etiquetaResultado.Text = "Resultado";
        etiquetaResultado.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // Form1
        // 
        AcceptButton = botonCalcular;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        ClientSize = new Size(970, 610);
        Controls.Add(principal);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(820, 570);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Punto Q - Plano cartesiano";
        principal.ResumeLayout(false);
        principal.PerformLayout();
        contenido.ResumeLayout(false);
        controles.ResumeLayout(false);
        controles.PerformLayout();
        tablaPuntos.ResumeLayout(false);
        ((ISupportInitialize)ax).EndInit();
        ((ISupportInitialize)ay).EndInit();
        ((ISupportInitialize)bx).EndInit();
        ((ISupportInitialize)by).EndInit();
        ((ISupportInitialize)px).EndInit();
        ((ISupportInitialize)py).EndInit();
        ResumeLayout(false);
    }
}
