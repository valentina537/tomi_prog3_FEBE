using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace SistemaAlumnos.FE
{
    public partial class FormInscripciones : Form
    {
        private int alumnoId;
        private int materiaSeleccionadaId = -1;

        private readonly HttpClient http = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5134/api/")
        };

        public FormInscripciones(int idAlumno, string nombre, string apellido)
        {
            InitializeComponent();
            alumnoId = idAlumno;
            lblAlumno.Text = $"Inscripciones de: {nombre} {apellido}";
        }

        // =====================================================
        //                  LOAD DEL FORM
        // =====================================================
        private void FormInscripciones_Load(object sender, EventArgs e)
        {
            CargarMaterias();
            CargarMateriasDelAlumno();
        }

        // =====================================================
        //                CARGAR MATERIAS
        // =====================================================
        private async void CargarMaterias()
        {
            try
            {
                var materias = await http.GetFromJsonAsync<List<Materia>>("materias");

                cmbMaterias.DataSource = materias;
                cmbMaterias.DisplayMember = "Nombre";
                cmbMaterias.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar materias: " + ex.Message);
            }
        }

        // =====================================================
        //      CARGAR MATERIAS YA INSCRIPTAS DEL ALUMNO
        // =====================================================
        private async void CargarMateriasDelAlumno()
        {
            try
            {
                var materiasAlumno = await http.GetFromJsonAsync<List<Materia>>(
                    $"inscripciones/alumno/{alumnoId}");

                dgvMateriasAlumno.DataSource = materiasAlumno;

                // Oculto columnas para que quede prolijo
                if (dgvMateriasAlumno.Columns.Contains("Id"))
                    dgvMateriasAlumno.Columns["Id"].Visible = false;

                if (dgvMateriasAlumno.Columns.Contains("Alumnos"))
                    dgvMateriasAlumno.Columns["Alumnos"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inscripciones: " + ex.Message);
            }
        }

        // =====================================================
        //                BOTÓN INSCRIBIR
        // =====================================================
        private async void btnInscribir_Click(object sender, EventArgs e)
        {
            if (cmbMaterias.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná una materia");
                return;
            }

            int idMateria = (int)cmbMaterias.SelectedValue;

            var inscripcion = new
            {
                AlumnoId = alumnoId,
                MateriaId = idMateria
            };

            try
            {
                var response = await http.PostAsJsonAsync("inscripciones", inscripcion);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Inscripción realizada con éxito ❤️");
                    CargarMateriasDelAlumno();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("No se pudo inscribir: " + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inscribir: " + ex.Message);
            }
        }

        // =====================================================
        //       SELECCIONAR MATERIA EN EL DATAGRID
        // =====================================================
        private void dgvMateriasAlumno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvMateriasAlumno.Rows[e.RowIndex].Selected = true;

                // tomo el ID de la materia seleccionada
                materiaSeleccionadaId =
                    Convert.ToInt32(dgvMateriasAlumno.Rows[e.RowIndex].Cells["Id"].Value);
            }
        }

        // =====================================================
        //                 BOTÓN ELIMINAR
        // =====================================================
        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (materiaSeleccionadaId == -1)
            {
                MessageBox.Show("Seleccioná una inscripción");
                return;
            }

            var response = await http.DeleteAsync(
                $"inscripciones?alumnoId={alumnoId}&materiaId={materiaSeleccionadaId}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Inscripción eliminada correctamente 🗑️");
                CargarMateriasDelAlumno();
                materiaSeleccionadaId = -1;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Error al eliminar: " + error);
            }
        }

        // =====================================================
        //                 BOTÓN EDITAR
        // =====================================================
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (materiaSeleccionadaId == -1)
            {
                MessageBox.Show("Seleccioná una inscripción");
                return;
            }

            if (cmbMaterias.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná una nueva materia");
                return;
            }

            int nuevaMateriaId = (int)cmbMaterias.SelectedValue;

            // Realmente editar = eliminar + volver a inscribir
            await http.DeleteAsync(
                $"inscripciones?alumnoId={alumnoId}&materiaId={materiaSeleccionadaId}");

            var nuevaInscripcion = new { AlumnoId = alumnoId, MateriaId = nuevaMateriaId };

            await http.PostAsJsonAsync("inscripciones", nuevaInscripcion);

            MessageBox.Show("Inscripción editada correctamente ✏️");

            CargarMateriasDelAlumno();
            materiaSeleccionadaId = -1;
        }
        //
        private void lblAlumno_Click(object sender, EventArgs e)
        {
            // No hace nada, solo evita error
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento vacío o lo que quieras poner
        }

        private void dgvMateriasAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvMateriasAlumno.Rows[e.RowIndex].Selected = true;

                materiaSeleccionadaId = Convert.ToInt32(
                dgvMateriasAlumno.Rows[e.RowIndex].Cells["Id"].Value);

            }
        }
    }
}