using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using TheProject.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TheProject.ViewModels
{
    class VM_VLoad
    {       
        public string filepath { get; set; }

        private bool cancel;

        private List<int> sourceData;
        private List<int> destinationData;
        private CancellationTokenSource cancellationTokenSource;

        ModelBase models;

       public ICommand Bottons { get; }



        public VM_VLoad()
        {
            destinationData = new List<int>();
            sourceData = Enumerable.Range(1, 100).ToList();

            Bottons = new RelayCommand<string>(button);

            models = new ModelBase();
        }



        private async void button(string text)
        {

            if (text == "1")
            {
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;

                cancel = false;


                try
                {
                    // Ejecutar la transferencia en un Task
                    await Task.Run(() => TransferData(token), token);
                }
                catch (OperationCanceledException)
                {
                    System.Windows.MessageBox.Show("La operación ha sido cancelada.", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                
            }
            else if (text == "2")
            {
                OnCancelClick();
            }
            else
            {

                App.init.Show();
                App.loda.Close();

            }
            App.loda.BT_Load.IsEnabled = true;
        }



        public async void loadinfo(CancellationToken token)
        {

            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "All files (*.*)|*.*",
                Title = "Select a File"
            };

            // Mostrar el diálogo de archivo
            bool? result = openFileDialog.ShowDialog();

            // Verificar si el usuario seleccionó un archivo
            if (result == true)
            {

                filepath = openFileDialog.FileName;

                Tools tools = new Tools();
                var m = tools.LoadFromBinaryFile<ModelBase>(filepath);

                token.ThrowIfCancellationRequested(); // Verificación temprana

                // Actualización de SleepModels
                foreach (var items in m[0].sleepModels)
                {
                    token.ThrowIfCancellationRequested(); // Verificar cancelación en cada iteración
                    models.sleepModels.Add(items);
                    await Task.Delay(5000, token); // Pequeña pausa para hacer más probable la cancelación durante el trabajo
                }

                // Actualización de BreaksModels
                foreach (var items in m[0].breaksModels)
                {
                    token.ThrowIfCancellationRequested();
                    models.breaksModels.Add(items);
                    await Task.Delay(5000, token);
                }

                // Esperar un tiempo antes de continuar
                await Task.Delay(5000, token);

                // Actualización de ExerciseModels
                foreach (var items in m[0].exercisemodels)
                {
                    token.ThrowIfCancellationRequested();
                    models.exercisemodels.Add(items);
                    await Task.Delay(5000, token);
                }

                // Actualización de WorkModels
                foreach (var items in m[0].workModels)
                {
                    token.ThrowIfCancellationRequested();
                    models.workModels.Add(items);
                    await Task.Delay(5000, token);
                }

                // Actualización de TasksModels
                foreach (var items in m[0].tasksModels)
                {
                    token.ThrowIfCancellationRequested();
                    models.tasksModels.Add(items);
                    await Task.Delay(5000, token);
                }




            }         

            

        }


        //private async void OnTransferDataClick(System.Windows.Controls.ProgressBar progressBar)
        //{

        //    progressBar.Value = 0;
        //    cancellationTokenSource = new CancellationTokenSource();
        //    var token = cancellationTokenSource.Token;

        //    cancel = false;


        //    try
        //    {
        //        // Ejecutar la transferencia en un Task
        //        await Task.Run(() => TransferData(token), token);
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        System.Windows.MessageBox.Show("La operación ha sido cancelada.", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show($"Se produjo un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        private void OnCancelClick()
        {

            cancellationTokenSource.Cancel();
            //App.loda.textstate.Text = "Cancelando..";
            cancel = true;
            App.loda.BT_Load.Dispatcher.Invoke(() => { App.loda.BT_Load.IsEnabled = true; });

        }

        private async Task TransferData(CancellationToken token)
        {

            App.loda.BT_Load.Dispatcher.Invoke(() => { App.loda.BT_Load.IsEnabled = false; });
            App.loda.BT_Nex.Dispatcher.Invoke(() => { App.loda.BT_Nex.IsEnabled = false; });
            double cont = 0;
            foreach (var item in sourceData)
            {
                cont++;
                

                // Simular trabajo (con Delay asincrónico)

                await Task.Delay(100, token);

                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    destinationData.Add(item);
              
                    //    DestinationListBox.Items.Refresh();
                });

                await System.Windows.Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    await UpdateProgress(cont / sourceData.Count, App.loda.loadbar, 0);
                });



            }
            App.loda.BT_Load.Dispatcher.Invoke(() => { App.loda.BT_Load.IsEnabled = true; });
            App.loda.BT_Nex.Dispatcher.Invoke(() => { App.loda.BT_Nex.IsEnabled = true; });
        }


        public void pass ()
        {
            foreach( var item in sourceData)
            {
                destinationData.Add(item);
            }
        }



        public async Task UpdateProgress(double porcent, System.Windows.Controls.ProgressBar progressBar, int delay = 0)
        {

            double sum = porcent * 100;

            if (cancel)
            {
                App.loda.textstate.Dispatcher.Invoke(() => App.loda.textstate.Text = "Cancelado");
                return;
            }

            progressBar.Dispatcher.Invoke(() => progressBar.Value = sum);
            App.loda.textstate.Dispatcher.Invoke(() => App.loda.textstate.Text = $"{sum}%");
            await Task.Delay(100);




        }
    }
}
