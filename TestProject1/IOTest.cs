using System;
using Xunit;

using DAL;
using DAL.Types;
using System.Collections.Generic;

namespace TestProject1
{
    public class IOTest
    {
        [Fact]
        public void GetAllMaterialsTest()
        {
            using (IO io = new IO())
            {
                List<MaterialRow>materials = io.GetAllMaterials();

                Assert.NotNull(materials);
            }
        }
    }
}
