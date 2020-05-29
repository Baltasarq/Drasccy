// Drasccy (c) 2020 Baltasar MIT License <baltasarq@gmail.com>


namespace Drasccy {
    public class MainWindowCore {
        public MainWindowCore()
        {
            this.View = new MainWindowView();

            this.View.OpQuit.Click += (obj,  args) => this.OnQuit();
        }

        void OnQuit()
        {
            this.View.Close();
        }

        public MainWindowView View {
            get; set;
        }
    }
}
