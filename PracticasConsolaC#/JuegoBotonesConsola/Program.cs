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

namespace JuegoBotonesConsola
{
    //Practica: Crear dinamica para que un tipo de boton se impar otro sean par, asi mismo hacia la izquierda se pierden unos a la derecha otros arriba se crean mas de un tipo hacia abajo se crean de otro tipo y si chocan pueden crearse mas dependiendo de si son par o impar - Medina Beltran Carlos Alberto

    //Aqui la clase ProgramaForma se hereda de la clase del formulario "Form"
    public partial class ProgramaForma : Form
    {
        //Instancia de un Timer
        Timer Tiempo = new Timer();

        //Instacia de un elemento Random
        Random ale = new Random();

        //Listas de botones una para impares y otra para pares
        List<Botones> btnImpar = new List<Botones>();
        List<Botones> btnPar = new List<Botones>();

        //Contadores para Par e Impar
        int contimpar = 0, contpar = 0;

        //Constructor de la clase ProgramaForma
        public ProgramaForma()
        {
            //Metodos que mandamos a llamar
            InitializeComponent();
            crearbotonImpar();
            crearbotonPar();

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

        //Este sera el metodo para saber con que componentes empezara la forma
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProgramaForma
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Name = "ProgramaForma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear una forma y dentro un btn";
            this.ResumeLayout(false);

        }

        //Es la herramienta tiempo_click para hacer movimientos
        private void Tiempo_Tick(object sender, EventArgs e)
        {
            //Ciclo for desde la posicion 0 hasta que sea menor que el numero total de elementos en la listaImpar
            for (int i = 0; i < btnImpar.Count; i++)
            {
                //Mandas como parametro a boton impar junto con la posicion que vaya en el ciclo
                movimiento(btnImpar, i);
                ChoqueBotonImparImpar(btnImpar, i);
            }
            //Ciclo for desde la posicion 0 hasta que sea menor que el numero total de elementos en la listaPar
            for (int i = 0; i < btnPar.Count; i++)
            {
                //Mandas como parametro a boton par junto con la posicion que vaya en el ciclo
                movimiento(btnPar, i);
                ChoqueBotonParPar(btnPar, i);
            }
            ChoqueBotonImparPar(btnImpar, btnPar);
        }

        //Metodo para crear el boton impar
        public void crearbotonImpar()
        {
            //Variables X y Y que seran numero random para la posicion sea en cualquier lugar de la forma
            int x = ale.Next(0, this.Width - 100);
            int y = ale.Next(0, this.Height - 100);

            //Añade un boton a la lista de botones Impares y se le manda el parametro 1 para decir que es impar
            btnImpar.Add(new Botones(1));
            //Localización que tendra el boton que se añade
            btnImpar[contimpar].btn.Location = new Point(x, y);
            btnImpar[contimpar].btn.BackColor = Color.Blue;
            //Añade boton a la forma
            this.Controls.Add(btnImpar[contimpar].btn);
            //Aumenta el contador mas uno en los impares
            contimpar++;
        }

        //Metodo para crear el boton par
        public void crearbotonPar()
        {
            //Variables X y Y que seran numero random para la posicion sea en cualquier lugar de la forma
            int x = ale.Next(0, this.Width - 100);
            int y = ale.Next(0, this.Height - 100);

            //Añade un boton a la lista de botones Pares
            btnPar.Add(new Botones(2));
            //Localización que tendra el boton que se añade
            btnPar[contpar].btn.Location = new Point(x, y);
            btnPar[contpar].btn.BackColor = Color.Green;
            //Añade boton a la forma
            this.Controls.Add(btnPar[contpar].btn);
            //Aumenta el contador mas uno en los pares
            contpar++;
        }

        public void movimiento(List<Botones> btn, int cont)
        {
            //Si el boton es color rojo entrara a este if
            if (btn[cont].btn.BackColor == Color.Red)
            {
                //Remueve el boton que esta en esta posicion en movimiento en la forma
                Controls.Remove(btn[cont].btn);
                //Sacar el residuo si es 1 es impar si no es par
                if (btn[cont].Num % 2 == 1)
                {
                    contimpar--;
                }
                else
                {
                    contpar--;
                }
                //Quita el elemento situado en dicha posicion
                btn.RemoveAt(cont);
                //Retorna
                return;
            }

            //Concatenas la posicion de los botones en X y Y
            btn[cont].btn.Left += btn[cont].X;
            btn[cont].btn.Top += btn[cont].Y;

            //If Para el lado izquierdo 
            if (btn[cont].btn.Left <= 0) 
            {
                //Para cambiar la direccion del boton en X
                btn[cont].X *= -1;

                //Este If es para decir: Si el residuo es igual a 1 entonces el boton impar se volvera color rojo
                if (btn[cont].Num % 2 == 1)
                {
                    btn[cont].btn.BackColor = Color.Red;
                }
            }
            //If Para el lado derecho
            if ((btn[cont].btn.Width + btn[cont].btn.Left) >= (this.Width - 15))  
            {
                //Para cambiar la direccion del boton en X
                btn[cont].X *= -1;

                //Este If es para decir: Si el residuo es igual a 0 entonces el boton par se volvera color rojo
                if (btn[cont].Num % 2 == 0)
                {
                    btn[cont].btn.BackColor = Color.Red;
                }
            }
            //If Para el lado de arriba o superior
            if (btn[cont].btn.Top <= 0) 
            {
                //Para cambiar la direccion del boton en Y
                btn[cont].Y *= -1;
                if (btn[cont].Num % 2 == 1)
                {
                    crearbotonImpar();
                }
            }
            //If Para el lado de abajo o inferior
            if ((btn[cont].btn.Top + btn[cont].btn.Height) >= (this.Height - 35))
            { 
                //Para cambiar la direccion del boton en Y
                btn[cont].Y *= -1;
                if (btn[cont].Num % 2 == 0)
                {
                    crearbotonPar();
                }
            }
        }

        //Metodo para choque entre Impar y Impar el primer parametro es para el primer boton impar
        public void ChoqueBotonImparImpar(List<Botones> btn, int cont)
        {
            for (int i = 0; i < btn.Count; i++)
            {
                if (i >= btn.Count || cont >= btn.Count)
                {
                    return;
                }
                if (btn[i].btn.Right >= btn[cont].btn.Left && btn[i].btn.Left <= btn[cont].btn.Right && cont != i && btn[i].btn.Bottom >= btn[cont].btn.Top && btn[i].btn.Top <= btn[cont].btn.Bottom)
                {
                    if (btn[i].X != btn[cont].X)
                    {
                        btn[cont].X *= -1;
                        btn[i].X *= -1;
                    }
                    if (btn[i].Y != btn[cont].Y)
                    {
                        btn[cont].Y *= -1;
                        btn[i].Y *= -1;
                    }
                    crearcantidadBotones(1, i, cont);
                }
            }
        }

        //Metodo para choque entre Par y Par el primer parametro es para el primer boton par
        public void ChoqueBotonParPar(List<Botones> btn, int cont)
        {
            for (int i = 0; i < btn.Count; i++)
            {
                if (i >= btn.Count || cont >= btn.Count)
                {
                    return;
                }
                if (btn[i].btn.Right >= btn[cont].btn.Left && btn[i].btn.Left <= btn[cont].btn.Right && cont != i && btn[i].btn.Bottom >= btn[cont].btn.Top && btn[i].btn.Top <= btn[cont].btn.Bottom)
                {
                    if (btn[i].X != btn[cont].X)
                    {
                        btn[cont].X *= -1;
                        btn[i].X *= -1;
                    }
                    if (btn[i].Y != btn[cont].Y)
                    {
                        btn[cont].Y *= -1;
                        btn[i].Y *= -1;
                    }
                    crearcantidadBotones(2, i, cont);
                }
            }
        }
       
        //Metodo para choque entre Impar y Par el primer parametro es para impar y el segundo para par
        public void ChoqueBotonImparPar(List<Botones> btn, List<Botones> btn2)
        {
            for (int i = 0; i < btnImpar.Count; i++)
            {
                if (i >= btn.Count)
                {
                    return;
                }

                for (int j = 0; j < btnPar.Count; j++)
                {
                    if (j >= btn2.Count)
                    {
                        return;
                    }

                    if (btn[i].btn.Right >= btn2[j].btn.Left && btn[i].btn.Left <= btn2[j].btn.Right && btn[i].btn.Bottom >= btn2[j].btn.Top && btn[i].btn.Top <= btn2[j].btn.Bottom)
                    {
                        if (btn[i].X != btn2[j].X)
                        {
                            btn2[j].X *= -1;
                            btn[i].X *= -1;
                        }
                        if (btn[i].Y != btn2[j].Y)
                        {
                            btn2[j].Y *= -1;
                            btn[i].Y *= -1;
                        }
                       //crearcantidadBotonesMayorMenor(btn, i, btn2,  j);
                       //break;
                    }
                }
            }
        }

        public void crearcantidadBotones(int opc, int i, int cont)
        {
            if (opc == 1)
            {
                i = btnImpar.ElementAt(i).Num;
                cont = btnImpar.ElementAt(cont).Num;
                if (btnImpar.Count < 10)
                {
                    for (int j = 0; j < (i + cont); j++)
                    {
                        int x = ale.Next(0, this.Width - 100);
                        int y = ale.Next(0, this.Height - 100);

                        btnImpar.Add(new Botones(1));
                        btnImpar[contimpar].btn.Location = new Point(x, y);
                        btnImpar[contimpar].btn.BackColor = Color.Blue;
                        Controls.Add(btnImpar[contimpar].btn);
                        contimpar++;
                    }
                }
            }
            else if (opc == 2)
            {
                i = btnPar.ElementAt(i).Num;
                cont = btnPar.ElementAt(cont).Num;
                if (btnPar.Count < 10)
                {
                    for (int j = 0; j < (i + cont); j++)
                    {
                        int x = ale.Next(0, this.Width - 100);
                        int y = ale.Next(0, this.Height - 100);

                        btnPar.Add(new Botones(2));
                        btnPar[contpar].btn.Location = new Point(x, y);
                        btnPar[contpar].btn.BackColor = Color.Green;
                        Controls.Add(btnPar[contpar].btn);
                        contpar++;
                    }
                }
            }
            opc = 0;
        }

        public void crearcantidadBotonesMayorMenor(List<Botones> btn, int cont, List<Botones> btn2, int cont2)
        {
            //Si el par es mayor que el impar entra al "SI"
            if (btn2[cont2].Num > btn[cont].Num)
            {
                int Num = btn[cont].Num;
                btn[cont].btn.BackColor = Color.Red;
                Controls.Remove(btn[cont].btn);
                btn.RemoveAt(cont);
                contimpar--;
                if (btnImpar.Count > Num)
                {
                    for (int i = 0; i < Num-1; i++)
                    {
                        btn[i].btn.BackColor = Color.Red;
                        Controls.Remove(btn[i].btn);
                        btn.RemoveAt(i);
                        contimpar--;
                    }
                }
                else
                {
                    for (int i = 0; i < btnImpar.Count; i++)
                    {
                        btn[i].btn.BackColor = Color.Red;
                        Controls.Remove(btn[i].btn);
                        btn.RemoveAt(i);
                        contimpar--;
                    }
                }
            }
            else
            {
                int Num = btn2[cont2].Num;
                btn2[cont2].btn.BackColor = Color.Red;
                Controls.Remove(btn2[cont2].btn);
                btn2.RemoveAt(cont2);
                contpar--;
                if (btnPar.Count > Num)
                {
                    for (int i = 0; i < Num-1; i++)
                    {
                        btn2[i].btn.BackColor = Color.Red;
                        Controls.Remove(btn[i].btn);
                        btn2.RemoveAt(i); 
                        contpar--;
                    }
                }
                else
                {
                    for (int i = 0; i < btnImpar.Count; i++)
                    {
                        btn2[i].btn.BackColor = Color.Red;
                        Controls.Remove(btn2[i].btn);
                        btn2.RemoveAt(i);
                        contpar--;
                    }
                }
            }
        }

        //Clase de botones
        public class Botones
        {
            //Instanciar botones
            public Button btn = new Button();
            //Numero que contendra como texto
            public int Num;
            //Instaciar Random 
            public Random random = new Random();
            //Coordenadas X y Y
            public int X = 5, Y = 5;
            int[] pares = new int[4] { 2, 4, 6, 8 };
            int[] impares = new int[5] { 1, 3, 5, 7, 9 };

            public Botones(int contador)
            {
                //Tamaño de boton
                btn.Size = new Size(50, 30);
                btn.Font = new Font(new FontFamily("Arial"), 12);
                btn.ForeColor = Color.White;

                //If para saber si el boton es Par
                if (contador == 1)
                {
                    //Para saber si el boton tiene residuo si no tiene y es 0 se pondra un numero random Par(2,4,6,8)
                    /*while (Num < 1 || Num % 2 == 0)
                    {
                        Num = random.Next(1, 9);
                    }*/
                    Num = impares[random.Next(0, 5)];
                    //Asignamos el numero al nombre(Texto) del boton
                    btn.Text = Num.ToString();
                }
                //else para de indicar que es Impar
                if(contador == 2)
                {
                    //Para saber si el boton tiene residuo si tiene y es 1 se pondra un numero random Impar (1,3,5,7,9)
                    /*while (Num < 1 || Num % 2 == 1)
                    {
                        Num = random.Next(1, 10);
                    }*/
                    Num = pares[random.Next(0, 4)];
                    //Asignamos el numero al nombre(Texto) del boton
                    btn.Text = Num.ToString();
                }

                //Es para darle direccion random a los botones tanto en X xomo en Y
                if (random.Next(1, 3) > 1)
                {
                    X = -X;
                }
                if (random.Next(1, 3) > 1)
                {
                    Y = -Y;
                }
            }

        }
    }
}
