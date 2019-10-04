using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
namespace CapaPresentacion
{
	public partial class Presentacion : Form
	{
		Producto p = new Producto();

		int pos;

		public Presentacion()
		{
			InitializeComponent();
		}

		private void bSalir_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Desea Salir? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void bAgregar_Click(object sender, EventArgs e)
		{
			try {
				p.nombre = tNombre.Text;
				p.descripcion = tDescripcion.Text;
				p.existencia = tExistencia.Text;
				p.fechaVencimiento = DateTime.Parse(tFVencimiento.Text);
				p.fechaCreacion = DateTime.Parse(tFCreacion.Text);
				p.marca = tMarca.Text;
				p.categoria = tCategoria.Text;
				p.estado = comboBox1.SelectedIndex;

				MessageBox.Show("El producto se agrego correctamente");

			} catch (Exception error) {
				MessageBox.Show("Ingrese los datos de forma valida");
			}

			Datos();
			limpiar();
		}
		public void Datos() {
			try
			{
				
				DataGridViewRow fila = new DataGridViewRow();
				fila.CreateCells(dataGridView1);
				fila.Cells[0].Value = p.nombre;
				fila.Cells[1].Value = p.descripcion;
				fila.Cells[2].Value = p.existencia;
				fila.Cells[3].Value = p.fechaVencimiento;
				fila.Cells[4].Value = p.fechaCreacion;
				fila.Cells[5].Value = p.marca;
				fila.Cells[6].Value = p.categoria;
				switch (p.estado) {
					case 0:
						fila.Cells[7].Value = "Activo";
						break;
					case 1:
						fila.Cells[7].Value = "Inactivo";
						break;
				}

				dataGridView1.Rows.Add(fila);
			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
			}
		}

		public void limpiar() {
			tNombre.Clear();
			tDescripcion.Clear();
			tMarca.Clear();
			tCategoria.Clear();
			tExistencia.Clear();
			
		}

		private void bEliminar_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
		}

		private void bEditar_Click(object sender, EventArgs e)
		{
			dataGridView1[0, pos].Value = tNombre.Text;
			dataGridView1[1, pos].Value = tDescripcion.Text;
			dataGridView1[2, pos].Value = tExistencia.Text;
			dataGridView1[3, pos].Value = tFVencimiento.Text;
			dataGridView1[4, pos].Value = tFCreacion.Text;
			dataGridView1[5, pos].Value = tMarca.Text;
			dataGridView1[6, pos].Value = tCategoria.Text;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			 pos = dataGridView1.CurrentRow.Index;

			tNombre.Text = dataGridView1[0,pos].Value.ToString();
			tDescripcion.Text = dataGridView1[1, pos].Value.ToString();
			tExistencia.Text = dataGridView1[2, pos].Value.ToString();
			tFVencimiento.Text = dataGridView1[3, pos].Value.ToString();
			tFCreacion.Text = dataGridView1[4, pos].Value.ToString();
			tMarca.Text = dataGridView1[5, pos].Value.ToString();
			tCategoria.Text = dataGridView1[6, pos].Value.ToString();

		
		}
	}
}
