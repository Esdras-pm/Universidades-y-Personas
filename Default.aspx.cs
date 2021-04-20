using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Universidades_y_Personas
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Parse("1/01/1999");
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
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            persona_lb.Text = "Datos de Alumno:";
            borrartodo();
            carneal_lb.Visible = true;
            carneal_txt.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            persona_lb.Text = "Datos de Profesor:";
            borrartodo();
            id_lb.Visible = true;
            id_txt.Visible = true;
            titulo_lb.Visible = true;
            titulo_txt.Visible = true;
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
        }

    }
}