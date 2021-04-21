using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
namespace Presentacion
{
    public partial class Captcha : Form
    {
        
        
        string palabra_inicial="",palabra="",palabraConfirmada="",palabraIngresadaConfirmada="";
        //para los 3 intentos sistema
        int intentos=3,aleatorio=0,FragmentosMostrados=0;
        System.Collections.Hashtable palabras_confirmadas = new System.Collections.Hashtable();
        //Dictionary<int, string> palabras_confirmadas = new Dictionary<int, string>();
            //guid=para que los archivos no sean iguales, segundos y fechas xd
        Queue<Bitmap> Fragmentos2 = new Queue<Bitmap>();
        ArrayList FragmentosConfirmados = new ArrayList();
                
        //recibir cola con todos los fragmentos
        public Captcha(Queue<Bitmap>Fragmentos,string NombreIMG)
        {

            InitializeComponent();

            //CARGA LOS DATOS
            CargarDatos();


            //GENERA IMAGENES DE EL ARRAY DE PALABRAS CONFIRMADAS
            GenerarImagenes();
            //global para usarlo en eventos
            Fragmentos2 = Fragmentos;
            //establecer primer fragmento de la cola en el pb_noconfirmado
            pb_noconfirmado.Image = Fragmentos2.Dequeue();
            aleatorio = numerosAleatorios();
            pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
            FragmentosMostrados++;
            this.txt_noconfirmado.Focus();
            //ESCRIBE EL NOMBRE DE LA IMAGEN COMO NOMBRE DE LA FACTURA
            EscribirNombreDeFactura(NombreIMG);


            //SE DA TAMAÑO A LA BARRA DE PROGRESO
            progressBar1.Maximum = (Fragmentos.Count-1)*3;
            progressBar1.Value = 0;
            progressBar1.Visible = false;

        }

        //CARGA LOS DATOS DEL ARCHIVO PALABRAS CONFIRMADAS PARA AGREGARLO AL HASHTABLE 

        private void CargarDatos()
        {
           
            TextReader sr = new StreamReader("PalabrasConfirmadas.txt");
            string Keys = "",Values="";
            Keys = sr.ReadLine();
            Values = sr.ReadLine();
            while (Keys!=null)
            {
                palabras_confirmadas.Add(int.Parse(Keys), Values);
                Keys = sr.ReadLine();
                Values = sr.ReadLine();
            }
            sr.Close();
        }

        //Numeros Aleatorios para obtener una imagen aleatoria segun la posicion en el arrayList
        private int numerosAleatorios()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 6));

            var random = new Random(seed);
            var value = random.Next(1,cantidadPalabrasConfirmadas());
            return value;
        }
        //Sabes cuantas palabras hay en el hashTable
        private int cantidadPalabrasConfirmadas()
        {
            return palabras_confirmadas.Count;
        }
        //GENERA IMAGGENES APARTIR DE LAS PALABRAS CONFIRMADAS
        private void GenerarImagenes()
        {
            FragmentosConfirmados.Clear();
            for (int i=1;i<= palabras_confirmadas.Count;i++)
            {
                //CREAMOS EL OBJETO IMAGEN
                Bitmap objBmp = new Bitmap(1, 1);
                int Width = 0;
                int Height = 0;
                //LE DAMOS EL FORMATO DE LA FUENTE
                Font objFont = new Font("Arial", 20, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

                Graphics objGraphics = Graphics.FromImage(objBmp);

                Width = (int)objGraphics.MeasureString(palabras_confirmadas[i].ToString(), objFont).Width;
                Height = (int)objGraphics.MeasureString(palabras_confirmadas[i].ToString(), objFont).Height;

                objBmp = new Bitmap(objBmp, new Size(Width, Height));

                objGraphics = Graphics.FromImage(objBmp);

                objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                objGraphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                objGraphics.DrawString(palabras_confirmadas[i].ToString(), objFont, new SolidBrush(Color.FromArgb(102, 102, 102)), 0, 0);
                objGraphics.Flush();
                FragmentosConfirmados.Add(objBmp);
            }
        }

        //Genera los datos de palabras confirmadas si el archivo no existe
        


        private void btn_comprobar_Click(object sender, EventArgs e)
        {
            //comprobacion 
            //es como joptionpane, dialogo de confirmacion de si y nop
            DialogResult dialogResult;
            string confirmadaPalabra = "";
            confirmadaPalabra = palabras_confirmadas[aleatorio + 1].ToString();
            MessageBox.Show(confirmadaPalabra);
            dialogResult = MessageBox.Show("Es esta la palabra que desea confirmar?..." + txt_noconfirmado.Text + " Y " + txt_confirmado.Text, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        if(dialogResult == DialogResult.Yes) { 
            if (intentos == 3)//pimer ntento
            {
                palabra_inicial = "";
                palabra_inicial = txt_noconfirmado.Text;
                txt_noconfirmado.Text = "";

                if (confirmadaPalabra.Equals(txt_confirmado.Text))
                {
                        txt_confirmado.Text = "";
                        intentos--;
                    this.txt_noconfirmado.Focus();
                    aleatorio = numerosAleatorios();
                    this.pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
                    this.Invoke(new Action(() => {
                        pb_confirmado.Refresh();
                    }));
                        lblErrorMessagge.Visible = false;
                    }
                else
                {
                        aleatorio = numerosAleatorios();
                        this.pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
                        this.Invoke(new Action(() => {
                            pb_confirmado.Refresh();
                        }));
                        txt_confirmado.Text = "";
                        msgError("Error... las palabras no coinciden, Inicie nuevamente 1");
                        


                        intentos = 3;
                }


            }else


            //cuando ya no sea la primer palabra confirmadaxd
            if (intentos >= 0 && intentos<3)//si es la palabra que deseamos ingresar, segundo o tercer intento
            {
                palabra = "";
                palabra = txt_noconfirmado.Text;
                txt_noconfirmado.Text = "";
                
                this.txt_noconfirmado.Focus();
                aleatorio = numerosAleatorios();
                this.pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
                this.Invoke(new Action(() => {
                    pb_confirmado.Refresh();
                }));
                if (palabra_inicial.Equals(palabra) && confirmadaPalabra.Equals(txt_confirmado.Text))
                {
                        lblErrorMessagge.Visible = false;
                        txt_confirmado.Text = "";
                        intentos--;
                }
                else
                {
                        txt_confirmado.Text = "";
                        msgError("Error... las palabras no coinciden, Inicie nuevamente ");

                    intentos = 3;
                }

            }
        }//Si preciona que no 
            else
            {
                aleatorio = numerosAleatorios();
                this.pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
                this.Invoke(new Action(() => {
                    pb_confirmado.Refresh();
                }));
                txt_noconfirmado.Text = "";
                txt_confirmado.Text = "";

            }

                if (intentos == 0)//termina de confirmar palabra
                {
                lblErrorMessagge.Visible = false;
                this.txt_noconfirmado.Focus();
                string mensaje="";
                    MessageBox.Show("Palabra confirmada");
                int KeyNueva = 0;
                KeyNueva = Keys();
                palabras_confirmadas.Add(KeyNueva, palabra_inicial) ;
                Actualizar(KeyNueva, palabra_inicial);
                EscribirFactura(FragmentosMostrados,palabra_inicial);
                FragmentosMostrados++;
                    for (int i=1;i<=palabras_confirmadas.Count;i++)
                    {
                        mensaje += "\n"+palabras_confirmadas[i].ToString();
                    }
                MessageBox.Show(mensaje);
                GenerarImagenes();
                if (Fragmentos2.Count!=0)
                    {
                        this.pb_noconfirmado.Image = Fragmentos2.Dequeue();
                    aleatorio = numerosAleatorios();
                    this.pb_confirmado.Image = (Image)FragmentosConfirmados[aleatorio];
                    this.Invoke(new Action(() => {
                            pb_noconfirmado.Refresh();
                        pb_confirmado.Refresh();
                        }));
                    progressBar1.Value += 1;
                    //se regresan los intentos por cada nueva palabra
                    intentos = 3;
                    }
                    else
                    {
                    EscribirFacturaSeparador();
                        //cerrar formulario actual
                        this.Close();
                    }
                }
         
            
           
            
        }
        //ESCRIBE LA FACTURA SEGUN LAS PALABRAS QUE SE VAN CONFIRMANDO
        private void EscribirFactura(int fragmentosMostrados, string palabra_inicial)
        {
            TextWriter sw = new StreamWriter("Facturas.txt",true);
            if (fragmentosMostrados == 1)
            {
                sw.Write("NIT: "+palabra_inicial + '\t' + '\t' + '\t');
            }
            else if(fragmentosMostrados == 2)
            {
                sw.WriteLine("Fecha: " + palabra_inicial);
            }
            else if (fragmentosMostrados%2==0)
            {
                sw.WriteLine("Cantidad: " + palabra_inicial);
            }
            else
            {
                sw.Write("Producto: " + palabra_inicial+'\t'+'\t'+'\t');
            }
            sw.Close();
        }


        //MINIMIZA EL FORM
        private void btnminimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //ESCRIBE UN SEPARADOR SENCILLO PARA MEJORAR LA LECTURA DE CADA FACTURA EN EL MONITOR
        private void EscribirFacturaSeparador()
        {
            TextWriter sw = new StreamWriter("Facturas.txt", true);
            
            
                sw.WriteLine("=======================================");
           
            sw.Close();
        }
        //QUITA LA EXTENSION DE LA IMAGEN Y ESCRIBE SOLO EL NOMBRE COMO NOMBRE DE FACTURA
        private void EscribirNombreDeFactura(string Nombre)
        {
            char[] delimiterChars = { '.' };
            //img.png->nombre[0]=img;nombre[1]=png;
            string[] nombre = Nombre.Split(delimiterChars);
            TextWriter sw = new StreamWriter("Facturas.txt", true);


            sw.WriteLine("Factura: "+nombre[0]);

            sw.Close();
        }
        //GENERADOR DE LLAVES PARA LAS PALABRAS CONFIRMADAS
        private int Keys()
        {
            return palabras_confirmadas.Count + 1;
            
        }
        //ACTUALIZA EL ARCHIVO DE PALABRAS CONFIRMADAS
        private void Actualizar(int keyConfirmada,string valueConfirmado)
        {
            TextWriter sw = new StreamWriter("PalabrasConfirmadas.txt", true);
            sw.WriteLine(keyConfirmada);
            sw.WriteLine(valueConfirmado);
            sw.Close();
        }
        //MUESTRA UN ERROR 
        private void msgError(string msg)
        {
            lblErrorMessagge.Text = "      " + msg;
            lblErrorMessagge.Visible = true;
            
        }
    }
}
