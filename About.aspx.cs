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
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = GridView1.SelectedIndex;
            alumno_lb.Text = "Alumnos de Mesoamericana:";
            GridView2.DataSource = unis[selec].Alumno;
            GridView2.DataBind();
            profesor_lb.Text = "Profesores de Mesoamericana:";
            GridView3.DataSource = unis[selec].Profesor;
            GridView3.DataBind();
            personal_lb.Text = "Personal Administratico de Mesoamericana:";
            GridView4.DataSource = unis[selec].Personal;
            GridView4.DataBind();
        }
    }
}