using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlumnos.FE
{
    public partial class FormMat : Form
    {
        private readonly HttpClient _http;

        public FormMat()
        {
            InitializeComponent();

            _http = new HttpClient();
            _http.BaseAddress = new Uri("http://localhost:5134");
        }

        private async void FormMat_Load(object sender, EventArgs e)
        {
            await CargarMaterias();
        }

        private async Task CargarMaterias()
        {
            try
            {
                var materias = await _http.GetFromJsonAsync<List<Materia>>("Materias");
                dgvMaterias.DataSource = materias;
            }
            catch
            {
                MessageBox.Show("Error al cargar las materias, verifica la API.");
            }
        }

        private async void Agregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreMateria.Text))
            {
                MessageBox.Show("Ingrese un nombre para la materia.");
                return;
            }

            var nuevaMateria = new Materia
            {
                Nombre = NombreMateria.Text
            };

            var res = await _http.PostAsJsonAsync("Materias", nuevaMateria);

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia agregada correctamente.");
                NombreMateria.Clear();
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al agregar la materia.");
            }
        }

        private async void Editar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia.");
                return;
            }

            if (string.IsNullOrWhiteSpace(NombreMateria.Text))
            {
                MessageBox.Show("Ingrese un nuevo nombre para editar.");
                return;
            }

            int id = (int)dgvMaterias.CurrentRow.Cells["Id"].Value;

            var materiaEditada = new Materia
            {
                Id = id,
                Nombre = NombreMateria.Text
            };

            var res = await _http.PutAsJsonAsync($"Materias/{id}", materiaEditada);

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia editada correctamente.");
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al editar la materia.");
            }
        }

        private async void Eliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia.");
                return;
            }

            int id = (int)dgvMaterias.CurrentRow.Cells["Id"].Value;

            var res = await _http.DeleteAsync($"Materias/{id}");

            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia eliminada.");
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al eliminar la materia.");
            }
        }

        

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterias.CurrentRow != null)
            {
                NombreMateria.Text = dgvMaterias.CurrentRow.Cells["Nombre"].Value.ToString();
            }
        }
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
