using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils;
using DevExpress.XtraMap;

namespace ColorizerShapeAttributeProvider {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap() {
            // Create a map control with initial settings and add it to the form.
            MapControl map = new MapControl() { Dock = DockStyle.Fill };
            this.Controls.Add(map);

            // Create a vector items layer.
            VectorItemsLayer itemsLayer = new VectorItemsLayer() {
                Colorizer = CreateColorizer(),
                Data = CreateData()
            };
            map.Layers.Add(itemsLayer);

            // Create a legend.
            map.Legends.Add(new ColorListLegend() { Layer = itemsLayer });
        }

        private MapDataAdapterBase CreateData() {
            MapItemStorage storage = new MapItemStorage();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++) {
                int sign = rnd.Next(2) > 0 ? 1 : -1;
                int coordX = rnd.Next(60) * sign;
                sign = rnd.Next(2) > 0 ? 1 : -1;
                int coordY = rnd.Next(110) * sign;
                int colorIndex = Math.Max(1, rnd.Next(4));
                storage.Items.Add(CreateBubbleItem(coordX, coordY, colorIndex));
            }

            return storage;
        }

        private MapBubble CreateBubbleItem(double x, double y, int colorIndex) {
            MapBubble bubble = new MapBubble();
            bubble.Location = new GeoPoint(x, y);
            bubble.Value = 60;
            bubble.Attributes.Add(new MapItemAttribute() { Name = "color", Value = string.Format("color{0}", colorIndex) } );
            return bubble;
        }

        private MapColorizer CreateColorizer() {
            KeyValueColorizer colorizer = new KeyValueColorizer();
            colorizer.AddItem("color1", new ColorizerColorTextItem() { Color = Color.Coral, Text = "Coral" });
            colorizer.AddItem("color2", new ColorizerColorTextItem() { Color = Color.Orange, Text = "Orange" });
            colorizer.AddItem("color3", new ColorizerColorTextItem() { Color = Color.LightBlue, Text = "Light Blue" });

            colorizer.ColorItemKeyProvider = new ShapeAttributeToColorKeyProvider() { AttributeName = "color" };
            return colorizer;
        }
    }

}

