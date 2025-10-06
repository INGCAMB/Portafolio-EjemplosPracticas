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

namespace P3_MedinaBeltran
{
    //Practica: Esta oscasión el boton cuando choque con las paredes tendra que hacer funciones diferente en cada pared del formulario - Medina Beltran Carlos Alberto

    //Aqui la clase ProgramaForma se hereda de la clase del formulario "Form"
    public partial class ProgramaForma : Form
    {
        //Instancia de un Button
        Button btn1 = new Button();
        //Instancia de un Timer
        Timer Tiempo = new Timer();
        //Instancia de un PictureBox
        PictureBox pb1 = new PictureBox();

        //Valores de cordenadas en las cuales se desplazara
        int X = -10, Y = 10;

        //Constructor de la clase ProgramaForma
        public ProgramaForma()
        {
            InitializeComponent();
            Boton();
            Imagen();
            //Habilitado el tiempo
            Tiempo.Enabled = true;
            //Interavalo de tiempo
            Tiempo.Interval = 50;
            //Concatena el tick para usar metodos en el tiempo
            Tiempo.Tick += new EventHandler(Tiempo_Tick);
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

        //Es la herramienta tiempo_click para hacer movimientos
        private void Tiempo_Tick(object sender, EventArgs e)
        {
            //X es horizontal
            btn1.Left += X;
            //Y es vertical
            btn1.Top += Y;

            //If Para el lado izquierdo 
            if (btn1.Left <= 0) 
            {
                X = -X;
                this.BackColor = Color.Gray;
                btn1.BackColor = Color.Red;
                btn1.Text = "Boton";
                pb1.Visible = false;

            }
            //If Para el lado derecho
            if ((btn1.Width + btn1.Left) >= (this.Width - 10))  
            {
                X = -X;
                pb1.Visible = true;
            }
            //If Para el lado de arriba o superior
            if (btn1.Top <= 0)  
            {
                Y = -Y;
                this.BackColor = Color.Blue;
                btn1.BackColor = Color.Yellow;
            }
            //If Para el lado de abajo o inferior
            if ((btn1.Top + btn1.Height) >= (this.Height - 20))    
            {
                Y = -Y;
                btn1.Text = "Hola mundo cruel";
                this.BackColor = Color.Green;
            }
        }

        //Este sera el metodo para saber con que componentes empezara la forma
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProgramaForma
            // 
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(362, 261);
            this.Name = "ProgramaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear una forma y dentro un boton";
            this.ResumeLayout(false);

        }

        //Metodo para instaciar un boton y darle atributos al boton y poder ser utilizado dentro de el constructor de la clase ProgramaForma
        private void Boton()
        {
            //Atributos que se obtienen del button ya sea como el texto, localizacion de donde estara en la forma, el tamaño, etc
            btn1.Location = new System.Drawing.Point(100, 100);
            btn1.Size = new System.Drawing.Size(100, 50);
            btn1.Text = "Boton para empezar";
            btn1.BackColor = Color.Red;
            //Añade el control button
            this.Controls.Add(btn1);
        }

        //Metodo para instaciar una caja de imagen y darle atributos y poder ser utilizado dentro de el constructor de la clase ProgramaForma
        private void Imagen()
        {
            //Atributos que se obtienen del picturebox ya sea como el texto, localizacion de donde estara en la forma, el tamaño, etc
            pb1.Size = new Size(100, 100);
            pb1.BackgroundImageLayout = ImageLayout.Center;
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.Location = new Point(50, 50);
            pb1.BackColor = Color.White;
            pb1.Image = Properties.Resources.CaritasFelices;
            pb1.Refresh();
            pb1.Visible = true;
            //Añade el control button
            this.Controls.Add(pb1);
        }
    }
}
