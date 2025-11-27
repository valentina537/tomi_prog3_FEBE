namespace Proyecto2025.BE.Models
{
    public class Inscripciones
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        //
        public Alumno? Alumno { get; set; }
        public Materia? Materia { get; set; }
    }
}
