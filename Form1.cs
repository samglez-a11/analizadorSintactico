namespace analizadorSintactico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            analizador analizador = new analizador();

            analizador.Analizador(textAnalizar.Text.ToString());

            textLexico.Text = analizador.getToken();
            textErrores.Text = analizador.getErrores();
            mostrarAnalisis(analizador.getAnalisis(), analizador.getSalida());
        }

        private void mostrarAnalisis(List<String> lista, List<String> salida)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add(lista[i], salida[i]);
            }
        }
    }
}