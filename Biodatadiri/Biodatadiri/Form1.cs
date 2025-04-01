using System;
using System.Drawing;
using System.Windows.Forms;

namespace BiodataDiri
{
    public partial class Form1 : Form
    {
        // Deklarasi komponen UI
        private Label lblNama, lblAlamat, lblJenisKelamin, lblTanggalLahir;
        private TextBox txtNama, txtAlamat;
        private ComboBox comboBoxJK;
        private DateTimePicker dateTimePicker1; // Deklarasi DateTimePicker

        private Button btnSimpan, btnReset, btnPilihFoto;
        private PictureBox pictureBoxFoto;
        private OpenFileDialog openFileDialog;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Biodata Diri"; // Judul Form
            this.Size = new Size(500, 500); // Ukuran Form

            // GroupBox untuk tampilan lebih rapi
            GroupBox groupBox = new GroupBox
            {
                Text = "Form Biodata",
                Location = new Point(20, 20),
                Size = new Size(440, 280)
            };

            // Label
            lblNama = new Label { Text = "Nama:", Location = new Point(20, 30), AutoSize = true };
            lblAlamat = new Label { Text = "Alamat:", Location = new Point(20, 70), AutoSize = true };
            lblJenisKelamin = new Label { Text = "Jenis Kelamin:", Location = new Point(20, 110), AutoSize = true };
            lblTanggalLahir = new Label { Text = "Tanggal Lahir:", Location = new Point(20, 150), AutoSize = true };

            // TextBox
            txtNama = new TextBox { Location = new Point(120, 30), Width = 280 };
            txtAlamat = new TextBox { Location = new Point(120, 70), Width = 280 };

            // ComboBox
            comboBoxJK = new ComboBox { Location = new Point(120, 110), Width = 280 };
            comboBoxJK.Items.AddRange(new string[] { "Laki-laki", "Perempuan" });

            // DateTimePicker
            dateTimePicker1 = new DateTimePicker { Location = new Point(120, 150), Width = 280 };

            // Tombol
            btnSimpan = new Button { Location = new Point(120, 200), Text = "Simpan", Width = 80 };
            btnReset = new Button { Location = new Point(220, 200), Text = "Reset", Width = 80 };

            btnSimpan.Click += btnSimpan_Click;
            btnReset.Click += btnReset_Click;

            // Menambahkan komponen ke GroupBox
            groupBox.Controls.Add(lblNama);
            groupBox.Controls.Add(txtNama);
            groupBox.Controls.Add(lblAlamat);
            groupBox.Controls.Add(txtAlamat);
            groupBox.Controls.Add(lblJenisKelamin);
            groupBox.Controls.Add(comboBoxJK);
            groupBox.Controls.Add(lblTanggalLahir);
            groupBox.Controls.Add(dateTimePicker1);
            groupBox.Controls.Add(btnSimpan);
            groupBox.Controls.Add(btnReset);

            // PictureBox untuk foto
            pictureBoxFoto = new PictureBox
            {
                Location = new Point(150, 320),
                Size = new Size(120, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Tombol Pilih Foto
            btnPilihFoto = new Button
            {
                Text = "Pilih Foto",
                Location = new Point(170, 450),
                Width = 80
            };
            btnPilihFoto.Click += BtnPilihFoto_Click;

            // OpenFileDialog untuk memilih gambar
            openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            // Menambahkan komponen ke Form
            Controls.Add(groupBox);
            Controls.Add(pictureBoxFoto);
            Controls.Add(btnPilihFoto);

            this.Load += Form1_Load;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text;
            string alamat = txtAlamat.Text;
            string tanggalLahir = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string jenisKelamin = comboBoxJK.SelectedItem?.ToString() ?? "Belum dipilih";

            string biodata = $"Nama: {nama}\nAlamat: {alamat}\nTanggal Lahir: {tanggalLahir}\nJenis Kelamin: {jenisKelamin}";
            MessageBox.Show(biodata, "Biodata Diri", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNama.Clear();
            txtAlamat.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboBoxJK.SelectedIndex = -1;
            pictureBoxFoto.Image = null;
        }

        private void BtnPilihFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form berhasil dimuat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
