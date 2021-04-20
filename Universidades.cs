using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Universidades_y_Personas
{
    public class Universidades
    {
        string universidad;
        List<Alumnos> alumno = new List<Alumnos>();
        List<Profesores> profesor = new List<Profesores>();
        List<PersonalAd> personal = new List<PersonalAd>();
        public Universidades()
        {
            Alumno = new List<Alumnos>();
            Profesor = new List<Profesores>();
            Personal = new List<PersonalAd>();
        }

        public string Universidad { get => universidad; set => universidad = value; }
        public List<Alumnos> Alumno { get => alumno; set => alumno = value; }
        public List<Profesores> Profesor { get => profesor; set => profesor = value; }
        public List<PersonalAd> Personal { get => personal; set => personal = value; }
    }
}