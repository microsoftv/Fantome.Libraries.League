﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Fantome.Libraries.League.IO.MaterialLibrary
{
    public class MaterialLibraryFile
    {
        public List<MaterialLibraryMaterial> Materials = new List<MaterialLibraryMaterial>();

        public MaterialLibraryFile() { }

        public MaterialLibraryFile(string fileLocation)
        {
            using (StreamReader sr = new StreamReader(fileLocation))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine() == "[MaterialBegin]")
                    {
                        this.Materials.Add(new MaterialLibraryMaterial(sr));
                    }
                }
            }
        }

        public void Write(string fileLocation)
        {
            using (StreamWriter sw = new StreamWriter(fileLocation))
            {
                foreach (MaterialLibraryMaterial material in this.Materials)
                {
                    material.Write(sw);
                    sw.WriteLine();
                }
            }
        }
    }
}