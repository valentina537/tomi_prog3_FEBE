using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Proyecto2025.FE
{
    public partial class FormMa : System.Windows.Forms.Form
    {
        private readonly HttpClient _http;

        public FormMa()
        {
            InitializeComponent();
            _http = new HttpClient();
            _http.BaseAddress = new Uri("http://localhost:5134");
           // this.ClientSize = new System.Drawing.Size(800, 450);
            //this.Text = "FormMa";

        }

        private async void FormMaterias_Load(object sender, EventArgs e)
        {
            await CargarMaterias();
        }

        private async Task CargarMaterias()
        {
            var materias = await _http.GetFromJsonAsync<List<Materia>>("Materias");
            dgvMaterias.DataSource = materias;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMateria.Text))
            {
                MessageBox.Show("Ingrese un nombre de materia");
                return;
            }

            var nueva = new Materia
            {
                Nombre = txtNombreMateria.Text
            };

            var response = await _http.PostAsJsonAsync("Materias", nueva);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia agregada!");
                txtNombreMateria.Clear();
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al agregar la materia");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia");
                return;
            }

            int id = (int)dgvMaterias.CurrentRow.Cells["Id"].Value;

            var response = await _http.DeleteAsync($"Materias/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia eliminada");
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al eliminar");
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una materia");
                return;
            }

            int id = (int)dgvMaterias.CurrentRow.Cells["Id"].Value;

            var materia = new Materia
            {
                Id = id,
                Nombre = txtNombreMateria.Text
            };

            var response = await _http.PutAsJsonAsync($"Materias/{id}", materia);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Materia editada");
                await CargarMaterias();
            }
            else
            {
                MessageBox.Show("Error al editar");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void DataMateria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMateriasAlumno.CurrentRow != null)
            {
                NombreMateria.Text = dgvMateriasAlumno.CurrentRow.Cells["Nombre"].Value.ToString();
            }
        }
    }

    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
