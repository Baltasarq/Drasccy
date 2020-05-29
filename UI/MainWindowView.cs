// Drasccy (c) 2020 Baltasar MIT License <baltasarq@gmail.com>


namespace Drasccy {
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    using Drasccy.Core;
    
    
    public class MainWindowView: WForms.Form {
        const int MaxWidth = SpeccyPlatform.MaxWidth * 2;
        const int MaxHeight = SpeccyPlatform.MaxHeight * 2;
        
        public MainWindowView()
        {
            this.Build();
            
            this.Grf.DrawLine( this.Pen, 0, 0, MaxWidth, MaxHeight );
        }

        void Build()
        {
            var pnl = new WForms.Panel {
                Dock = WForms.DockStyle.Fill
            };
            
            pnl.Controls.Add( this.BuildDrawingArea() );
            this.Controls.Add( pnl );

            this.Menu = this.BuildMainMenu();
            this.ClientSize = new Draw.Size( MaxWidth, MaxHeight );
            this.MinimumSize = this.ClientSize;
            this.Text = AppInfo.CompleteName;
        }

        WForms.MainMenu BuildMainMenu()
        {
            var toret = new WForms.MainMenu();
            var fileMenu = new WForms.MenuItem( "&File" );
            
            this.OpQuit = new WForms.MenuItem( "&Quit" );
            fileMenu.MenuItems.Add( this.OpQuit );
            
            toret.MenuItems.Add( fileMenu );
            return toret;
        }

        WForms.PictureBox BuildDrawingArea()
        {
            var bmp = new Draw.Bitmap(
                MaxWidth,
                MaxHeight );
            this.Image = new WForms.PictureBox {
                Dock = WForms.DockStyle.Fill,
                Image = bmp,
                Height = MaxHeight,
                Width = MaxWidth
            };
            
            this.Grf = Draw.Graphics.FromImage( bmp );
            this.Pen = new Draw.Pen( Draw.Color.Black );
            this.Cls();
            return this.Image;
        }

        public void Cls()
        {
            this.Grf.FillRectangle( Draw.Brushes.White,
                                    0, 0,
                                    MaxWidth,
                                    MaxHeight ); 
        }

        public Draw.Pen Pen {
            get; set;
        }

        public WForms.MenuItem OpQuit {
            get; set;
        }

        Draw.Graphics Grf {
            get; set;
        }

        WForms.PictureBox Image {
            get; set;
        }
    }
}
