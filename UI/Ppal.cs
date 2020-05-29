// Drasccy (c) 2020 Baltasar MIT License <baltasarq@gmail.com>


namespace Drasccy {
    using WForms = System.Windows.Forms;
    
    internal class Ppal {
        public static void Main(string[] args)
        {
            WForms.Application.Run( new MainWindowCore().View );
        }
    }
}
