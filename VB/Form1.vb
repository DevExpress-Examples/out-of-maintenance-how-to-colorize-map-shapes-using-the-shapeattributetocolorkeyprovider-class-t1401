Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports DevExpress.Utils
Imports DevExpress.XtraMap

Namespace ColorizerShapeAttributeProvider
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            InitializeMap()
        End Sub

        Private Sub InitializeMap()
            ' Create a map control with initial settings and add it to the form.
            Dim map As New MapControl() With {.Dock = DockStyle.Fill}
            Me.Controls.Add(map)

            ' Create a vector items layer.
            Dim itemsLayer As New VectorItemsLayer() With {.Colorizer = CreateColorizer(), .Data = CreateData()}
            map.Layers.Add(itemsLayer)

            ' Create a legend.
            map.Legends.Add(New ColorListLegend() With {.Layer = itemsLayer})
        End Sub

        Private Function CreateData() As MapDataAdapterBase
            Dim storage As New MapItemStorage()
            Dim rnd As New Random()
            For i As Integer = 0 To 99
                Dim sign As Integer = If(rnd.Next(2) > 0, 1, -1)
                Dim coordX As Integer = rnd.Next(60) * sign
                sign = If(rnd.Next(2) > 0, 1, -1)
                Dim coordY As Integer = rnd.Next(110) * sign
                Dim colorIndex As Integer = Math.Max(1, rnd.Next(4))
                storage.Items.Add(CreateBubbleItem(coordX, coordY, colorIndex))
            Next i

            Return storage
        End Function

        Private Function CreateBubbleItem(ByVal x As Double, ByVal y As Double, ByVal colorIndex As Integer) As MapBubble
            Dim bubble As New MapBubble()
            bubble.Location = New GeoPoint(x, y)
            bubble.Value = 60
            bubble.Attributes.Add(New MapItemAttribute() With {.Name = "color", .Value = String.Format("color{0}", colorIndex)})
            Return bubble
        End Function

        Private Function CreateColorizer() As MapColorizer
            Dim colorizer As New KeyValueColorizer()
            colorizer.AddItem("color1", New ColorizerColorTextItem() With {.Color = Color.Coral, .Text = "Coral"})
            colorizer.AddItem("color2", New ColorizerColorTextItem() With {.Color = Color.Orange, .Text = "Orange"})
            colorizer.AddItem("color3", New ColorizerColorTextItem() With {.Color = Color.LightBlue, .Text = "Light Blue"})

            colorizer.ColorItemKeyProvider = New ShapeAttributeToColorKeyProvider() With {.AttributeName = "color"}
            Return colorizer
        End Function
    End Class

End Namespace

