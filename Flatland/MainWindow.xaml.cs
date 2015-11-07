using Messaging;
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

namespace Flatland
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IHandle<RenderMessage>
    {
        public MainWindow()
        {
            InitializeComponent();


        }


        public void Handle(RenderMessage message)
        {
            Dispatcher.Invoke(message.DrawAction, this.canvas);
        }

        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            var bus = new Bus(new Dispatcher());
            bus.Subscribe(this);
            var world = new World(bus, this.canvas);
        }
    }
}
