using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Universidades_y_Personas
{
    public partial class _Default : Page
    {
        static List<Universidades> unis = new List<Universidades>();
        static List<Alumnos> al = new List<Alumnos>();
        static List<Profesores> prof = new List<Profesores>();
        static List<PersonalAd> pers = new List<PersonalAd>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string archivo = Server.MapPath("UniversidadesP.json");
                StreamReader jsonStream = File.OpenText(archivo);
                string json = jsonStream.ReadToEnd(); jsonStream.Close();
                if (json.Length > 0)
                    unis = JsonConvert.DeserializeObject<List<Universidades>>(json);
            }
        }

        void borrartodo()
        {
            carneal_lb.Visible = false;
            finallab_lb.Visible = false;
            id_lb.Visible = false;
            igss_lb.Visible = false;
            iniciolab_lb.Visible = false;
            profesion_lb.Visible = false;
            titulo_lb.Visible = false;
            carneal_txt.Visible = false;
            id_txt.Visible = false;
            igss_txt.Visible = false;
            profesion_txt.Visible = false;
            titulo_txt.Visible = false;
            finallab_cd.Visible = false;
            iniciolab_cd.Visible = false;
            alumno_bt.Visible = false;
            personal_bt.Visible = false;
            profesor_bt.Visible = false;
        }
        void vaciar()
        {
            nombreA_txt.Text = "";
            apellidoA_txt.Text = "";
            direccionA_txt.Text = "";
            Calendar1.SelectedDate = DateTime.Parse("1999-01-01T00:00:00");
            carneal_txt.Text = "";
            id_txt.Text = "";
            igss_txt.Text = "";
            profesion_txt.Text = "";
            titulo_txt.Text = "";
            iniciolab_cd.SelectedDate = DateTime.Today;
            finallab_cd.SelectedDate = DateTime.Today;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            persona_lb.Text = "Datos de Alumno:";
            borrartodo();
            carneal_lb.Visible = true;
            carneal_txt.Visible = true;
            alumno_bt.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            persona_lb.Text = "Datos de Profesor:";
            borrartodo();
            id_lb.Visible = true;
            id_txt.Visible = true;
            titulo_lb.Visible = true;
            titulo_txt.Visible = true;
            profesor_bt.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            persona_lb.Text = "Datos de Personal:";
            borrartodo();
            igss_lb.Visible = true;
            igss_txt.Visible = true;
            profesion_lb.Visible = true;
            profesion_txt.Visible = true;
            iniciolab_cd.Visible = true;
            iniciolab_lb.Visible = true;
            finallab_cd.Visible = true;
            finallab_lb.Visible = true;
            personal_bt.Visible = true;
        }
        private void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(unis);
            string archivo = Server.MapPath("UniversidadesP.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        protected void alumno_bt_Click(object sender, EventArgs e)
        {
            Universidades u = unis.Find(p => p.Universidad == uni_txt.Text);
            if (u!=null)
                al = u.Alumno;
            Alumnos estudiante = new Alumnos();
            estudiante.Nombre = nombreA_txt.Text;
            estudiante.Apellido = apellidoA_txt.Text;
            estudiante.Direccion = direccionA_txt.Text;
            estudiante.Fechanac = Calendar1.SelectedDate;
            estudiante.Carne = carneal_txt.Text;

            al.Add(estudiante);
            vaciar();
        }

        protected void profesor_bt_Click(object sender, EventArgs e)
        {
            Universidades u = unis.Find(p => p.Universidad == uni_txt.Text);
            if (u!=null)
                prof = u.Profesor;
            Profesores estudiante = new Profesores();
            estudiante.Nombre = nombreA_txt.Text;
            estudiante.Apellido = apellidoA_txt.Text;
            estudiante.Direccion = direccionA_txt.Text;
            estudiante.Fechanac = Calendar1.SelectedDate;
            estudiante.Id = id_txt.Text;
            estudiante.Titulo = titulo_txt.Text;

            prof.Add(estudiante);
            vaciar();
        }

        protected void personal_bt_Click(object sender, EventArgs e)
        {
            Universidades u = unis.Find(p => p.Universidad == uni_txt.Text);
            if (u!=null)
                pers = u.Personal;
            PersonalAd estudiante = new PersonalAd();
            estudiante.Nombre = nombreA_txt.Text;
            estudiante.Apellido = apellidoA_txt.Text;
            estudiante.Direccion = direccionA_txt.Text;
            estudiante.Fechanac = Calendar1.SelectedDate;
            estudiante.Igss = igss_txt.Text;
            estudiante.Profesion = profesion_txt.Text;
            estudiante.Iniciolab = iniciolab_cd.SelectedDate;
            estudiante.Finlab = finallab_cd.SelectedDate;

            pers.Add(estudiante);
            vaciar();
        }

        protected void universidadbt_Click(object sender, EventArgs e)
        {
            Universidades u = unis.Find(p => p.Universidad == uni_txt.Text);
            if (u==null)
            {
                Universidades universidad = new Universidades();
                universidad.Universidad = uni_txt.Text;
                universidad.Alumno = al.ToList();
                universidad.Personal = pers.ToList();
                universidad.Profesor = prof.ToList();

                unis.Add(universidad);

                GuardarJson();

                al.Clear();
                prof.Clear();
                pers.Clear();
            }
            else
            {
                u.Universidad = uni_txt.Text;
                u.Alumno = al;
                u.Profesor = prof;
                u.Personal = pers;
                GuardarJson();
            }
            uni_txt.Text = "";
            vaciar();
        }
    }
}