using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;


namespace EntityProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {//7.В коде окна создайте контекст базы данных и поместите свойство
     //  Notices в DataContext элемента DataGrid
        EntityContext context;
        public MainWindow()
        {
            context = new EntityContext("TestDbConnection");
            InitializeComponent();
            InitNoticeList();
        }

        private void InitNoticeList()
        {
            try
            {
                context.Notices.Load();
                dGrid.DataContext = context.Notices.Local;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        //10.Обработка событий нажатия кнопок главного окна
        //        Кнопки добавления и редактирования объекта должны вызывать
        //        открытия диалогового окна редактирования.Если при закрытии окна
        //редактирования была нажата кнопка ОК, то данные нужно сохранить:

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var notice = new Notice();
            EditWindow ew = new EditWindow(notice);
            var result = ew.ShowDialog();
            if (result == true)
            {
                context.Notices.Add(notice);
                context.SaveChanges();
                ew.Close();
            }
        }
        //11.При удалении объекта нужно вывести предупреждение:
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    Notice notice = dGrid.SelectedItem as Notice;
                    context.Notices.Remove(notice);                    
                }
                context.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show("Что-то пошло не так!!!\n" + ex.Message); }

        }

            private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Notice notice = dGrid.SelectedItem as Notice;

            EditWindow ew = new EditWindow(notice);
            var result = ew.ShowDialog();
            if (result == true)
            {
                context.SaveChanges();
                ew.Close();
            }
            else
            {
                // вернуть начальное значение
                context.Entry(notice).Reload();
                // перегрузить DataContext
                dGrid.DataContext = null;
                dGrid.DataContext = context.Notices.Local;
            }
        }
        //13.Обработка события нумерации при загрузке в dGrid
        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
