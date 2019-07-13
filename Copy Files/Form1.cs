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

        private string _folderPathDestiny;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                _folderPathDestiny = LoadPathFromRegistry(_folderPathKey);
                txtBoxFolderPath.Text = _folderPathDestiny;

                string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    CopyFileToPathFolderDestiny(args[1]);
                }
            }
            catch (Exception ex)
            {

                GetError(ex);
            }
        }

        private void CopyFileToPathFolderDestiny(string argsPath)
        {
            try
            {
                string fileName = Path.GetFileName(argsPath);
                string destiny = Path.Combine(_folderPathDestiny, fileName);

                bool fileExist = File.Exists(destiny);

                if (fileExist)
                {
                    DialogResult dialogResult = MessageBox.Show("Ten plik już został dodany. Czy chcesz dodać go ponownie?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(argsPath);
                        string extension = Path.GetExtension(argsPath);
                        fileNameWithoutExtension += Guid.NewGuid();
                        fileName = fileNameWithoutExtension;
                        fileName += extension;
                        destiny = Path.Combine(_folderPathDestiny, fileName);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                File.Copy(argsPath, destiny);


                MessageBox.Show("Dodano plik!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                GetError(ex);
            }

            Environment.Exit(0);
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
                    _folderPathDestiny = folderBrowserDialog.SelectedPath;
                    txtBoxFolderPath.Text = _folderPathDestiny;
                    SavePathToRegistry(_folderPathKey, _folderPathDestiny);
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
                Process.Start(_folderPathDestiny);
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
                DirectoryInfo directoryInfo = new DirectoryInfo(_folderPathDestiny);

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
