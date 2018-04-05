using RestfulClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCVTest
{
    public partial class ImportFace : Form
    {

        List<String> files = new List<String>();

        public ImportFace()
        {
            InitializeComponent();
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (txtFolderPath.Text != "" && Directory.Exists(txtFolderPath.Text))
                {
                    fbd.SelectedPath = txtFolderPath.Text;
                }
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFolderPath.Text = fbd.SelectedPath;
                    
                    files = Directory.GetFiles(fbd.SelectedPath, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
                    LstImage.DataSource = files;
                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Count, "Message");
                }
            }
        }

        private async void BtnImport_Click(object sender, EventArgs e)
        {
            foreach (String file in files)
            {
                if (File.Exists(file))
                {
                    var filename = Path.GetFileNameWithoutExtension(file);
                    Byte[] bytes = File.ReadAllBytes(file);
                    String image = Convert.ToBase64String(bytes);
                    try
                    {
                        if (!(await ImportFaceToServerAsync(new Person(filename, "", new WebEntity.Face(image)))))
                        {
                            LstFailBox.Items.Add(file);
                        }
                    } catch (Exception ex)
                    {
                        Debug.WriteLine("Error import image: " + ex);
                        LstFailBox.Items.Add(file);
                    }
                    
                }
            }
        }

        private async Task<bool> ImportFaceToServerAsync(Person person)
        {
            var response = await RestfulClient.CreatePerson(person);
            if (response.ReturnCode == 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
