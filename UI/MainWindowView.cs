// Drasccy (c) 2020 Baltasar MIT License <baltasarq@gmail.com>


namespace Drasccy {
    using Draw = System.Drawing;
    using WForms = System.Windows.Forms;
    using Drasccy.Core;
    
    
    public class MainWindowView: WForms.Form {
        public enum ZoomValue { x1 = 1, x2 = 2, x4 = 4, x8 = 8, x16 = 16 };
        
        public MainWindowView()
        {
            this.Build();
            
            this.Grf.DrawLine( this.Pen, 0, 0, this.Width, this.Height );
        }

        void Build()
        {
            // Controls
            var pnl = new WForms.Panel {
                Dock = WForms.DockStyle.Fill
            };
            
            pnl.Controls.Add( this.BuildDrawingArea() );
            pnl.Controls.Add( this.BuildPalette()  );
            this.Controls.Add( pnl );

            // Last touches
            this.Menu = this.BuildMainMenu();
            this.ClientSize = new Draw.Size( this.Width, this.Height );
            this.MinimumSize = this.ClientSize;
            this.Text = AppInfo.CompleteName;
        }

        WForms.TableLayoutPanel BuildPalette()
        {
            var toret = new WForms.TableLayoutPanel {
                Dock = WForms.DockStyle.Left
            };

            this.BtLine = new WForms.Button {
                Text = "Line",
                Dock = WForms.DockStyle.Top
            };
            
            // Measure max width
            var grf = this.CreateGraphics();
            int width = (int) grf.MeasureString( this.BtLine.Text, this.Font ).Width;
            
            // Finish
            toret.Controls.Add( this.BtLine );
            toret.MaximumSize = new Draw.Size( width * 2, int.MaxValue );
            this.BtLine.Width = toret.MaximumSize.Width - 20;
            return toret;
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
            this.Image = new WForms.PictureBox {
                Dock = WForms.DockStyle.Fill
            };

            this.SetZoom( ZoomValue.x2 );
            return this.Image;
        }

        public void Cls()
        {
            this.Grf.FillRectangle( Draw.Brushes.White,
                                    0, 0,
                                    this.Width,
                                    this.Height ); 
        }

        public void SetZoom(ZoomValue zoomValue)
        {
            this.Zoom = (int) zoomValue;
            
            var bmp = new Draw.Bitmap(
                this.Width,
                this.Height );
            this.Image.Image = bmp;
            this.Image.Height = this.Height;
            this.Image.Width = this.Width;
            this.Grf = Draw.Graphics.FromImage( bmp );
            this.Pen = new Draw.Pen( Draw.Color.Black );
            this.Cls();
        }

        public Draw.Pen Pen {
            get; set;
        }

        public WForms.MenuItem OpQuit {
            get; set;
        }

        public int Width {
            get {
                return SpeccyPlatform.MaxWidth * this.Zoom;
            }
        }
        
        public int Height {
            get {
                return SpeccyPlatform.MaxHeight * this.Zoom;
            }
        }

        public WForms.Button BtLine {
            get; set;
        }

        int Zoom {
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
