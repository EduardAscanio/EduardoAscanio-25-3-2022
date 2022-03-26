using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Microsoft.Data.Sqlite;

namespace NuevaListaDeTareas
{
    public partial class MainPage : ContentPage
    {
        public List<string> tareas;
        public List<string> tareasCompletas;
        public MainPage()
        {
            InitializeComponent();
            tareas = new List<string>
            { "Hacer la Cama", "Hacer el Desayuno", "Salir a Caminar"};

            tareasCompletas = new List<string>();
            ListView.ItemsSource = tareas;
        }

        public void Refresh() {
            ListView.ItemsSource = new List<string>();
            ListViewCompleted.ItemsSource = new List<string>();
            ListView.ItemsSource = tareas;
            ListViewCompleted.ItemsSource = tareasCompletas;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            tareas.Add(NuevaTarea.Text);
            Refresh();
        }

        private void DeleteTask(List<string> list, string item)  {
            list.Remove(item);
            Refresh();
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            DeleteTask (tareas,(sender as SwipeItem).CommandParameter as string);
        }

        private void CompleteBtn_Clicked(object sender, EventArgs e)
        {
            string item = (sender as SwipeItem).CommandParameter as string;
            tareasCompletas.Add(item);
            DeleteTask(tareas, item);
        }
        private void DeleteCompleted_Clicked(object sender, EventArgs e)
        {
            DeleteTask(tareasCompletas, (sender as SwipeItem).CommandParameter as string);
        }
    }
}
