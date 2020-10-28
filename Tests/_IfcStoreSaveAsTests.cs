using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xbim.Ifc;
using Xbim.IO;
using Xbim.ModelGeometry.Scene;

namespace Xbim.IO.Tests
{
    [TestClass]
    public class _IfcStoreSaveAsTests
    {
        [TestMethod]
        public void CreateGeometryTest()
        {
            IfcStore.ModelProviderFactory.UseHeuristicModelProvider();

            var filePath = "TestFiles\\02_ONKS_Unicode.ifc";
            var ifcFile = new FileInfo(filePath);

            using (var model = IfcStore.Open(filePath))
            {
                Debug.WriteLine($"finished IfcStore.Open()");
                int label = 1;
                int nullCounter = 0;
                foreach (var instance in model.Instances)
                {
                    if (instance == null)
                    {
                        nullCounter += 1;   // count up
                        Assert.IsNull(model.Instances[label]);
                        Debug.WriteLine($".Instances[{label}] is null.");
                    }
                    label += 1;
                }
                Debug.WriteLine($"num of null instances = {nullCounter}, num of label = {label - 1}");

                
                var c = new Xbim3DModelContext(model);
                //c.CreateContext(null, true);
                c.CreateContext();

                var newName = Path.ChangeExtension(ifcFile.Name, ".xbim");
                model.SaveAs(newName, StorageType.Xbim);    // このメソッド内で例外が発生する！
                var xbimFile = new FileInfo(newName);

                Assert.IsTrue(xbimFile.Exists);
                
            }
        }
    }
}
