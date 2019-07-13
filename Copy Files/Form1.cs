using Microsoft.Win32;
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

        private void GetError(Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                GetError(ex);
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
                GetError(ex);
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
                GetError(ex);
            }
            return folderPath;
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_folderPath);
            }
            catch (Exception ex)
            {
                GetError(ex);
            }
        }

        private void BtnDeleteEverything_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Na pewno chcesz usunąć wszystko z folderu?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteAllFiles();
                }
            }
            catch (Exception ex)
            {

                GetError(ex);
            }
            
        }

        private void DeleteAllFiles()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(_folderPath);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                {
                    dir.Delete(true);
                }

                MessageBox.Show("Usunięto wszystkie pliki i foldery", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                GetError(ex);
            }
        }
    }
}
