# How to colorize map shapes using the ShapeAttributeToColorKeyProvider class 


<p>The following example demonstrates how to colorize chart items using the<strong> ShapeAttributeToColorKeyProvider</strong> class as a color information provider for the colorizer.<br />To solve this task, create a ShapeAttributeToColorKeyProvider object. Specify the <strong>ShapeAttributeToColorKeyProvider.AttributeName</strong> property value as a shape argument name. Assign the object to the<strong> KeyValueColorizer.ColorItemKeyProvider</strong> property.</p>
<p>Then, add <a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapColorizerColorTextItemtopic">ColorizerColorTextItem</a> objects with keys, which represent attributes of shapes, and add it to the colorizer via the <strong>KeyValueColorizer.AddItem</strong> method.</p>

<br/>


