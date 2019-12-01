using DesarrolloBE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DPADesarrolloWeb2019.Utils
{
    public class Utils
    {
        
        public static List<Puesto_trabajo> csvLoad(string filePath, bool hasHeader)
        {
            List<Puesto_trabajo> retorno = null;

            using (var reader = new StreamReader(filePath))
            {
                retorno = new List<Puesto_trabajo>();
                Puesto_trabajo single = null;                 

                if (hasHeader)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    single = new Puesto_trabajo()
                    {
                        Documento_identidad = values[0],
                        NombreCompleto = values[1]
                    };
                    retorno.Add(single);
                    
                }
                return retorno;
            }
        }

        public static int csvProcessing(string filePath, bool hasHeader)
        {
            using (var reader = new StreamReader(filePath))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                int records = 0;

                if (hasHeader)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                     
                    records++;
                }
                return records;
            }
        }
    }
}