<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576173/14.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T140151)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))**
<!-- default file list end -->
# How to colorize map shapes using the ShapeAttributeToColorKeyProvider class 


<p>The following example demonstrates how to colorize chart items using the<strong> ShapeAttributeToColorKeyProvider</strong> class as a color information provider for the colorizer.<br />To solve this task, create a ShapeAttributeToColorKeyProvider object. Specify the <strong>ShapeAttributeToColorKeyProvider.AttributeName</strong> property value as a shape argument name. Assign the object to the<strong> KeyValueColorizer.ColorItemKeyProvider</strong> property.</p>
<p>Then, add <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapColorizerColorTextItemtopic">ColorizerColorTextItem</a> objects with keys, which represent attributes of shapes, and add it to the colorizer via the <strong>KeyValueColorizer.AddItem</strong> method.</p>

<br/>


