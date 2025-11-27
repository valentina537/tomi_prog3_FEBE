using System;

namespace Proyecto2025.BE.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido {  get; set; }
        public required string Legajo { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
