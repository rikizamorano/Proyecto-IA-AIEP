using System.Security.Cryptography.Xml;

namespace ProyAI_MVC.Models
{
    public class Unidad
    {

        public int Id_unidad { get; set; }
        public string Nombre_unidad { get; set; } // Nombre de la unidad
        public int Horas_pedagogicas { get; set; } // Relación con el modelo Asignatura
        public int Asignatura_id { get; set; } // Navegación a Asignatura
    }

}
}
