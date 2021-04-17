using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Diccionario : Form
    {
        //arroba--quitar los caracteres especialesc:
        string PATH = "";
        public Diccionario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImage = new OpenFileDialog();
            getImage.InitialDirectory = "C:\\";
            getImage.Filter = "Archivos de Imagen (*.png)|*png;";
            getImage.Title = "Selecciona la Factura";
            PATH = "";
            if(getImage.ShowDialog() == DialogResult.OK)
            {
                //concatenacion de la ruta del archivo hacia el path para poder ir a cortar la imagen
                PATH+= getImage.FileName;
                MessageBox.Show(getImage.SafeFileName);
                Captcha form2 = new Captcha(imagenes());
                form2.Show();
            }
            else
            {
                MessageBox.Show("No se selecciono imagen", "Sin seleccion", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }
        public Queue<Bitmap> imagenes()
        {
            //Cola-queue :v 
            Queue<Bitmap> Lista = new Queue<Bitmap>();
            int posXmin = 0, posYmin = 0, anchura = 200, altura = 100;
            //el usuario suba la imagen, toma ruta y la almacena en  path 
            Bitmap source = new Bitmap(@PATH);
            
            int alto = source.Height;
            int altoSteps = alto / 100;
           // MessageBox.Show(altoSteps.ToString()); esos dos no afectan va? xd
            //MessageBox.Show((source.Width / 200).ToString());
            //cambiar el 4 por altoSteps 
            for (int i = 0; i < 4; i++)
            {
                posXmin = 0;
                for (int j = 0; j < (source.Width / 200); j++)
                {

                    Rectangle rectOrig = new Rectangle(posXmin, posYmin, anchura, altura);

                    Bitmap CroppedImage = CropImage(source, rectOrig);
                    Lista.Enqueue(CroppedImage);

                    posXmin = 200;
                }
                posYmin += 100;
            }
            return Lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
