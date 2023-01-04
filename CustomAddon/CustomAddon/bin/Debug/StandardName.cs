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

namespace BIMobjectAddin
{
    [Transaction(TransactionMode.Manual)]
    internal class StandardName : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get UIDocument & Document
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                Family thisFamily = null;
                if (doc.IsFamilyDocument == true)
                {
                    thisFamily = doc.OwnerFamily;
                }
                if (thisFamily != null)
                {
                    FamilyManager familyManager = doc.FamilyManager;

                    Parameter material = thisFamily.LookupParameter("Material");


                    TaskDialog.Show("Info", material.AsValueString().ToString());

                    //Dictionary<string, FamilyParameter> familyParameters = new Dictionary<string, FamilyParameter>();



                    //foreach (FamilyParameter familyParameter in familyManager.Parameters)
                    //{
                    //    string name = familyParameter.Definition.Name;
                    //    familyParameters.Add(name, familyParameter);
                    //}
                    //List<string> keys = new List<string>(familyParameters.Keys);

                    //foreach(FamilyParameter parameter in familyManager.Parameters)
                    //{
                  
                    //    //value = parameter.Values.ToString();
                    //    //keys.Add(value); 
                    //}

                    //TaskDialog.Show("Info", keys.ToString());

                }

                return Result.Succeeded;
            } catch (Exception e)
            {

                message = e.Message;
                return Result.Failed;
            }
        }
    }
}