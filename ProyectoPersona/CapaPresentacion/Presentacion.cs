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
		int pos;
		Persona p = new Persona();
		public Presentacion()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Desea Salir? ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				p.nombre = tNombre.Text;
				p.apellido = tApellido.Text;
				p.fechaNacimiento = DateTime.Parse(dateTimePicker1.Text);
				p.edad = int.Parse(tEdad.Text);
				p.sexo = tSexo.Text;
				p.estado = comboBox1.SelectedIndex;

				MessageBox.Show("La persona se agrego");

			}
			catch (Exception error)
			{
				MessageBox.Show("Ingrese los datos de forma valida");
			}

			Datos();
			limpiar();
		}
		public void Datos()
		{
			try
			{

				DataGridViewRow fila = new DataGridViewRow();
				fila.CreateCells(dataGridView1);
				fila.Cells[0].Value = p.nombre;
				fila.Cells[1].Value = p.apellido;
				fila.Cells[2].Value = p.fechaNacimiento;
				fila.Cells[3].Value = p.edad;
				fila.Cells[4].Value = p.sexo;
				switch (p.estado)
				{
					case 0:
						fila.Cells[5].Value = "Vivo";
						break;
					case 1:
						fila.Cells[5].Value = "Muerto";
						break;
				}

				dataGridView1.Rows.Add(fila);
			}
			catch (Exception error)
			{
				MessageBox.Show(error.Message);
			}
		}
		public void limpiar()
		{
			tNombre.Clear();
			tApellido.Clear();
			tEdad.Clear();
			tSexo.Clear();

		}

		private void button3_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView1[0, pos].Value = tNombre.Text;
			dataGridView1[1, pos].Value = tApellido.Text;
			dataGridView1[2, pos].Value = DateTime.Parse(dateTimePicker1.Text);
			dataGridView1[3, pos].Value = tEdad.Text;
			dataGridView1[4, pos].Value = tSexo.Text;
			dataGridView1[5, pos].Value = comboBox1.Text;

			MessageBox.Show("La persona se edito");
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			pos = dataGridView1.CurrentRow.Index;

			tNombre.Text = dataGridView1[0, pos].Value.ToString();
			tApellido.Text = dataGridView1[1, pos].Value.ToString();
			dateTimePicker1.Text = dataGridView1[2, pos].Value.ToString();
			tEdad.Text = dataGridView1[3, pos].Value.ToString();
			tSexo.Text = dataGridView1[4, pos].Value.ToString();
			comboBox1.Text = dataGridView1[5, pos].Value.ToString();
		}
	}
}
