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
using System.Windows.Shapes;

namespace EntityProject
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    /// 

    //8.Создание окна редактирования
    //Для редактирования или создания нового объекта необходимо этот
    //объект передать окну.Для этого можно создать параметризированный
    //конструктор, принимающий нужный объект в качестве параметра.
    //Полученный объект затем нужно привязать к элементам ввода:
    public partial class EditWindow : Window
    {
        Notice notice;
        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(Notice notice) : this()
        {
            this.notice = notice;
            grid.DataContext = notice;
        }
        //9.Обработка событий нажатия кнопок может выглядеть так
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
