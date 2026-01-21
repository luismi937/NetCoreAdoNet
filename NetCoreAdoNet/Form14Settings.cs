using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form14Settings : Form
    {
        public Form14Settings()
        {
            InitializeComponent();
        }


        private void btnLeerSettings_Click(object sender, EventArgs e)
        {
            //necesitamos un constructor de configuraciones
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //en este entorno de proyecto, SEttings no es nativo, a pesar de llamarlo
            //appsetings.json no lo reconoce, debemos de inddicar la ubicacion del fichero y el nombre
            builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);
            //necesitamos el objeto para configurar las keys 
            IConfigurationRoot configuration = builder.Build();
            //existen keys ya configuradas y podemos recuperarlas con metodos nativos 
            //las keys diferencian mayusculas y minusculas
            string cadena = configuration.GetConnectionString("SqlLocalTajamar");
            this.lblConexion.Text = cadena;
            //si no son keys conocidas, debemos navegar hasta ellas
            //la navegacion entre keys se estblece mediante
            //KeyPrincipal:SubKey
            //KeyPrincipal:SubKey:SubSubKey
            string imagen1 = configuration.GetSection("Imagenes:imcagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imcagen2").Value;
            string colorLetra = configuration.GetSection("Colores:Letra").Value;
            string colorFondo = configuration.GetSection("Colores:Fondo").Value;
            this.pictureBox1.Image = Image.FromFile(imagen1);
            this.pictureBox2.Image = Image.FromFile(imagen2);
            this.BackColor = Color.FromName(colorFondo);
            this.btnLeerSettings.ForeColor = Color.FromName(colorLetra);


        }
        private void btnLeerHelperClick(object sender, EventArgs e)
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();
            //existen keys ya configuradas y podemos recuperarlas con metodos nativos 
            //las keys diferencian mayusculas y minusculas
            string cadena = configuration.GetConnectionString("SqlLocalTajamar");
            this.lblConexion.Text = cadena;
            //si no son keys conocidas, debemos navegar hasta ellas
            //la navegacion entre keys se estblece mediante
            //KeyPrincipal:SubKey
            //KeyPrincipal:SubKey:SubSubKey
            string imagen1 = configuration.GetSection("Imagenes:imcagen1").Value;
            string imagen2 = configuration.GetSection("Imagenes:imcagen2").Value;
            string colorLetra = configuration.GetSection("Colores:Letra").Value;
            string colorFondo = configuration.GetSection("Colores:Fondo").Value;
            this.pictureBox1.Image = Image.FromFile(imagen1);
            this.pictureBox2.Image = Image.FromFile(imagen2);
            this.BackColor = Color.FromName(colorFondo);
            this.btnLeerSettings.ForeColor = Color.FromName(colorLetra);


        }
    }
}
