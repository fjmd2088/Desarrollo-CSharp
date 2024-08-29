using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desarrollo_C_
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            basedatosSQLite();
            ComboBoxLenguaIndigena();
        }

        private void basedatosSQLite()
        {
            string cadena = "Data Source = Desarrollo_CSharp.db; Version=3;"
                ;
            using (SQLiteConnection conn = new SQLiteConnection(cadena))
            {
                conn.Open();
                string query = "SELECT unidad_administrativa FROM TR_UA";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreComision = reader["unidad_administrativa"].ToString();
                            dataGridView1.Rows.Add(nombreComision);
                        }
                    }
                }
            }
        }

        private void ComboBoxLenguaIndigena()
        {
            // Crear una lista para almacenar los datos del ComboBox
            List<string> opcionesComboBox = new List<string>();

            string connectionString = "Data Source = Desarrollo_CSharp.db; Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_lengua_indigena FROM TC_LENGUA_INDIGENA";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            opcionesComboBox.Add(reader["id_lengua_indigena"].ToString());
                        }
                    }
                }
            }

            // Asignar ComboBox a cada celda de la columna c2
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();

                // Añadir las opciones al ComboBoxCell
                comboBoxCell.Items.AddRange(opcionesComboBox.ToArray());

                // Añadir el ComboBoxCell a la columna c2 de la fila actual
                fila.Cells["empleo_anterior"] = comboBoxCell;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del FolderBrowserDialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // Título del diálogo
                folderDialog.Description = "Seleccione un directorio";

                // Mostrar el diálogo y verificar si el usuario seleccionó un directorio
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtener la ruta del directorio seleccionado
                    string rutaSeleccionada = folderDialog.SelectedPath;

                    // Mostrar la ruta seleccionada en un control, como un TextBox
                    txtRutaDirectorio.Text = rutaSeleccionada;

                    // Puedes hacer algo con la ruta seleccionada aquí
                    MessageBox.Show("Directorio seleccionado: " + rutaSeleccionada);
                }
            }
        }
    }
}
