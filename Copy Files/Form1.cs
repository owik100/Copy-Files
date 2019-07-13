using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Files
{
    public partial class Form1 : Form
    {
        private readonly string _folderPathKey = "PathFolder";
        private readonly string _registrySubKey = @"SOFTWARE\Owik\CopyImages";

        private string _folderPath;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _folderPath = LoadPathFromRegistry(_folderPathKey);
            txtBoxFolderPath.Text = _folderPath;
        }

        private void BtnChooseFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    _folderPath = folderBrowserDialog.SelectedPath;
                    txtBoxFolderPath.Text = _folderPath;
                    SavePathToRegistry(_folderPathKey, _folderPath);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SavePathToRegistry(string key, string value)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(_registrySubKey);
                registryKey.SetValue(key, value);
                registryKey.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string LoadPathFromRegistry(string key)
        {
            string folderPath = string.Empty;

            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(_registrySubKey);

                if (registryKey != null)
                {
                    folderPath = registryKey.GetValue(key).ToString();
                    registryKey.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return folderPath;
        }
    }
}
