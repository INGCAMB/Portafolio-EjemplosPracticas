using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Estos son algunos de los using que ponemos o podemos utilizar con referencias de Visual Studio
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FormaBotonConsola
{
    //Practica: Crear una forma y un boton en consola. - Medina Beltran Carlos Alberto

    //Aqui la clase ProgramaForma se hereda de la clase del formulario "Form"
    public partial class ProgramaForma : Form
    {
        //Constructor de la clase ProgramaForma
        public ProgramaForma()
        {
            InitializeComponent();
            Boton();
        }

        //Este es para especificar que la aplicacion windows forms es un contenedor 
        [STAThread]
        //
        public static void Main(string[] args)
        {
            //Aplicar estilos de sistema operativo de la aplicacion
            Application.EnableVisualStyles();
            //
            Application.SetCompatibleTextRenderingDefault(false);
            //Este sirve para correr primero la Forma "ProgramaForma"
            Application.Run(new ProgramaForma());
        }

        //Este sera el metodo para saber con que componentes empezara la forma
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // ProgramaForma
            // Atributos que se le daran a "este-this" formulario Como el nommbre y el texto de encabezado y el tamaño de la forma 
            this.ClientSize = new System.Drawing.Size(362, 261);
            this.Name = "Programa de practica 1";
            this.BackColor = Color.Aqua;
            this.Text = "Crear una forma y dentro un boton";
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        //Metodo para instaciar un boton y darle atributos al boton y poder ser utilizado dentro de el constructor de la clase ProgramaForma
        private void Boton()
        {
            //Instancia de un Button
            Button btn1 = new Button();
            //Atributos que se obtienen del button ya sea como el texto, localizacion de donde estara en la forma, el tamaño, etc
            btn1.Location = new System.Drawing.Point(100, 100);
            btn1.Size = new System.Drawing.Size(100, 50);
            btn1.Text = "Boton para empezar";
            btn1.BackColor = Color.Red;
            //Añade el control button
            this.Controls.Add(btn1);
        }
    }
}
