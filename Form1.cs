using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace Actividad_Integradora_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Empresa empresa;
        private void Form1_Load(object sender, EventArgs e)
        {
            empresa = new Empresa();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Mostrar(dataGridView1, empresa.ListaDeInversores());
            Mostrar(dataGridView2, empresa.ListaDeAcciones());

        }

        private void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }

        private void button1_Click(object sender, EventArgs e) //BTN AGREGAR INVERSOR
        {
            try
            {
                var legajo = Interaction.InputBox("Legajo: ");
                var i = new Inversor(legajo);
                // Verificanos que el Legajo no exista.
                if (empresa.ValidarLegajo(i)) throw new Exception("El Legajo ya existe!");

                var nombre = Interaction.InputBox("Nombre: ");
                var apellido = Interaction.InputBox("Apellido: ");
                var dni = Interaction.InputBox("DNI: ");
                i.Nombre = nombre;
                i.Apellido = apellido;
                i.DNI = dni;
                empresa.AgregarInversor(i);

                Mostrar(dataGridView1, empresa.ListaDeInversores());

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e) //BTN ELIMINAR INVERSOR
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay Inversores para borrar!");

                var legajo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                empresa.BorrarInversor(new Inversor(legajo));
                Mostrar(dataGridView1, empresa.ListaDeInversores());
                //Mostrar(dataGridView4, c.ListaDeAutosyDuenos());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e) //BTN AGREGAR ACCION
        {
            try
            {

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void button3_Click(object sender, EventArgs e) //BTN AGREGAR ASIGNAR ACCION A INVERSOR
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) throw new Exception("No hay acciones para asignar !!!");
                var accion = new Accion(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay inversores para asignar !!!");
                var inversor = new Inversor(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                var cantidadAasignar = Interaction.InputBox("Que cantidad desea asignar?");
                //Verificar que la cantidad emitida no supere la cantidad comprada
                inversor.Cantidad_A_Asignar = Convert.ToInt32(cantidadAasignar);
                if(accion.CantidadEmitida>inversor.Cantidad_A_Asignar) throw new Exception("Cantidad insuficiente.");
                
                empresa.Asignar(inversor, accion);
                dataGridView1_RowEnter(null, null); //SE USA CUANDO SE CAMBIA DE FILA EN OTRA GRILLA
                //Mostrar(dataGridView4, empresa.ListaDeAutosyDuenos());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros de inversores !!!");
                var legajo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Mostrar(dataGridView3, empresa.ListaDeAccionesDeUnInversor(new Inversor(legajo)));
            }
            catch (Exception)
            {


            }
        }
    }
}
