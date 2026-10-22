#nullable enable
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProyeccionPuntoQ;

partial class FormPasos
{
    private IContainer? components = null;
    private TableLayoutPanel contenido = null!;
    private TextBox textoProcedimiento = null!;
    private Button botonCerrar = null!;

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
        contenido = new TableLayoutPanel();
        textoProcedimiento = new TextBox();
        botonCerrar = new Button();
        contenido.SuspendLayout();
        SuspendLayout();
        // 
        // contenido
        // 
        contenido.ColumnCount = 1;
        contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        contenido.Controls.Add(textoProcedimiento, 0, 0);
        contenido.Controls.Add(botonCerrar, 0, 1);
        contenido.Dock = DockStyle.Fill;
        contenido.Location = new Point(0, 0);
        contenido.Name = "contenido";
        contenido.Padding = new Padding(12);
        contenido.RowCount = 2;
        contenido.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        contenido.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        contenido.Size = new Size(600, 460);
        contenido.TabIndex = 0;
        // 
        // textoProcedimiento
        // 
        textoProcedimiento.Dock = DockStyle.Fill;
        textoProcedimiento.Font = new Font("Consolas", 10F);
        textoProcedimiento.Location = new Point(15, 15);
        textoProcedimiento.Multiline = true;
        textoProcedimiento.Name = "textoProcedimiento";
        textoProcedimiento.ReadOnly = true;
        textoProcedimiento.ScrollBars = ScrollBars.Vertical;
        textoProcedimiento.Size = new Size(570, 386);
        textoProcedimiento.TabIndex = 0;
        // 
        // botonCerrar
        // 
        botonCerrar.DialogResult = DialogResult.OK;
        botonCerrar.Dock = DockStyle.Right;
        botonCerrar.Location = new Point(480, 407);
        botonCerrar.Name = "botonCerrar";
        botonCerrar.Size = new Size(105, 35);
        botonCerrar.TabIndex = 1;
        botonCerrar.Text = "Cerrar";
        botonCerrar.UseVisualStyleBackColor = true;
        // 
        // FormPasos
        // 
        AcceptButton = botonCerrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = botonCerrar;
        ClientSize = new Size(600, 460);
        Controls.Add(contenido);
        Font = new Font("Segoe UI", 9F);
        MinimumSize = new Size(420, 300);
        Name = "FormPasos";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Procedimiento para hallar Q";
        contenido.ResumeLayout(false);
        contenido.PerformLayout();
        ResumeLayout(false);
    }
}
