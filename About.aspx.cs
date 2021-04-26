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
    public partial class About : Page
    {
        static List<Universidades> unis = new List<Universidades>();
        static List<Alumnos> al = new List<Alumnos>();
        static List<Profesores> prof = new List<Profesores>();
        static List<PersonalAd> pers = new List<PersonalAd>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string archivo = Server.MapPath("UniversidadesP.json");
            StreamReader jsonStream = File.OpenText(archivo);

            string json = jsonStream.ReadToEnd(); jsonStream.Close();
            unis = JsonConvert.DeserializeObject<List<Universidades>>(json);

            GridView1.DataSource = unis;
            GridView1.DataBind();
            MaintainScrollPositionOnPostBack = true;
        }
        private void GuardarJson()
        {
            string json = JsonConvert.SerializeObject(unis);
            string archivo = Server.MapPath("UniversidadesP.json");
            System.IO.File.WriteAllText(archivo, json);
        }
        public void alumnomostrar(bool siono)
        {
            alapellido_lb.Visible = siono;
            alapellido_txt.Visible = siono;
            aldireccion_lb.Visible = siono;
            aldireccion_txt.Visible = siono;
            alfechanac_cd.Visible = siono;
            alfechanac_lb.Visible = siono;
            alnombre_lb.Visible = siono;
            alnombre_txt.Visible = siono;
            carneal_lb.Visible = siono;
            carneal_txt.Visible = siono;
            alumnobt.Enabled = siono;
        }
        void esconder()
        {
            alumnomostrar(false);
            alumnobt.Visible = false;
            profebt.Visible = false;
            profebt.Enabled = false;
            alumno_lb.Text = "";
            profesor_lb.Text = "";
            personal_lb.Text = "";
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridView1.SelectedIndex;
            esconder();
            GridView2.DataSource = unis[selec].Alumno;
            GridView2.DataBind();
            GridView3.DataSource = unis[selec].Profesor;
            GridView3.DataBind();
            GridView4.DataSource = unis[selec].Personal;
            GridView4.DataBind();
            if (unis[selec].Alumno.Count>0)
            {
                alumno_lb.Text = "Alumnos de "+unis[selec].Universidad+":";
                alumnobt.Visible = true;
            }
            if (unis[selec].Profesor.Count > 0)
            {
                profesor_lb.Text = "Profesores de " + unis[selec].Universidad + ":";
                profebt.Visible = true;
            }
            if (unis[selec].Personal.Count > 0)
                personal_lb.Text = "Personal administrativo de " + unis[selec].Universidad + ":";
            alumnomostrar(false);
        }

        protected void profebt_Click(object sender, EventArgs e)
        {
            int selec = GridView1.SelectedIndex;
            int selec2 = GridView3.SelectedIndex;
            unis[selec].Profesor.RemoveAt(selec2);
            GuardarJson();
            profebt.Enabled = false;

            GridView3.DataSource = unis[selec].Profesor;
            GridView3.DataBind();
        }
        void vaciar()
        {
            alnombre_txt.Text = "";
            alapellido_txt.Text = "";
            aldireccion_txt.Text = "";
            alfechanac_cd.SelectedDate = DateTime.Parse("1999-01-01T00:00:00");
            carneal_txt.Text = "";
        }
        protected void alumnobt_Click(object sender, EventArgs e)
        {
            int selec = GridView1.SelectedIndex;
            int selec2 = GridView2.SelectedIndex;

            unis[selec].Alumno.RemoveAt(selec2);
            al = unis[selec].Alumno;
            Alumnos estudiante = new Alumnos();
            estudiante.Nombre = alnombre_txt.Text;
            estudiante.Apellido = alapellido_txt.Text;
            estudiante.Direccion = aldireccion_txt.Text;
            estudiante.EdadP = estudiante.edad(alfechanac_cd.SelectedDate);
            estudiante.Fechanac = alfechanac_cd.SelectedDate;
            estudiante.Carne = carneal_txt.Text;

            al.Add(estudiante);
            unis[selec].Alumno = al;

            GuardarJson();
            alumnomostrar(false);
            vaciar();

            GridView2.DataSource = unis[selec].Alumno;
            GridView2.DataBind();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            profebt.Enabled = true;
            alumnomostrar(false);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridView1.SelectedIndex;
            int selec2 = GridView2.SelectedIndex;
            alumnomostrar(true);
            alapellido_txt.Text = unis[selec].Alumno[selec2].Apellido;
            alnombre_txt.Text = unis[selec].Alumno[selec2].Nombre;
            aldireccion_txt.Text = unis[selec].Alumno[selec2].Direccion;
            alfechanac_cd.SelectedDate = unis[selec].Alumno[selec2].Fechanac;
            carneal_txt.Text = unis[selec].Alumno[selec2].Carne;
        }

        protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[7].Visible = false;
        }
    }
}