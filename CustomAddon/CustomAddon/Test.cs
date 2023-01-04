using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI.Selection;

namespace CustomAddon
{
    [Transaction(TransactionMode.Manual)]
    internal class Test : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //Get Document
            Document doc = uidoc.Document;

            try
            {
                //Pick Object
                Reference pickedObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                //Retrive Element
                ElementId eleId = pickedObj.ElementId;
                Element ele = doc.GetElement(eleId);
                ElementId typeObj = ele.GetTypeId();
                Element obj = doc.GetElement(typeObj);

                TaskDialog.Show("Debug", "Tested!");


                //Retrive Parameter Value
                Parameter function = obj.LookupParameter("Product Type / Function");
                string functionTxt = function.AsValueString().ToString();

                Parameter type = obj.LookupParameter("Type");
                string typeTxt = type.AsValueString().ToString();

                Parameter material = obj.LookupParameter("Material");
                string materialTxt = material.AsValueString().ToString();

                Parameter brand = obj.LookupParameter("Brand / Production Name");
                string brandTxt = brand.AsValueString().ToString();

                Parameter model = obj.LookupParameter("Model / Series");
                string modelTxt = model.AsValueString().ToString();

                Parameter mark = obj.LookupParameter("Product Mark");
                string markTxt = mark.AsValueString().ToString();

               // Parameter parWidth = ele.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
              //  string widthTxt = parWidth.AsValueString();

                // Check is share
                Parameter width = ele.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
                if (width.IsShared)
                {
                    TaskDialog.Show("Debug", "share");
                }
                else
                {
                    TaskDialog.Show("Debug", "not share");
                }
              //  bool widthIsShare = width.IsShared;

              //  Parameter width = ele.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
              //  string widthTxt = width.AsValueString();
               

               // TaskDialog.Show("Debug", );


                // Parameter width = ele.LookupParameter("Width");
                // bool widthIsShare = width.IsShared;

                /* string widthTxt = null;
                  if (widthIsShare == true)
                  {
                      widthTxt = width.AsValueString().ToString();
                  } else
                  {
                    Parameter parWidth = ele.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
                      widthTxt = parWidth.AsValueString().ToString();
                  }
                 */

                //Parameter height = ele.LookupParameter("Height");
                //string heightTxt = height.AsValueString().ToString();

                //Parameter depth = ele.LookupParameter("Depth");
                //string depthTxt = depth.AsValueString().ToString();

                //Parameter color = ele.LookupParameter("Color");
                //string colorTxt = color.AsValueString().ToString();


                if (pickedObj != null)
                {

                    TaskDialog.Show("Info", "Product Type / Function: " + functionTxt + Environment.NewLine
                        + "Type:    " + typeTxt + Environment.NewLine
                        + "Material:    " + materialTxt + Environment.NewLine
                        + "Brand / Production Name: " + brandTxt + Environment.NewLine
                        + "Model:   " + modelTxt + Environment.NewLine
                        + "Mark:    " + markTxt + Environment.NewLine
                        //+ "Width:   " + widthTxt + Environment.NewLine
                        //+ "Height: " + heightTxt + Environment.NewLine
                        //+ "Depth: " + depthTxt + Environment.NewLine
                        //+ "Color: " + colorTxt + Environment.NewLine
                        );
                }
                else
                {
                    TaskDialog.Show("Error", "Please select an element!");
                }

                return Result.Succeeded;
            }
            catch (Exception e)
            {

                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
